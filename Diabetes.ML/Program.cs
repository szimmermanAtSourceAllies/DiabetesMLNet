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
            var inputParametersSecondary = new[]
            {
                "d1_glucose_max", "glucose_apache", "h1_glucose_max", "h1_glucose_min", "weight", "d1_glucose_min",
                "d1_bun_max", "apache_2_diagnosis", "d1_bun_min", "bun_apache", "age", "d1_sysbp_max",
                "d1_sysbp_noninvasive_max", "bmi", "h1_sysbp_max", "h1_sysbp_min", "h1_sysbp_noninvasive_max",
                "d1_sysbp_min", "h1_sysbp_invasive_max", "d1_sysbp_noninvasive_min", "h1_sysbp_noninvasive_min",
                "h1_sysbp_invasive_min", "d1_sysbp_invasive_max", "d1_mbp_max", "d1_platelets_min", "height",
                "h1_spo2_max", "h1_spo2_min", "h1_bun_min", "h1_bun_max", "h1_mbp_invasive_max", "h1_pao2fio2ratio_max",
                "d1_sysbp_invasive_min", "d1_mbp_noninvasive_max", "d1_spo2_min", "d1_creatinine_max",
                "d1_creatinine_min", "creatinine_apache", "h1_arterial_pco2_max", "h1_pao2fio2ratio_min",
                "h1_arterial_pco2_min"
            };
            var x = inputParametersOriginal.Except(inputParametersSecondary).ToArray();
            var inputParameters = inputParametersOriginal.Union(inputParametersSecondary).Distinct().ToArray();



            var trainTestSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.8);
            var trainingData = trainTestSplit.TrainSet;
            var testData = trainTestSplit.TestSet;

            var dataProcessPipeline =
                mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "ethnicity_encoded", "ethnicity")
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "gender_encoded",
                        "gender"))
                    .Append(mlContext.Transforms.Concatenate("Features", inputParameters))
                    .Append(mlContext.Transforms.ReplaceMissingValues("Features",
                        replacementMode: MissingValueReplacingEstimator.ReplacementMode.Mean));

            // STEP 3. Create transformer using the data pre-processing estimator
            ITransformer dataPrepTransformer = dataProcessPipeline.Fit(trainingData);

            // STEP 4. Pre-process the training data
            var preprocessedTrainData = dataPrepTransformer.Transform(trainingData);

            // STEP 5: Set the training algorithm, then create and config the modelBuilder                            
            var trainer =
                mlContext.BinaryClassification.Trainers.FastTree(labelColumnName: "diabetes_mellitus",
                    featureColumnName: "Features");

            // STEP 6: Train the model fitting to the DataSet
            var trainedModel = trainer.Fit(preprocessedTrainData);

            // STEP 8: Evaluate the model and show accuracy stats
            Console.WriteLine("===== Evaluating Model's accuracy with Test data =====");
            var preprocessedTestData = dataPrepTransformer.Transform(testData);
            var predictions = trainedModel.Transform(preprocessedTestData);

            var metrics = mlContext.BinaryClassification.Evaluate(data: predictions,
                labelColumnName: "diabetes_mellitus",
                scoreColumnName: "Score");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"************************************************************");
            Console.WriteLine($"*       Metrics for {trainedModel.ToString()} binary classification model      ");
            Console.WriteLine($"*-----------------------------------------------------------");
            Console.WriteLine($"*       Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"*       Area Under Roc Curve:      {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"*       Area Under PrecisionRecall Curve:  {metrics.AreaUnderPrecisionRecallCurve:P2}");
            Console.WriteLine($"*       F1Score:  {metrics.F1Score:P2}");
            Console.WriteLine($"*       LogLoss:  {metrics.LogLoss:#.##}");
            Console.WriteLine($"*       LogLossReduction:  {metrics.LogLossReduction:#.##}");
            Console.WriteLine($"*       PositivePrecision:  {metrics.PositivePrecision:#.##}");
            Console.WriteLine($"*       PositiveRecall:  {metrics.PositiveRecall:#.##}");
            Console.WriteLine($"*       NegativePrecision:  {metrics.NegativePrecision:#.##}");
            Console.WriteLine($"*       NegativeRecall:  {metrics.NegativeRecall:P2}");
            Console.WriteLine($"************************************************************");

            var dataToPredict = mlContext.Data.LoadFromTextFile<Dataset>(
                "/Users/szimmerman/dev/wids/Diabetes/datasets/UnlabeledWiDS2021.csv", hasHeader: true,
                separatorChar: ',');

            var preprocessedFinalData = dataPrepTransformer.Transform(dataToPredict);

            var predictedData = mlContext.Data
                .CreateEnumerable<Prediction>(trainedModel.Transform(preprocessedFinalData), false).ToList();

            using (var file =
                new System.IO.StreamWriter(
                    @$"/Users/szimmerman/dev/wids/Diabetes/datasets/Prediction{DateTime.Now:yyyyMMddHHmmss}.csv"))
            {
                file.WriteLine("encounter_id,diabetes_mellitus");
                foreach (var prediction in predictedData)
                {
                    file.WriteLine($"{prediction.encounter_id},{prediction.Probability}");
                }
            }
        }

        private static Dictionary<string, List<float>> GetInputParams()
        {
            var dictionary = new Dictionary<string, List<float>>
            {
                {"age", new List<float> {118, 19, 188}},
                {"apache_2_diagnosis", new List<float> {118, 19, 188}},
                {"bmi", new List<float> {19, 118, 188}},
                {"bun_apache", new List<float> {118, 19, 86}},
                {"creatinine_apache", new List<float> {118, 19, 86}},
                {"d1_bun_max", new List<float> {19, 118, 86}},
                {"d1_bun_min", new List<float> {19, 118, 86}},
                {"d1_creatinine_max", new List<float> {118, 19, 86}},
                {"d1_creatinine_min", new List<float> {118, 19, 86}},
                {"d1_glucose_min", new List<float> {118, 19, 86}},
                {"d1_mbp_max", new List<float> {118, 19, 188}},
                {"d1_mbp_noninvasive_max", new List<float> {19, 118, 188}},
                {"d1_platelets_min", new List<float> {118, 19, 86}},
                {"d1_spo2_min", new List<float> {118, 19, 188}},
                {"d1_sysbp_max", new List<float> {118, 19, 188}},
                {"d1_sysbp_min", new List<float> {118, 19, 188}},
                {"d1_sysbp_noninvasive_max", new List<float> {118, 19, 188}},
                {"d1_sysbp_noninvasive_min", new List<float> {118, 19, 188}},
                {"glucose_apache", new List<float> {118, 19, 86}},
                {"h1_glucose_max", new List<float> {86}},
                {"h1_glucose_min", new List<float> {86}},
                {"h1_mbp_invasive_max", new List<float> {165}},
                {"h1_spo2_max", new List<float> {118, 19, 188}},
                {"h1_spo2_min", new List<float> {118, 19, 188}},
                {"h1_sysbp_invasive_max", new List<float> {165}},
                {"h1_sysbp_invasive_min", new List<float> {165}},
                {"h1_sysbp_max", new List<float> {118, 19, 188}},
                {"h1_sysbp_min", new List<float> {118, 19, 188}},
                {"h1_sysbp_noninvasive_max", new List<float> {118, 19, 188}},
                {"h1_sysbp_noninvasive_min", new List<float> {118, 19, 188}},
                {"height", new List<float> {118, 19, 188}},
                {"weight", new List<float> {19, 118, 188}}
            };
            return dictionary;
        }

        private static void OutputHospitalDataStats(string[] inputParameters, IDataView dataView, MLContext mlContext)
        {
            // which hospitals have the most readings
            var records = mlContext.Data.CreateEnumerable<Dataset>(dataView, false).ToList();
            var hospitalDiabetes = new Dictionary<float, Dictionary<string, List<float>>>();

            var totalRecordsByHospital = new Dictionary<float, int>
            {
                {118, 0},
                {19, 0},
                {188, 0},
                {86, 0},
                {161, 0},
                {175, 0},
                {165, 0},
                {100, 0},
                {7, 0}
            };
            foreach (var record in records)
            {
                if (totalRecordsByHospital.ContainsKey(record.hospital_id))
                    totalRecordsByHospital[record.hospital_id]++;
                if (!hospitalDiabetes.ContainsKey(record.hospital_id))
                {
                    var inputDictionary = new Dictionary<string, List<float>>();
                    foreach (var inputParameter in inputParameters)
                    {
                        inputDictionary.Add(inputParameter, new List<float>());
                    }

                    hospitalDiabetes.Add(record.hospital_id, inputDictionary);
                }

                hospitalDiabetes[record.hospital_id]["glucose_apache"].Add(record.glucose_apache);
                hospitalDiabetes[record.hospital_id]["h1_glucose_max"].Add(record.h1_glucose_max);
                hospitalDiabetes[record.hospital_id]["h1_glucose_min"].Add(record.h1_glucose_min);
                hospitalDiabetes[record.hospital_id]["weight"].Add(record.weight);
                hospitalDiabetes[record.hospital_id]["d1_glucose_min"].Add(record.d1_glucose_min);
                hospitalDiabetes[record.hospital_id]["d1_bun_max"].Add(record.d1_bun_max);
                hospitalDiabetes[record.hospital_id]["apache_2_diagnosis"].Add(record.apache_2_diagnosis);
                hospitalDiabetes[record.hospital_id]["d1_bun_min"].Add(record.d1_bun_min);
                hospitalDiabetes[record.hospital_id]["bun_apache"].Add(record.bun_apache);
                hospitalDiabetes[record.hospital_id]["age"].Add(record.age);
                hospitalDiabetes[record.hospital_id]["d1_sysbp_max"].Add(record.d1_sysbp_max);
                hospitalDiabetes[record.hospital_id]["d1_sysbp_noninvasive_max"].Add(record.d1_sysbp_noninvasive_max);
                hospitalDiabetes[record.hospital_id]["bmi"].Add(record.bmi);
                hospitalDiabetes[record.hospital_id]["h1_sysbp_max"].Add(record.h1_sysbp_max);
                hospitalDiabetes[record.hospital_id]["h1_sysbp_min"].Add(record.h1_sysbp_min);
                hospitalDiabetes[record.hospital_id]["h1_sysbp_noninvasive_max"].Add(record.h1_sysbp_noninvasive_max);
                hospitalDiabetes[record.hospital_id]["d1_sysbp_min"].Add(record.d1_sysbp_min);
                hospitalDiabetes[record.hospital_id]["h1_sysbp_invasive_max"].Add(record.h1_sysbp_invasive_max);
                hospitalDiabetes[record.hospital_id]["d1_sysbp_noninvasive_min"].Add(record.d1_sysbp_noninvasive_min);
                hospitalDiabetes[record.hospital_id]["h1_sysbp_noninvasive_min"].Add(record.h1_sysbp_noninvasive_min);
                hospitalDiabetes[record.hospital_id]["h1_sysbp_invasive_min"].Add(record.h1_sysbp_invasive_min);
                hospitalDiabetes[record.hospital_id]["d1_mbp_max"].Add(record.d1_mbp_max);
                hospitalDiabetes[record.hospital_id]["d1_platelets_min"].Add(record.d1_platelets_min);
                hospitalDiabetes[record.hospital_id]["height"].Add(record.height);
                hospitalDiabetes[record.hospital_id]["h1_spo2_max"].Add(record.h1_spo2_max);
                hospitalDiabetes[record.hospital_id]["h1_spo2_min"].Add(record.h1_spo2_min);
                hospitalDiabetes[record.hospital_id]["h1_mbp_invasive_max"].Add(record.h1_mbp_invasive_max);
                hospitalDiabetes[record.hospital_id]["d1_mbp_noninvasive_max"].Add(record.d1_mbp_noninvasive_max);
                hospitalDiabetes[record.hospital_id]["d1_spo2_min"].Add(record.d1_spo2_min);
                hospitalDiabetes[record.hospital_id]["d1_creatinine_max"].Add(record.d1_creatinine_max);
                hospitalDiabetes[record.hospital_id]["d1_creatinine_min"].Add(record.d1_creatinine_min);
                hospitalDiabetes[record.hospital_id]["creatinine_apache"].Add(record.creatinine_apache);
            }

            foreach (var hospital in totalRecordsByHospital)
            {
                Console.WriteLine($"{hospital.Key}|{hospital.Value}");
            }

            // which hospitals have the most readings
            Console.WriteLine(
                "Parameter, HospitalId, Count, Percent, HospitalId, Count, Percent, HospitalId, Count, Percent");

            var topHospitalSum = new Dictionary<float, int>();

            var topHospitalCount = new Dictionary<float, int>();
            foreach (var inputParameter in inputParameters)
            {
                var hospitalDiabetesSummary = hospitalDiabetes.Keys.ToDictionary(hospitalId => hospitalId,
                    hospitalId => hospitalDiabetes[hospitalId][inputParameter].Count(r => !float.IsNaN(r)));
                var sortedDict = (
                        from entry
                            in hospitalDiabetesSummary
                        orderby entry.Value descending
                        select entry)
                    .Take(3)
                    .ToArray();

                for (var i = 0; i <= 2; ++i)
                {
                    if (!topHospitalSum.ContainsKey(sortedDict[i].Key))
                    {
                        topHospitalSum.Add(sortedDict[i].Key, 0);
                        topHospitalCount.Add(sortedDict[i].Key, 0);
                    }

                    topHospitalSum[sortedDict[i].Key] += sortedDict[i].Value;
                    topHospitalCount[sortedDict[i].Key]++;
                }

                var firstPercentage = sortedDict[0].Value * 1.0 / totalRecordsByHospital[sortedDict[0].Key];
                var secondPercentage = sortedDict[1].Value * 1.0 / totalRecordsByHospital[sortedDict[1].Key];
                var thirdPercentage = sortedDict[2].Value * 1.0 / totalRecordsByHospital[sortedDict[2].Key];
                Console.WriteLine(
                    $@"{inputParameter},{sortedDict[0].Key},{sortedDict[0].Value},{firstPercentage},{sortedDict[1].Key},{sortedDict[1].Value},{secondPercentage},{sortedDict[2].Key},{sortedDict[2].Value},{thirdPercentage}");
            }
        }

        private static Dictionary<string, float> CalculateMeans(
            IReadOnlyDictionary<string, List<float>> inputParameters, IDataView dataView, MLContext mlContext)
        {
            // which hospitals have the most readings
            var records = mlContext.Data.CreateEnumerable<Dataset>(dataView, false).ToList();

            var featureDictionary = inputParameters.ToDictionary(inputParameter => inputParameter.Key,
                inputParameter => new List<float>());
            foreach (var record in records)
            {
                foreach (var (key, value) in inputParameters)
                {
                    var featureValue = key switch
                    {
                        "age" => record.age,
                        "apache_2_diagnosis" => record.apache_2_diagnosis,
                        "bmi" => record.bmi,
                        "bun_apache" => record.bun_apache,
                        "creatinine_apache" => record.creatinine_apache,
                        "d1_bun_max" => record.d1_bun_max,
                        "d1_bun_min" => record.d1_bun_min,
                        "d1_creatinine_max" => record.d1_creatinine_max,
                        "d1_creatinine_min" => record.d1_creatinine_min,
                        "d1_glucose_min" => record.d1_glucose_min,
                        "d1_mbp_max" => record.d1_mbp_max,
                        "d1_mbp_noninvasive_max" => record.d1_mbp_noninvasive_max,
                        "d1_platelets_min" => record.d1_platelets_min,
                        "d1_spo2_min" => record.d1_spo2_min,
                        "d1_sysbp_max" => record.d1_sysbp_max,
                        "d1_sysbp_min" => record.d1_sysbp_min,
                        "d1_sysbp_noninvasive_max" => record.d1_sysbp_noninvasive_max,
                        "d1_sysbp_noninvasive_min" => record.d1_sysbp_noninvasive_min,
                        "glucose_apache" => record.glucose_apache,
                        "h1_glucose_max" => record.h1_glucose_max,
                        "h1_glucose_min" => record.h1_glucose_min,
                        "h1_mbp_invasive_max" => record.h1_mbp_invasive_max,
                        "h1_spo2_max" => record.h1_spo2_max,
                        "h1_spo2_min" => record.h1_spo2_min,
                        "h1_sysbp_invasive_max" => record.h1_sysbp_invasive_max,
                        "h1_sysbp_invasive_min" => record.h1_sysbp_invasive_min,
                        "h1_sysbp_max" => record.h1_sysbp_max,
                        "h1_sysbp_min" => record.h1_sysbp_min,
                        "h1_sysbp_noninvasive_max" => record.h1_sysbp_noninvasive_max,
                        "h1_sysbp_noninvasive_min" => record.h1_sysbp_noninvasive_min,
                        "height" => record.height,
                        "weight" => record.weight,
                        _ => 0f
                    };

                    if (value.Contains(record.hospital_id))
                        featureDictionary[key].Add(featureValue);
                }
            }

            return featureDictionary.ToDictionary(
                d => d.Key,
                d => d.Value.Where(x => !float.IsNaN(x)).Average());
        }
    }
}