using System.Collections.Generic;
using backend_learning_algorithm.Contracts;
namespace backend_learning_algorithm.Common
{
    public class NetworkSolver
    {
        public static Network solver(Network network)
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
                        var pcNetwork = BooleanAlgebra.PathConsistency(new Network
                        {
                            Variables = currentNetwork.Variables,
                            NetworkRelations = currentNetwork.NetworkRelations
                        });
                        currentNetwork = orderedNetwork(currentNetwork, pcNetwork);
                        break;
                    }
                }
            }
            return currentNetwork;
        }

        public static Network orderedNetwork(Network network, Network pcNetwork)
        {
            var orderedNetworkPC = new Network();
            for (var i = 0; i < network.NetworkRelations.Count; i++)
            {
                for (var j = 0; j < pcNetwork.NetworkRelations.Count; j++)
                {
                    if (network.NetworkRelations[i].FirstVar == pcNetwork.NetworkRelations[j].FirstVar &&
                    network.NetworkRelations[i].SecondVar == pcNetwork.NetworkRelations[j].SecondVar)
                    {
                        var newRel = new Relationship();
                        newRel.FirstVar = network.NetworkRelations[i].FirstVar;
                        newRel.SecondVar = network.NetworkRelations[i].SecondVar;
                        newRel.Relations = orderedRelations(network.NetworkRelations[i].Relations,
                                                            pcNetwork.NetworkRelations[j].Relations);
                        orderedNetworkPC.NetworkRelations.Add(newRel);
                        break;
                    }
                }
            }

            return orderedNetworkPC;
        }

        public static List<string> orderedRelations(List<string> netRels, List<string> pcNetRels)
        {
            var relations = new List<string>();
            for (var i = 0; i < netRels.Count; i++)
            {
                for (var j = 0; j < pcNetRels.Count; j++)
                {
                    if (netRels[i] == pcNetRels[j])
                    {
                        relations.Add(netRels[i]);
                        break;
                    }
                }
            }
            return relations;
        }
    }
}