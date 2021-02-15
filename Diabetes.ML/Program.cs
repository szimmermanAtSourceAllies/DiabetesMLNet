using System;
using System.Collections.Generic;
using System.Linq;
using Diabetes.Models;
using FileHelpers;
using Microsoft.ML;
using Microsoft.ML.Transforms;

namespace Diabetes.ML
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // WriteModelFromDataDictionary();
            // return;

            var mlContext = new MLContext();

            BuildTrainEvaluateAndSaveModel(mlContext);

            Console.WriteLine("=============== End of process, hit any key to finish ===============");
        }

        private static void WriteModelFromDataDictionary()
        {
            var dbmEngine = new FileHelperEngine<DataDictionary>();
            var records = dbmEngine.ReadFile("/Users/szimmerman/dev/wids/Diabetes/datasets/DataDictionaryWiDS2021.csv");

            Console.WriteLine("using Microsoft.ML.Data;");
            Console.WriteLine("");
            Console.WriteLine("namespace Diabetes.Models");
            Console.WriteLine("{");
            Console.WriteLine("\tpublic class Dataset");
            Console.WriteLine("\t{");
            var columnNumber = 0;
            foreach (var record in records)
            {
                Console.WriteLine($"\t\t/// <summary>");
                Console.WriteLine($"\t\t/// Category: {record.Category}");
                Console.WriteLine($"\t\t/// UOM: {record.UnitOfMeasure}");
                Console.WriteLine($"\t\t/// Sample: {record.Example}");
                Console.WriteLine($"\t\t/// Description: {record.Description.Split(Environment.NewLine).First()}");
                Console.WriteLine($"\t\t/// </summary>");
                Console.WriteLine($"\t\t[LoadColumn({columnNumber++})]");
                Console.WriteLine(
                    $"\t\tpublic {TranslateTypeToCSharp(record.DataType)} {record.VariableName} {{ get; set; }}");
                Console.WriteLine("");
            }

            Console.WriteLine("\t}");
            Console.WriteLine("}");
        }

        private static string TranslateTypeToCSharp(string type)
        {
            return type switch
            {
                "binary" => "float",
                "integer" => "float",
                "numeric" => "float",
                _ => "string"
            };
        }

        private static void BuildTrainEvaluateAndSaveModel(MLContext mlContext)
        {
            // STEP 1: Common data loading configuration
            var dataView = mlContext.Data.LoadFromTextFile<Dataset>(
                "/Users/szimmerman/dev/wids/Diabetes/datasets/TrainingWiDS2021.csv", hasHeader: true,
                separatorChar: ',');

            // STEP 2: Concatenate the features and set the training algorithm
            var inputParametersOriginal = new[]
            {
                "bmi",
                "age",
                "gender_encoded",
                "ethnicity_encoded",
                "d1_glucose_min",
                "d1_bun_max",
                "d1_hemaglobin_min",
                "d1_sysbp_max",
                "h1_glucose_max",
                "h1_diasbp_min",
                "apache_2_diagnosis",
                "apache_3j_diagnosis",
                "glucose_apache",
                "heart_rate_apache",
                "d1_creatinine_max"
            };
            var inputParametersExtended = new[]
            {
                "d1_glucose_max", "glucose_apache", "h1_glucose_max", "h1_glucose_min", "weight", "d1_glucose_min",
                "d1_bun_max", "apache_2_diagnosis", "d1_bun_min", "bun_apache", "age", "d1_sysbp_max",
                "d1_sysbp_noninvasive_max", "bmi", "h1_sysbp_max", "h1_sysbp_min", "h1_sysbp_noninvasive_max",
                "d1_sysbp_min", "h1_sysbp_invasive_max", "d1_sysbp_noninvasive_min", "h1_sysbp_noninvasive_min",
                "h1_sysbp_invasive_min", "d1_sysbp_invasive_max", "d1_mbp_max", "d1_platelets_min", "height",
                "h1_spo2_max", "h1_spo2_min", "h1_bun_min", "h1_bun_max", "h1_mbp_invasive_max", "h1_pao2fio2ratio_max",
                "d1_sysbp_invasive_min", "d1_mbp_noninvasive_max", "d1_spo2_min", "d1_creatinine_max",
                "d1_creatinine_min", "creatinine_apache", "h1_arterial_pco2_max", "h1_pao2fio2ratio_min",
                "h1_arterial_pco2_min", "hospital_id", "icu_id"
            };
            var inputParameters = inputParametersOriginal.Union(inputParametersExtended).Distinct().ToArray();

            var dataProcessPipeline =
                mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "ethnicity_encoded", "ethnicity")
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "gender_encoded",
                        "gender"))
                    .Append(mlContext.Transforms.Concatenate("Features", inputParameters))
                    .Append(mlContext.Transforms.ReplaceMissingValues("Features",
                        replacementMode: MissingValueReplacingEstimator.ReplacementMode.Mean));

            // STEP 3. Create transformer using the data pre-processing estimator
            ITransformer dataPrepTransformer = dataProcessPipeline.Fit(dataView);

            // STEP 4. Pre-process the training data
            var preprocessedTrainData = dataPrepTransformer.Transform(dataView);

            // STEP 5: Set the training algorithm, then create and config the modelBuilder                            
            var trainer =
                mlContext.BinaryClassification.Trainers.FastTree(labelColumnName: "diabetes_mellitus",
                    featureColumnName: "Features");

            // STEP 6: Train the model fitting to the DataSet
            var trainedModel = trainer.Fit(preprocessedTrainData);

            var dataToPredict = mlContext.Data.LoadFromTextFile<Dataset>(
                "/Users/szimmerman/dev/wids/Diabetes/datasets/UnlabeledWiDS2021.csv", hasHeader: true,
                separatorChar: ',');

            var preprocessedFinalData = dataPrepTransformer.Transform(dataToPredict);

            var predictedData = mlContext.Data
                .CreateEnumerable<Prediction>(trainedModel.Transform(preprocessedFinalData), false).ToList();

            using var file =
                new System.IO.StreamWriter(
                    @$"/Users/szimmerman/dev/wids/Diabetes/datasets/Prediction{DateTime.Now:yyyyMMddHHmmss}.csv");
            file.WriteLine("encounter_id,diabetes_mellitus");
            foreach (var prediction in predictedData)
            {
                file.WriteLine($"{prediction.encounter_id},{prediction.Probability}");
            }
        }
    }
}