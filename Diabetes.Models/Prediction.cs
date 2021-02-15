using Microsoft.ML.Data;

namespace Diabetes.Models
{
    public class Prediction : Dataset
    {
        public bool PredictedLabel { get; set; }

        public float Score { get; set; }

        public float Probability { get; set; }
    }
}
