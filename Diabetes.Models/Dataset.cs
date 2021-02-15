using Microsoft.ML.Data;

namespace Diabetes.Models
{
        public class Dataset
        {
                /// <summary>
                /// Category: identifier
                /// UOM: None
                /// Sample: None
                /// Description: Unique identifier associated with a patient unit stay
                /// </summary>
                [LoadColumn(0)]
                public float record_id { get; set; }

                /// <summary>
                /// Category: identifier
                /// UOM: None
                /// Sample: None
                /// Description: Unique identifier associated with a patient unit stay
                /// </summary>
                [LoadColumn(1)]
                public float encounter_id { get; set; }

                /// <summary>
                /// Category: identifier
                /// UOM: None
                /// Sample: None
                /// Description: Unique identifier associated with a hospital
                /// </summary>
                [LoadColumn(2)]
                public float hospital_id { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: Years
                /// Sample: None
                /// Description: The age of the patient on unit admission
                /// </summary>
                [LoadColumn(3)]
                public float age { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: kilograms/metres^2
                /// Sample: 21.5
                /// Description: The body mass index of the person on unit admission
                /// </summary>
                [LoadColumn(4)]
                public float bmi { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: None
                /// Sample: 0
                /// Description: Whether the patient was admitted to the hospital for an elective surgical operation
                /// </summary>
                [LoadColumn(5)]
                public float elective_surgery { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: None
                /// Sample: Caucasian
                /// Description: The common national or cultural tradition which the person belongs to
                /// </summary>
                [LoadColumn(6)]
                public string ethnicity { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: None
                /// Sample: F
                /// Description: The genotypical sex of the patient
                /// </summary>
                [LoadColumn(7)]
                public string gender { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: centimetres
                /// Sample: 180
                /// Description: The height of the person on unit admission
                /// </summary>
                [LoadColumn(8)]
                public float height { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: None
                /// Sample: Home
                /// Description: The location of the patient prior to being admitted to the hospital
                /// </summary>
                [LoadColumn(9)]
                public string hospital_admit_source { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: None
                /// Sample: Operating room
                /// Description: The location of the patient prior to being admitted to the unit
                /// </summary>
                [LoadColumn(10)]
                public string icu_admit_source { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: None
                /// Sample: None
                /// Description: A unique identifier for the unit to which the patient was admitted
                /// </summary>
                [LoadColumn(11)]
                public float icu_id { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: None
                /// Sample: None
                /// Description: 
                /// </summary>
                [LoadColumn(12)]
                public string icu_stay_type { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: None
                /// Sample: Neurological ICU
                /// Description: A classification which indicates the type of care the unit is capable of providing
                /// </summary>
                [LoadColumn(13)]
                public string icu_type { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: Days
                /// Sample: 3.5
                /// Description: The length of stay of the patient between hospital admission and unit admission
                /// </summary>
                [LoadColumn(14)]
                public float pre_icu_los_days { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: None
                /// Sample: 0
                /// Description: Whether the current unit stay is the second (or greater) stay at an ICU within the same hospitalization
                /// </summary>
                [LoadColumn(15)]
                public float readmission_status { get; set; }

                /// <summary>
                /// Category: demographic
                /// UOM: kilograms
                /// Sample: 80
                /// Description: The weight (body mass) of the person on unit admission
                /// </summary>
                [LoadColumn(16)]
                public float weight { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: g/L
                /// Sample: 30
                /// Description: The albumin concentration measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(17)]
                public float albumin_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: None
                /// Sample: 308
                /// Description: The APACHE II diagnosis for the ICU admission
                /// </summary>
                [LoadColumn(18)]
                public float apache_2_diagnosis { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: None
                /// Sample: 1405
                /// Description: The APACHE III-J sub-diagnosis code which best describes the reason for the ICU admission
                /// </summary>
                [LoadColumn(19)]
                public float apache_3j_diagnosis { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: None
                /// Sample: 1
                /// Description: The APACHE operative status; 1 for post-operative, 0 for non-operative
                /// </summary>
                [LoadColumn(20)]
                public float apache_post_operative { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: None
                /// Sample: 0
                /// Description: Whether the patient had acute renal failure during the first 24 hours of their unit stay, defined as a 24 hour urine output <410ml, creatinine >=133 micromol/L and no chronic dialysis
                /// </summary>
                [LoadColumn(21)]
                public float arf_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: micromol/L
                /// Sample: 20
                /// Description: The bilirubin concentration measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(22)]
                public float bilirubin_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: mmol/L
                /// Sample: None
                /// Description: The blood urea nitrogen concentration measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(23)]
                public float bun_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: micromol/L
                /// Sample: 70
                /// Description: The creatinine concentration measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(24)]
                public float creatinine_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: Fraction
                /// Sample: 0.21
                /// Description: The fraction of inspired oxygen from the arterial blood gas taken during the first 24 hours of unit admission which produces the highest APACHE III score for oxygenation
                /// </summary>
                [LoadColumn(25)]
                public float fio2_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: None
                /// Sample: 4
                /// Description: The eye opening component of the Glasgow Coma Scale measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(26)]
                public float gcs_eyes_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: None
                /// Sample: 6
                /// Description: The motor component of the Glasgow Coma Scale measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(27)]
                public float gcs_motor_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: None
                /// Sample: 1
                /// Description: Whether the Glasgow Coma Scale was unable to be assessed due to patient sedation
                /// </summary>
                [LoadColumn(28)]
                public float gcs_unable_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: None
                /// Sample: 5
                /// Description: The verbal component of the Glasgow Coma Scale measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(29)]
                public float gcs_verbal_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: mmol/L
                /// Sample: 5
                /// Description: The glucose concentration measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(30)]
                public float glucose_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: Beats per minute
                /// Sample: 75
                /// Description: The heart rate measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(31)]
                public float heart_rate_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: Fraction
                /// Sample: 0.4
                /// Description: The hematocrit measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(32)]
                public float hematocrit_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: None
                /// Sample: 0
                /// Description: Whether the patient was intubated at the time of the highest scoring arterial blood gas used in the oxygenation score
                /// </summary>
                [LoadColumn(33)]
                public float intubated_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: Millimetres of mercury
                /// Sample: None
                /// Description: The mean arterial pressure measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(34)]
                public float map_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: Millimetres of mercury
                /// Sample: 40
                /// Description: The partial pressure of carbon dioxide from the arterial blood gas taken during the first 24 hours of unit admission which produces the highest APACHE III score for oxygenation
                /// </summary>
                [LoadColumn(35)]
                public float paco2_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: Millimetres of mercury
                /// Sample: 40
                /// Description: The partial pressure of carbon dioxide from the arterial blood gas taken during the first 24 hours of unit admission which produces the highest APACHE III score for acid-base disturbance
                /// </summary>
                [LoadColumn(36)]
                public float paco2_for_ph_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The partial pressure of oxygen from the arterial blood gas taken during the first 24 hours of unit admission which produces the highest APACHE III score for oxygenation
                /// </summary>
                [LoadColumn(37)]
                public float pao2_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: None
                /// Sample: 7.4
                /// Description: The pH from the arterial blood gas taken during the first 24 hours of unit admission which produces the highest APACHE III score for acid-base disturbance
                /// </summary>
                [LoadColumn(38)]
                public float ph_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: Breaths per minute
                /// Sample: 14
                /// Description: The respiratory rate measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(39)]
                public float resprate_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: mmol/L
                /// Sample: 145
                /// Description: The sodium concentration measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(40)]
                public float sodium_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: Degrees Celsius
                /// Sample: 33
                /// Description: The temperature measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(41)]
                public float temp_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: Millilitres
                /// Sample: 2000
                /// Description: The total urine output for the first 24 hours
                /// </summary>
                [LoadColumn(42)]
                public float urineoutput_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: None
                /// Sample: 1
                /// Description: Whether the patient was invasively ventilated at the time of the highest scoring arterial blood gas using the oxygenation scoring algorithm, including any mode of positive pressure ventilation delivered through a circuit attached to an endo-tracheal tube or tracheostomy
                /// </summary>
                [LoadColumn(43)]
                public float ventilated_apache { get; set; }

                /// <summary>
                /// Category: APACHE covariate
                /// UOM: 10^9/L
                /// Sample: 10
                /// Description: The white blood cell count measured during the first 24 hours which results in the highest APACHE III score
                /// </summary>
                [LoadColumn(44)]
                public float wbc_apache { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 60
                /// Description: The patient's highest diastolic blood pressure during the first 24 hours of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(45)]
                public float d1_diasbp_invasive_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 60
                /// Description: The patient's lowest diastolic blood pressure during the first 24 hours of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(46)]
                public float d1_diasbp_invasive_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 60
                /// Description: The patient's highest diastolic blood pressure during the first 24 hours of their unit stay, either non-invasively or invasively measured
                /// </summary>
                [LoadColumn(47)]
                public float d1_diasbp_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 60
                /// Description: The patient's lowest diastolic blood pressure during the first 24 hours of their unit stay, either non-invasively or invasively measured
                /// </summary>
                [LoadColumn(48)]
                public float d1_diasbp_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 60
                /// Description: The patient's highest diastolic blood pressure during the first 24 hours of their unit stay, non-invasively measured
                /// </summary>
                [LoadColumn(49)]
                public float d1_diasbp_noninvasive_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 60
                /// Description: The patient's lowest diastolic blood pressure during the first 24 hours of their unit stay, non-invasively measured
                /// </summary>
                [LoadColumn(50)]
                public float d1_diasbp_noninvasive_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Beats per minute
                /// Sample: 75
                /// Description: The patient's highest heart rate during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(51)]
                public float d1_heartrate_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Beats per minute
                /// Sample: 75
                /// Description: The patient's lowest heart rate during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(52)]
                public float d1_heartrate_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The patient's highest mean blood pressure during the first 24 hours of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(53)]
                public float d1_mbp_invasive_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The patient's lowest mean blood pressure during the first 24 hours of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(54)]
                public float d1_mbp_invasive_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The patient's highest mean blood pressure during the first 24 hours of their unit stay, either non-invasively or invasively measured
                /// </summary>
                [LoadColumn(55)]
                public float d1_mbp_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The patient's lowest mean blood pressure during the first 24 hours of their unit stay, either non-invasively or invasively measured
                /// </summary>
                [LoadColumn(56)]
                public float d1_mbp_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The patient's highest mean blood pressure during the first 24 hours of their unit stay, non-invasively measured
                /// </summary>
                [LoadColumn(57)]
                public float d1_mbp_noninvasive_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The patient's lowest mean blood pressure during the first 24 hours of their unit stay, non-invasively measured
                /// </summary>
                [LoadColumn(58)]
                public float d1_mbp_noninvasive_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Breaths per minute
                /// Sample: 14
                /// Description: The patient's highest respiratory rate during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(59)]
                public float d1_resprate_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Breaths per minute
                /// Sample: 14
                /// Description: The patient's lowest respiratory rate during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(60)]
                public float d1_resprate_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Percentage
                /// Sample: None
                /// Description: The patient's highest peripheral oxygen saturation during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(61)]
                public float d1_spo2_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Percentage
                /// Sample: 100
                /// Description: The patient's lowest peripheral oxygen saturation during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(62)]
                public float d1_spo2_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 120
                /// Description: The patient's highest systolic blood pressure during the first 24 hours of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(63)]
                public float d1_sysbp_invasive_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 120
                /// Description: The patient's lowest systolic blood pressure during the first 24 hours of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(64)]
                public float d1_sysbp_invasive_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 120
                /// Description: The patient's highest systolic blood pressure during the first 24 hours of their unit stay, either non-invasively or invasively measured
                /// </summary>
                [LoadColumn(65)]
                public float d1_sysbp_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 120
                /// Description: The patient's lowest systolic blood pressure during the first 24 hours of their unit stay, either non-invasively or invasively measured
                /// </summary>
                [LoadColumn(66)]
                public float d1_sysbp_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 120
                /// Description: The patient's highest systolic blood pressure during the first 24 hours of their unit stay, non-invasively measured
                /// </summary>
                [LoadColumn(67)]
                public float d1_sysbp_noninvasive_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 120
                /// Description: The patient's lowest systolic blood pressure during the first 24 hours of their unit stay, non-invasively measured
                /// </summary>
                [LoadColumn(68)]
                public float d1_sysbp_noninvasive_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Degrees Celsius
                /// Sample: 33
                /// Description: The patient's highest core temperature during the first 24 hours of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(69)]
                public float d1_temp_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Degrees Celsius
                /// Sample: 33
                /// Description: The patient's lowest core temperature during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(70)]
                public float d1_temp_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 60
                /// Description: The patient's highest diastolic blood pressure during the first hour of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(71)]
                public float h1_diasbp_invasive_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 60
                /// Description: The patient's lowest diastolic blood pressure during the first hour of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(72)]
                public float h1_diasbp_invasive_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 60
                /// Description: The patient's highest diastolic blood pressure during the first hour of their unit stay, either non-invasively or invasively measured
                /// </summary>
                [LoadColumn(73)]
                public float h1_diasbp_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 60
                /// Description: The patient's lowest diastolic blood pressure during the first hour of their unit stay, either non-invasively or invasively measured
                /// </summary>
                [LoadColumn(74)]
                public float h1_diasbp_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 60
                /// Description: The patient's highest diastolic blood pressure during the first hour of their unit stay, non-invasively measured
                /// </summary>
                [LoadColumn(75)]
                public float h1_diasbp_noninvasive_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 60
                /// Description: The patient's lowest diastolic blood pressure during the first hour of their unit stay, non-invasively measured
                /// </summary>
                [LoadColumn(76)]
                public float h1_diasbp_noninvasive_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Beats per minute
                /// Sample: 75
                /// Description: The patient's highest heart rate during the first hour of their unit stay
                /// </summary>
                [LoadColumn(77)]
                public float h1_heartrate_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Beats per minute
                /// Sample: 75
                /// Description: The patient's lowest heart rate during the first hour of their unit stay
                /// </summary>
                [LoadColumn(78)]
                public float h1_heartrate_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The patient's highest mean blood pressure during the first hour of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(79)]
                public float h1_mbp_invasive_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The patient's lowest mean blood pressure during the first hour of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(80)]
                public float h1_mbp_invasive_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The patient's highest mean blood pressure during the first hour of their unit stay, either non-invasively or invasively measured
                /// </summary>
                [LoadColumn(81)]
                public float h1_mbp_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The patient's lowest mean blood pressure during the first hour of their unit stay, either non-invasively or invasively measured
                /// </summary>
                [LoadColumn(82)]
                public float h1_mbp_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The patient's highest mean blood pressure during the first hour of their unit stay, non-invasively measured
                /// </summary>
                [LoadColumn(83)]
                public float h1_mbp_noninvasive_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The patient's lowest mean blood pressure during the first hour of their unit stay, non-invasively measured
                /// </summary>
                [LoadColumn(84)]
                public float h1_mbp_noninvasive_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Breaths per minute
                /// Sample: 14
                /// Description: The patient's highest respiratory rate during the first hour of their unit stay
                /// </summary>
                [LoadColumn(85)]
                public float h1_resprate_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Breaths per minute
                /// Sample: 14
                /// Description: The patient's lowest respiratory rate during the first hour of their unit stay
                /// </summary>
                [LoadColumn(86)]
                public float h1_resprate_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Percentage
                /// Sample: None
                /// Description: The patient's highest peripheral oxygen saturation during the first hour of their unit stay
                /// </summary>
                [LoadColumn(87)]
                public float h1_spo2_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Percentage
                /// Sample: 100
                /// Description: The patient's lowest peripheral oxygen saturation during the first hour of their unit stay
                /// </summary>
                [LoadColumn(88)]
                public float h1_spo2_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 120
                /// Description: The patient's highest systolic blood pressure during the first hour of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(89)]
                public float h1_sysbp_invasive_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 120
                /// Description: The patient's lowest systolic blood pressure during the first hour of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(90)]
                public float h1_sysbp_invasive_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 120
                /// Description: The patient's highest systolic blood pressure during the first hour of their unit stay, either non-invasively or invasively measured
                /// </summary>
                [LoadColumn(91)]
                public float h1_sysbp_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 120
                /// Description: The patient's lowest systolic blood pressure during the first hour of their unit stay, either non-invasively or invasively measured
                /// </summary>
                [LoadColumn(92)]
                public float h1_sysbp_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 120
                /// Description: The patient's highest systolic blood pressure during the first hour of their unit stay, non-invasively measured
                /// </summary>
                [LoadColumn(93)]
                public float h1_sysbp_noninvasive_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Millimetres of mercury
                /// Sample: 120
                /// Description: The patient's lowest systolic blood pressure during the first hour of their unit stay, non-invasively measured
                /// </summary>
                [LoadColumn(94)]
                public float h1_sysbp_noninvasive_min { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Degrees Celsius
                /// Sample: 33
                /// Description: The patient's highest core temperature during the first hour of their unit stay, invasively measured
                /// </summary>
                [LoadColumn(95)]
                public float h1_temp_max { get; set; }

                /// <summary>
                /// Category: vitals
                /// UOM: Degrees Celsius
                /// Sample: 33
                /// Description: The patient's lowest core temperature during the first hour of their unit stay
                /// </summary>
                [LoadColumn(96)]
                public float h1_temp_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: None
                /// Sample: 30
                /// Description: The lowest albumin concentration of the patient in their serum during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(97)]
                public float d1_albumin_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: g/L
                /// Sample: 30
                /// Description: The lowest albumin concentration of the patient in their serum during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(98)]
                public float d1_albumin_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: micromol/L
                /// Sample: 20
                /// Description: The highest bilirubin concentration of the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(99)]
                public float d1_bilirubin_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: micromol/L
                /// Sample: 20
                /// Description: The lowest bilirubin concentration of the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(100)]
                public float d1_bilirubin_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 5
                /// Description: The highest blood urea nitrogen concentration of the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(101)]
                public float d1_bun_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 5
                /// Description: The lowest blood urea nitrogen concentration of the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(102)]
                public float d1_bun_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 2.5
                /// Description: The highest calcium concentration of the patient in their serum during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(103)]
                public float d1_calcium_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 2.5
                /// Description: The lowest calcium concentration of the patient in their serum during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(104)]
                public float d1_calcium_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: micromol/L
                /// Sample: 70
                /// Description: The highest creatinine concentration of the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(105)]
                public float d1_creatinine_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: micromol/L
                /// Sample: 70
                /// Description: The lowest creatinine concentration of the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(106)]
                public float d1_creatinine_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 5
                /// Description: The highest glucose concentration of the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(107)]
                public float d1_glucose_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 5
                /// Description: The lowest glucose concentration of the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(108)]
                public float d1_glucose_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 30
                /// Description: The highest bicarbonate concentration for the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(109)]
                public float d1_hco3_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: None
                /// Sample: 30
                /// Description: The lowest bicarbonate concentration for the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(110)]
                public float d1_hco3_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: g/dL
                /// Sample: 10
                /// Description: The highest hemoglobin concentration for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(111)]
                public float d1_hemaglobin_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: g/dL
                /// Sample: 10
                /// Description: The lowest hemoglobin concentration for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(112)]
                public float d1_hemaglobin_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: Fraction
                /// Sample: 0.4
                /// Description: The highest volume proportion of red blood cells in a patient's blood during the first 24 hours of their unit stay, expressed as a fraction
                /// </summary>
                [LoadColumn(113)]
                public float d1_hematocrit_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: Fraction
                /// Sample: 0.4
                /// Description: The lowest volume proportion of red blood cells in a patient's blood during the first 24 hours of their unit stay, expressed as a fraction
                /// </summary>
                [LoadColumn(114)]
                public float d1_hematocrit_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: micromol/L
                /// Sample: 1
                /// Description: The highest international normalized ratio for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(115)]
                public float d1_inr_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: micromol/L
                /// Sample: 1
                /// Description: The lowest international normalized ratio for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(116)]
                public float d1_inr_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 1
                /// Description: The highest lactate concentration for the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(117)]
                public float d1_lactate_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 1
                /// Description: The lowest lactate concentration for the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(118)]
                public float d1_lactate_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: 10^9/L
                /// Sample: 200
                /// Description: The highest platelet count for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(119)]
                public float d1_platelets_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: 10^9/L
                /// Sample: 200
                /// Description: The lowest platelet count for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(120)]
                public float d1_platelets_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 3.8
                /// Description: The highest potassium concentration for the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(121)]
                public float d1_potassium_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 3.8
                /// Description: The lowest potassium concentration for the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(122)]
                public float d1_potassium_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 145
                /// Description: The highest sodium concentration for the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(123)]
                public float d1_sodium_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 145
                /// Description: The lowest sodium concentration for the patient in their serum or plasma during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(124)]
                public float d1_sodium_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: 10^9/L
                /// Sample: 10
                /// Description: The highest white blood cell count for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(125)]
                public float d1_wbc_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: 10^9/L
                /// Sample: 10
                /// Description: The lowest white blood cell count for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(126)]
                public float d1_wbc_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: None
                /// Sample: 30
                /// Description: The lowest albumin concentration of the patient in their serum during the first hour of their unit stay
                /// </summary>
                [LoadColumn(127)]
                public float h1_albumin_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: g/L
                /// Sample: 30
                /// Description: The lowest albumin concentration of the patient in their serum during the first hour of their unit stay
                /// </summary>
                [LoadColumn(128)]
                public float h1_albumin_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: micromol/L
                /// Sample: 20
                /// Description: The highest bilirubin concentration of the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(129)]
                public float h1_bilirubin_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: micromol/L
                /// Sample: 20
                /// Description: The lowest bilirubin concentration of the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(130)]
                public float h1_bilirubin_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 5
                /// Description: The highest blood urea nitrogen concentration of the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(131)]
                public float h1_bun_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 5
                /// Description: The lowest blood urea nitrogen concentration of the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(132)]
                public float h1_bun_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 2.5
                /// Description: The highest calcium concentration of the patient in their serum during the first hour of their unit stay
                /// </summary>
                [LoadColumn(133)]
                public float h1_calcium_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 2.5
                /// Description: The lowest calcium concentration of the patient in their serum during the first hour of their unit stay
                /// </summary>
                [LoadColumn(134)]
                public float h1_calcium_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: micromol/L
                /// Sample: 70
                /// Description: The highest creatinine concentration of the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(135)]
                public float h1_creatinine_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: micromol/L
                /// Sample: 70
                /// Description: The lowest creatinine concentration of the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(136)]
                public float h1_creatinine_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 5
                /// Description: The highest glucose concentration of the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(137)]
                public float h1_glucose_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 5
                /// Description: The lowest glucose concentration of the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(138)]
                public float h1_glucose_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 30
                /// Description: The highest bicarbonate concentration for the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(139)]
                public float h1_hco3_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: None
                /// Sample: 30
                /// Description: The lowest bicarbonate concentration for the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(140)]
                public float h1_hco3_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: g/dL
                /// Sample: 10
                /// Description: The highest hemoglobin concentration for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(141)]
                public float h1_hemaglobin_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: g/dL
                /// Sample: 10
                /// Description: The lowest hemoglobin concentration for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(142)]
                public float h1_hemaglobin_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: Fraction
                /// Sample: 0.4
                /// Description: The highest volume proportion of red blood cells in a patient's blood during the first hour of their unit stay, expressed as a fraction
                /// </summary>
                [LoadColumn(143)]
                public float h1_hematocrit_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: Fraction
                /// Sample: 0.4
                /// Description: The lowest volume proportion of red blood cells in a patient's blood during the first hour of their unit stay, expressed as a fraction
                /// </summary>
                [LoadColumn(144)]
                public float h1_hematocrit_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: micromol/L
                /// Sample: 1
                /// Description: The highest international normalized ratio for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(145)]
                public float h1_inr_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: micromol/L
                /// Sample: 1
                /// Description: The lowest international normalized ratio for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(146)]
                public float h1_inr_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 1
                /// Description: The highest lactate concentration for the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(147)]
                public float h1_lactate_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 1
                /// Description: The lowest lactate concentration for the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(148)]
                public float h1_lactate_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: 10^9/L
                /// Sample: 200
                /// Description: The highest platelet count for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(149)]
                public float h1_platelets_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: 10^9/L
                /// Sample: 200
                /// Description: The lowest platelet count for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(150)]
                public float h1_platelets_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 3.8
                /// Description: The highest potassium concentration for the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(151)]
                public float h1_potassium_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 3.8
                /// Description: The lowest potassium concentration for the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(152)]
                public float h1_potassium_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 145
                /// Description: The highest sodium concentration for the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(153)]
                public float h1_sodium_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: mmol/L
                /// Sample: 145
                /// Description: The lowest sodium concentration for the patient in their serum or plasma during the first hour of their unit stay
                /// </summary>
                [LoadColumn(154)]
                public float h1_sodium_min { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: 10^9/L
                /// Sample: 10
                /// Description: The highest white blood cell count for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(155)]
                public float h1_wbc_max { get; set; }

                /// <summary>
                /// Category: labs
                /// UOM: 10^9/L
                /// Sample: 10
                /// Description: The lowest white blood cell count for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(156)]
                public float h1_wbc_min { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: Millimetres of mercury
                /// Sample: 40
                /// Description: The highest arterial partial pressure of carbon dioxide for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(157)]
                public float d1_arterial_pco2_max { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: Millimetres of mercury
                /// Sample: 40
                /// Description: The lowest arterial partial pressure of carbon dioxide for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(158)]
                public float d1_arterial_pco2_min { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: None
                /// Sample: 7.4
                /// Description: The highest arterial pH for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(159)]
                public float d1_arterial_ph_max { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: None
                /// Sample: 7.4
                /// Description: The lowest arterial pH for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(160)]
                public float d1_arterial_ph_min { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The highest arterial partial pressure of oxygen for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(161)]
                public float d1_arterial_po2_max { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The lowest arterial partial pressure of oxygen for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(162)]
                public float d1_arterial_po2_min { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: Fraction
                /// Sample: 0.21
                /// Description: The highest fraction of inspired oxygen for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(163)]
                public float d1_pao2fio2ratio_max { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: Fraction
                /// Sample: 0.21
                /// Description: The lowest fraction of inspired oxygen for the patient during the first 24 hours of their unit stay
                /// </summary>
                [LoadColumn(164)]
                public float d1_pao2fio2ratio_min { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: Millimetres of mercury
                /// Sample: 40
                /// Description: The highest arterial partial pressure of carbon dioxide for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(165)]
                public float h1_arterial_pco2_max { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: Millimetres of mercury
                /// Sample: 40
                /// Description: The lowest arterial partial pressure of carbon dioxide for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(166)]
                public float h1_arterial_pco2_min { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: None
                /// Sample: 7.4
                /// Description: The highest arterial pH for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(167)]
                public float h1_arterial_ph_max { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: None
                /// Sample: 7.4
                /// Description: The lowest arterial pH for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(168)]
                public float h1_arterial_ph_min { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The highest arterial partial pressure of oxygen for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(169)]
                public float h1_arterial_po2_max { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: Millimetres of mercury
                /// Sample: 80
                /// Description: The lowest arterial partial pressure of oxygen for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(170)]
                public float h1_arterial_po2_min { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: Fraction
                /// Sample: 0.21
                /// Description: The highest fraction of inspired oxygen for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(171)]
                public float h1_pao2fio2ratio_max { get; set; }

                /// <summary>
                /// Category: labs blood gas
                /// UOM: Fraction
                /// Sample: 0.21
                /// Description: The lowest fraction of inspired oxygen for the patient during the first hour of their unit stay
                /// </summary>
                [LoadColumn(172)]
                public float h1_pao2fio2ratio_min { get; set; }

                /// <summary>
                /// Category: APACHE comorbidity
                /// UOM: None
                /// Sample: 1
                /// Description: Whether the patient has a definitive diagnosis of acquired immune deficiency syndrome (AIDS) (not HIV positive alone)
                /// </summary>
                [LoadColumn(173)]
                public float aids { get; set; }

                /// <summary>
                /// Category: APACHE comorbidity
                /// UOM: None
                /// Sample: 1
                /// Description: Whether the patient has a history of heavy alcohol use with portal hypertension and varices, other causes of cirrhosis with evidence of portal hypertension and varices, or biopsy proven cirrhosis. This comorbidity does not apply to patients with a functioning liver transplant.
                /// </summary>
                [LoadColumn(174)]
                public float cirrhosis { get; set; }

                /// <summary>
                /// Category: APACHE comorbidity
                /// UOM: None
                /// Sample: 1
                /// Description: Whether the patient has cirrhosis and additional complications including jaundice and ascites, upper GI bleeding, hepatic encephalopathy, or coma.
                /// </summary>
                [LoadColumn(175)]
                public float hepatic_failure { get; set; }

                /// <summary>
                /// Category: APACHE comorbidity
                /// UOM: None
                /// Sample: 1
                /// Description: Whether the patient has their immune system suppressed within six months prior to ICU admission for any of the following reasons; radiation therapy, chemotherapy, use of non-cytotoxic immunosuppressive drugs, high dose steroids (at least 0.3 mg/kg/day of methylprednisolone or equivalent for at least 6 months).
                /// </summary>
                [LoadColumn(176)]
                public float immunosuppression { get; set; }

                /// <summary>
                /// Category: APACHE comorbidity
                /// UOM: None
                /// Sample: 1
                /// Description: Whether the patient has been diagnosed with acute or chronic myelogenous leukemia, acute or chronic lymphocytic leukemia, or multiple myeloma.
                /// </summary>
                [LoadColumn(177)]
                public float leukemia { get; set; }

                /// <summary>
                /// Category: APACHE comorbidity
                /// UOM: None
                /// Sample: 1
                /// Description: Whether the patient has been diagnosed with non-Hodgkin lymphoma.
                /// </summary>
                [LoadColumn(178)]
                public float lymphoma { get; set; }

                /// <summary>
                /// Category: APACHE comorbidity
                /// UOM: None
                /// Sample: 1
                /// Description: Whether the patient has been diagnosed with any solid tumor carcinoma (including malignant melanoma) which has evidence of metastasis.
                /// </summary>
                [LoadColumn(179)]
                public float solid_tumor_with_metastasis { get; set; }

                /// <summary>
                /// Category: Target Variable
                /// UOM: None
                /// Sample: 1
                /// Description: Whether the patient has been diagnosed with diabetes mellitus, a chronic disease.
                /// </summary>
                [LoadColumn(180)]
                public bool diabetes_mellitus { get; set; }
        }
}
