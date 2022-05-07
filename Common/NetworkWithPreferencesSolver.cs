using System;
using System.Collections.Generic;
using System.Linq;
using backend_learning_algorithm.Contracts;

namespace backend_learning_algorithm.Common
{
    public class NetworkWithPreferencesSolver
    {
        public static Network solver(NetworkWithPreferences networkWithPreferences)
        {
            return networkWithPreferences.Network;
        }

    }
}