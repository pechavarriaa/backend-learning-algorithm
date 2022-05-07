using System.Collections.Generic;

namespace backend_learning_algorithm.Contracts
{
    public class PreferenceOrderByPair
    {
        public PreferenceVariables PreferenceVariables { get; set; }
        public Dictionary<string, List<string>> PreferenceOrder { get; set; }
    }

    public class PreferenceVariables
    {
        public string firstVar { get; set; }
        public string secondVar { get; set; }
        public string thirdVar { get; set; }
        public string fourthVar { get; set; }
    }
}