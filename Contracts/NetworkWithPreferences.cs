using System.Collections.Generic;

namespace backend_learning_algorithm.Contracts
{
    public class NetworkWithPreferences
    {
        public Network Network { get; set; }

        public List<Relationship> SinglePreferences { get; set; }

        public List<PreferenceOrderByPair> ConditionalPreferences { get; set; }

        public NetworkWithPreferences() { }

    }
}