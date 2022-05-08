using System;
using System.Collections.Generic;
using System.Linq;
using backend_learning_algorithm.Contracts;
using BAR = backend_learning_algorithm.Common.BooleanAlgebraRelations;

namespace backend_learning_algorithm.Common
{
    public class NetworkWithPreferencesSolver
    {

        public static Network DFSOfConditionalPreferences(List<PreferenceOrderByPair> ConditionalPreferences, Network network, Relationship relationship, string relation)
        {
            foreach (var preferenceOrder in ConditionalPreferences)
            {
                if (preferenceOrder.PreferenceVariables.firstVar == relationship.FirstVar &&
                    preferenceOrder.PreferenceVariables.secondVar == relationship.SecondVar)
                {
                    var networkPair = network.NetworkRelations
                    .Where(rel => preferenceOrder.PreferenceVariables.thirdVar == rel.FirstVar
                            && preferenceOrder.PreferenceVariables.fourthVar == rel.SecondVar)
                    .First();
                    var inversePair = network.NetworkRelations
                     .Where(rel => preferenceOrder.PreferenceVariables.thirdVar == rel.SecondVar
                            && preferenceOrder.PreferenceVariables.fourthVar == rel.FirstVar)
                    .First();

                    var preferredRelation = firstMatch(preferenceOrder.PreferenceOrder[relation], networkPair.Relations);
                    var inverseRelation = BooleanAlgebra.GetInverseRelation(Enum.Parse<BAR>(preferredRelation)).ToString();
                    networkPair.Relations = new List<string>() { preferredRelation };
                    inversePair.Relations = new List<string>() { inverseRelation };

                    network = BooleanAlgebra.PathConsistency(network);
                    var newRelationship = new Relationship(preferenceOrder.PreferenceVariables.thirdVar, preferenceOrder.PreferenceVariables.fourthVar, preferenceOrder.PreferenceOrder[relation]);
                    network = DFSOfConditionalPreferences(ConditionalPreferences, network, newRelationship, preferredRelation);
                }
            }

            return network;
        }

        public static Network solver(NetworkWithPreferences networkWithPreferences)
        {
            var network = networkWithPreferences.Network;
            foreach (var singlePreference in networkWithPreferences.SinglePreferences)
            {
                var networkPair = network.NetworkRelations
                .Where(rel => singlePreference.FirstVar == rel.FirstVar
                        && singlePreference.SecondVar == rel.SecondVar)
                .First();
                var inversePair = network.NetworkRelations
                .Where(rel => singlePreference.FirstVar == rel.SecondVar
                        && singlePreference.SecondVar == rel.FirstVar)
                .First();
                var preferredRelation = firstMatch(singlePreference.Relations, networkPair.Relations);
                var inverseRelation = BooleanAlgebra.GetInverseRelation(Enum.Parse<BAR>(preferredRelation)).ToString();

                networkPair.Relations = new List<string>() { preferredRelation };
                inversePair.Relations = new List<string>() { inverseRelation };

                network = BooleanAlgebra.PathConsistency(network);
                network = DFSOfConditionalPreferences(networkWithPreferences.ConditionalPreferences, network, singlePreference, preferredRelation);
            }
            return network;
        }

        public static string firstMatch(List<string> preferredOrder, List<string> relationItems)
        {
            for (var x = 0; x < preferredOrder.Count; x++)
            {
                if (relationItems.Contains(preferredOrder[x]))
                    return preferredOrder[x];
            }
            return relationItems.First();
        }
    }
}