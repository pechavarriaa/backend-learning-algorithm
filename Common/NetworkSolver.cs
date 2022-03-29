using backend_learning_algorithm.Contracts;
namespace backend_learning_algorithm.Common
{
    public class NetworkSolver
    {
        public static Network Backtracking(Network network)
        {
            var networkIsSolved = false;
            var currentNetwork = network;
            while (!networkIsSolved)
            {
                networkIsSolved = true;
                for (var i = 0; i < currentNetwork.NetworkRelations.Count; i++)
                {
                    if (currentNetwork.NetworkRelations[i].Relations.Count > 1)
                    {
                        networkIsSolved = false;
                        currentNetwork.NetworkRelations[i].Relations = currentNetwork.NetworkRelations[i].Relations.GetRange(0, 1);
                        currentNetwork = BooleanAlgebra.PathConsistency(currentNetwork);
                        break;
                    }
                }
            }
            return currentNetwork;
        }
    }
}