using System;
using System.Linq;
using System.Collections.Generic;
using backend_learning_algorithm.Contracts;
using BAR = backend_learning_algorithm.Common.BooleanAlgebraRelations;

namespace backend_learning_algorithm.Common
{
    public class BooleanAlgebra
    {
        public static List<List<BAR>> TransitiveTableList = new List<List<BAR>>
        {
            // First Relation being Precedes
            new List<BAR> { BAR.Precedes, BAR.Precedes, BAR.Precedes },
            new List<BAR> { BAR.Precedes, BAR.Meets, BAR.Precedes },
            new List<BAR> { BAR.Precedes, BAR.Overlaps, BAR.Precedes },
            new List<BAR> { BAR.Precedes, BAR.Finished_by, BAR.Precedes },
            new List<BAR> { BAR.Precedes, BAR.Contains, BAR.Precedes },
            new List<BAR> { BAR.Precedes, BAR.Start, BAR.Precedes },
            new List<BAR> { BAR.Precedes, BAR.Equal, BAR.Precedes },
            new List<BAR> { BAR.Precedes, BAR.Started_by, BAR.Precedes },
            new List<BAR> { BAR.Precedes, BAR.During, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.Precedes, BAR.Finishes, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.Precedes, BAR.Overlapped_by, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.Precedes, BAR.Met_by, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.Precedes, BAR.Preceded_by, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Finished_by, BAR.Contains, BAR.Start, BAR.Equal, BAR.Started_by, BAR.During, BAR.Finishes, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            
            // First Relation being Meets
            new List<BAR> { BAR.Meets, BAR.Precedes, BAR.Precedes },
            new List<BAR> { BAR.Meets, BAR.Meets, BAR.Precedes },
            new List<BAR> { BAR.Meets, BAR.Overlaps, BAR.Precedes },
            new List<BAR> { BAR.Meets, BAR.Finished_by, BAR.Precedes },
            new List<BAR> { BAR.Meets, BAR.Contains, BAR.Precedes },
            new List<BAR> { BAR.Meets, BAR.Start, BAR.Meets },
            new List<BAR> { BAR.Meets, BAR.Equal, BAR.Meets },
            new List<BAR> { BAR.Meets, BAR.Started_by, BAR.Meets },
            new List<BAR> { BAR.Meets, BAR.During, BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.Meets, BAR.Finishes, BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.Meets, BAR.Overlapped_by, BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.Meets, BAR.Met_by, BAR.Finished_by, BAR.Equal, BAR.Finishes },
            new List<BAR> { BAR.Meets, BAR.Preceded_by, BAR.Contains, BAR.Started_by, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },

            // First Relation being Overlaps
            new List<BAR> { BAR.Overlaps, BAR.Precedes, BAR.Precedes },
            new List<BAR> { BAR.Overlaps, BAR.Meets, BAR.Precedes },
            new List<BAR> { BAR.Overlaps, BAR.Overlaps, BAR.Precedes, BAR.Meets, BAR.Overlaps },
            new List<BAR> { BAR.Overlaps, BAR.Finished_by, BAR.Precedes, BAR.Meets, BAR.Overlaps },
            new List<BAR> { BAR.Overlaps, BAR.Contains, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Finished_by, BAR.Contains },
            new List<BAR> { BAR.Overlaps, BAR.Start, BAR.Overlaps },
            new List<BAR> { BAR.Overlaps, BAR.Equal, BAR.Overlaps },
            new List<BAR> { BAR.Overlaps, BAR.Started_by, BAR.Overlaps, BAR.Finished_by, BAR.Contains},
            new List<BAR> { BAR.Overlaps, BAR.During, BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.Overlaps, BAR.Finishes, BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.Overlaps, BAR.Overlapped_by, BAR.Overlaps, BAR.Finished_by, BAR.Contains, BAR.Start, BAR.Equal, BAR.Started_by, BAR.During, BAR.Finishes, BAR.Overlapped_by },
            new List<BAR> { BAR.Overlaps, BAR.Met_by, BAR.Contains, BAR.Started_by, BAR.Overlapped_by },
            new List<BAR> { BAR.Overlaps, BAR.Preceded_by, BAR.Contains, BAR.Started_by, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },

            // First Relation being Finished_by
            new List<BAR> { BAR.Finished_by, BAR.Precedes, BAR.Precedes },
            new List<BAR> { BAR.Finished_by, BAR.Meets, BAR.Meets },
            new List<BAR> { BAR.Finished_by, BAR.Overlaps, BAR.Overlaps },
            new List<BAR> { BAR.Finished_by, BAR.Finished_by, BAR.Finished_by },
            new List<BAR> { BAR.Finished_by, BAR.Contains, BAR.Contains },
            new List<BAR> { BAR.Finished_by, BAR.Start, BAR.Overlaps },
            new List<BAR> { BAR.Finished_by, BAR.Equal, BAR.Finished_by },
            new List<BAR> { BAR.Finished_by, BAR.Started_by, BAR.Contains },
            new List<BAR> { BAR.Finished_by, BAR.During, BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.Finished_by, BAR.Finishes, BAR.Finished_by, BAR.Equal, BAR.Finishes },
            new List<BAR> { BAR.Finished_by, BAR.Overlapped_by, BAR.Contains, BAR.Started_by, BAR.Overlapped_by },
            new List<BAR> { BAR.Finished_by, BAR.Met_by, BAR.Contains, BAR.Started_by, BAR.Overlapped_by },
            new List<BAR> { BAR.Finished_by, BAR.Preceded_by, BAR.Contains, BAR.Started_by, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },

            // First Relation being Contains
            new List<BAR> { BAR.Contains, BAR.Precedes, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Finished_by, BAR.Contains },
            new List<BAR> { BAR.Contains, BAR.Meets, BAR.Overlaps, BAR.Finished_by, BAR.Contains },
            new List<BAR> { BAR.Contains, BAR.Overlaps, BAR.Overlaps, BAR.Finished_by, BAR.Contains },
            new List<BAR> { BAR.Contains, BAR.Finished_by, BAR.Contains },
            new List<BAR> { BAR.Contains, BAR.Contains, BAR.Contains },
            new List<BAR> { BAR.Contains, BAR.Start, BAR.Overlaps, BAR.Finished_by, BAR.Contains },
            new List<BAR> { BAR.Contains, BAR.Equal, BAR.Contains },
            new List<BAR> { BAR.Contains, BAR.Started_by, BAR.Contains },
            new List<BAR> { BAR.Contains, BAR.During, BAR.Overlaps, BAR.Finished_by, BAR.Contains, BAR.Start, BAR.Equal, BAR.Started_by, BAR.During, BAR.Finishes, BAR.Overlapped_by },
            new List<BAR> { BAR.Contains, BAR.Finishes, BAR.Contains, BAR.Started_by, BAR.Overlapped_by },
            new List<BAR> { BAR.Contains, BAR.Overlapped_by, BAR.Contains, BAR.Started_by, BAR.Overlapped_by },
            new List<BAR> { BAR.Contains, BAR.Met_by, BAR.Contains, BAR.Started_by, BAR.Overlapped_by },
            new List<BAR> { BAR.Contains, BAR.Preceded_by, BAR.Contains, BAR.Started_by, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },

            // First Relation being Start
            new List<BAR> { BAR.Start, BAR.Precedes, BAR.Precedes },
            new List<BAR> { BAR.Start, BAR.Meets, BAR.Precedes },
            new List<BAR> { BAR.Start, BAR.Overlaps, BAR.Precedes, BAR.Meets, BAR.Overlaps },
            new List<BAR> { BAR.Start, BAR.Finished_by, BAR.Precedes, BAR.Meets, BAR.Overlaps },
            new List<BAR> { BAR.Start, BAR.Contains, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Finished_by, BAR.Contains },
            new List<BAR> { BAR.Start, BAR.Start, BAR.Start },
            new List<BAR> { BAR.Start, BAR.Equal, BAR.Start },
            new List<BAR> { BAR.Start, BAR.Started_by, BAR.Start, BAR.Equal, BAR.Started_by },
            new List<BAR> { BAR.Start, BAR.During, BAR.During },
            new List<BAR> { BAR.Start, BAR.Finishes, BAR.During },
            new List<BAR> { BAR.Start, BAR.Overlapped_by, BAR.During, BAR.Finishes, BAR.Overlapped_by },
            new List<BAR> { BAR.Start, BAR.Met_by, BAR.Met_by },
            new List<BAR> { BAR.Start, BAR.Preceded_by, BAR.Preceded_by },

            // First Relation being Started_by
            new List<BAR> { BAR.Started_by, BAR.Precedes, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Finished_by, BAR.Contains },
            new List<BAR> { BAR.Started_by, BAR.Meets, BAR.Overlaps, BAR.Finished_by, BAR.Contains },
            new List<BAR> { BAR.Started_by, BAR.Overlaps, BAR.Overlaps, BAR.Finished_by, BAR.Contains },
            new List<BAR> { BAR.Started_by, BAR.Finished_by, BAR.Contains },
            new List<BAR> { BAR.Started_by, BAR.Contains, BAR.Contains },
            new List<BAR> { BAR.Started_by, BAR.Start, BAR.Start, BAR.Equal, BAR.Started_by },
            new List<BAR> { BAR.Started_by, BAR.Equal, BAR.Started_by },
            new List<BAR> { BAR.Started_by, BAR.Started_by, BAR.Started_by },
            new List<BAR> { BAR.Started_by, BAR.During, BAR.During, BAR.Finishes, BAR.Overlapped_by },
            new List<BAR> { BAR.Started_by, BAR.Finishes, BAR.Overlapped_by },
            new List<BAR> { BAR.Started_by, BAR.Overlapped_by, BAR.Overlapped_by },
            new List<BAR> { BAR.Started_by, BAR.Met_by, BAR.Met_by },
            new List<BAR> { BAR.Started_by, BAR.Preceded_by, BAR.Preceded_by },

            // First Relation being During
            new List<BAR> { BAR.During, BAR.Precedes, BAR.Precedes },
            new List<BAR> { BAR.During, BAR.Meets, BAR.Precedes },
            new List<BAR> { BAR.During, BAR.Overlaps, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.During, BAR.Finished_by, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.During, BAR.Contains, BAR.Preceded_by, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Finished_by, BAR.Contains, BAR.Start, BAR.Equal, BAR.Started_by, BAR.During, BAR.Finishes, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.During, BAR.Start, BAR.During },
            new List<BAR> { BAR.During, BAR.Equal, BAR.During },
            new List<BAR> { BAR.During, BAR.Started_by, BAR.During, BAR.Finishes, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.During, BAR.During, BAR.During },
            new List<BAR> { BAR.During, BAR.Finishes, BAR.During },
            new List<BAR> { BAR.During, BAR.Overlapped_by, BAR.During, BAR.Finishes, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.During, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.During, BAR.Preceded_by, BAR.Preceded_by },

            // First Relation being Finishes
            new List<BAR> { BAR.Finishes, BAR.Precedes, BAR.Precedes },
            new List<BAR> { BAR.Finishes, BAR.Meets, BAR.Meets },
            new List<BAR> { BAR.Finishes, BAR.Overlaps,  BAR.Overlaps, BAR.Start, BAR.During },
            new List<BAR> { BAR.Finishes, BAR.Finished_by, BAR.Finished_by, BAR.Equal, BAR.Finishes },
            new List<BAR> { BAR.Finishes, BAR.Contains, BAR.Contains, BAR.Started_by, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Finishes, BAR.Start, BAR.During },
            new List<BAR> { BAR.Finishes, BAR.Equal, BAR.Finishes },
            new List<BAR> { BAR.Finishes, BAR.Started_by, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Finishes, BAR.During, BAR.During },
            new List<BAR> { BAR.Finishes, BAR.Finishes, BAR.Finishes },
            new List<BAR> { BAR.Finishes, BAR.Overlapped_by, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Finishes, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Finishes, BAR.Preceded_by, BAR.Preceded_by },

            // First Relation being Overlapped_by
            new List<BAR> { BAR.Overlapped_by, BAR.Precedes, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Finished_by, BAR.Contains},
            new List<BAR> { BAR.Overlapped_by, BAR.Meets, BAR.Overlaps, BAR.Finished_by, BAR.Contains },
            new List<BAR> { BAR.Overlapped_by, BAR.Overlaps, BAR.Overlaps, BAR.Finished_by, BAR.Contains, BAR.Start, BAR.Equal, BAR.Started_by, BAR.During, BAR.Finishes, BAR.Overlapped_by },
            new List<BAR> { BAR.Overlapped_by, BAR.Finished_by, BAR.Contains, BAR.Started_by, BAR.Overlapped_by },
            new List<BAR> { BAR.Overlapped_by, BAR.Contains, BAR.Contains, BAR.Started_by, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Overlapped_by, BAR.Start, BAR.During, BAR.Finishes, BAR.Overlapped_by },
            new List<BAR> { BAR.Overlapped_by, BAR.Equal, BAR.Overlapped_by },
            new List<BAR> { BAR.Overlapped_by, BAR.Started_by, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Overlapped_by, BAR.During, BAR.During, BAR.Finishes, BAR.Overlapped_by },
            new List<BAR> { BAR.Overlapped_by, BAR.Finishes, BAR.Overlapped_by },
            new List<BAR> { BAR.Overlapped_by, BAR.Overlapped_by, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Overlapped_by, BAR.Preceded_by, BAR.Preceded_by },

            // First Relation being Met_by
            new List<BAR> { BAR.Met_by, BAR.Precedes, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Finished_by, BAR.Contains},
            new List<BAR> { BAR.Met_by, BAR.Meets, BAR.Start, BAR.Equal, BAR.Started_by },
            new List<BAR> { BAR.Met_by, BAR.Overlaps, BAR.During, BAR.Finishes, BAR.Overlapped_by },
            new List<BAR> { BAR.Met_by, BAR.Finished_by, BAR.Met_by },
            new List<BAR> { BAR.Met_by, BAR.Contains, BAR.Preceded_by },
            new List<BAR> { BAR.Met_by, BAR.Start, BAR.During, BAR.Finishes, BAR.Overlapped_by },
            new List<BAR> { BAR.Met_by, BAR.Equal, BAR.Met_by },
            new List<BAR> { BAR.Met_by, BAR.Started_by, BAR.Preceded_by },
            new List<BAR> { BAR.Met_by, BAR.During, BAR.During, BAR.Finishes, BAR.Overlapped_by },
            new List<BAR> { BAR.Met_by, BAR.Finishes, BAR.Met_by },
            new List<BAR> { BAR.Met_by, BAR.Overlapped_by, BAR.Preceded_by },
            new List<BAR> { BAR.Met_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Met_by, BAR.Preceded_by, BAR.Preceded_by },

            // First Relation being Preceded_by
            new List<BAR> { BAR.Preceded_by, BAR.Precedes, BAR.Precedes, BAR.Meets, BAR.Overlaps, BAR.Finished_by, BAR.Contains, BAR.Start, BAR.Equal, BAR.Started_by, BAR.During, BAR.Finishes, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Preceded_by, BAR.Meets, BAR.During, BAR.Finishes, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Preceded_by, BAR.Overlaps, BAR.During, BAR.Finishes, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Preceded_by, BAR.Finished_by, BAR.Preceded_by },
            new List<BAR> { BAR.Preceded_by, BAR.Contains, BAR.Preceded_by },
            new List<BAR> { BAR.Preceded_by, BAR.Start, BAR.During, BAR.Finishes, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Preceded_by, BAR.Equal, BAR.Preceded_by },
            new List<BAR> { BAR.Preceded_by, BAR.Started_by, BAR.Preceded_by },
            new List<BAR> { BAR.Preceded_by, BAR.During, BAR.During, BAR.Finishes, BAR.Overlapped_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Preceded_by, BAR.Finishes, BAR.Preceded_by },
            new List<BAR> { BAR.Preceded_by, BAR.Overlapped_by, BAR.Preceded_by },
            new List<BAR> { BAR.Preceded_by, BAR.Met_by, BAR.Preceded_by },
            new List<BAR> { BAR.Preceded_by, BAR.Preceded_by, BAR.Preceded_by }
        };

        public static List<BAR> TransitiveTableRecord(BAR firstRelation, BAR secondRelation)
        {
            if (firstRelation.Equals(BAR.None) || secondRelation.Equals(BAR.None))
            {
                return new List<BAR>();
            }

            foreach (var pair in BooleanAlgebra.TransitiveTableList)
            {
                if (pair[0].Equals(firstRelation) && pair[1].Equals(secondRelation))
                {
                    // skip first two relations wich are the input
                    return pair.Skip(2).ToList();
                }
            }

            return new List<BAR>();
        }

        public static Dictionary<BAR, BAR> GetInverseRelations()
        {
            return new Dictionary<BAR, BAR>()
            {
                { BAR.Precedes, BAR.Preceded_by},
                { BAR.Preceded_by, BAR.Precedes },
                { BAR.Meets, BAR.Met_by },
                { BAR.Met_by, BAR.Meets },
                { BAR.Overlaps, BAR.Overlapped_by },
                { BAR.Overlapped_by, BAR.Overlaps },
                { BAR.Contains, BAR.During },
                { BAR.During, BAR.Contains },
                { BAR.Finishes, BAR.Finished_by },
                { BAR.Finished_by, BAR.Finishes },
                { BAR.Start, BAR.Started_by },
                { BAR.Started_by, BAR.Start },
                { BAR.Equal, BAR.Equal }
            };
        }

        public static BAR GetInverseRelation(BAR booleanAlgebraRelation)
        {
            var inverseRelations = BooleanAlgebra.GetInverseRelations();
            return inverseRelations.ContainsKey(booleanAlgebraRelation) ?
                   inverseRelations[booleanAlgebraRelation] :
                   BAR.None;
        }

        public static Network PathConsistency(Network inputNetwork)
        {
            var graphRelations = new Dictionary<Tuple<string, string>, List<BAR>>();

            var pc = true;
            var pcList = new Stack<Tuple<string, string>>();

            // Set all possible relations for all variables in network
            for (var i = 0; i < inputNetwork.Variables.Count; i++)
            {
                for (var j = i + 1; j < inputNetwork.Variables.Count; j++)
                {
                    var tempTuple = new Tuple<string, string>(inputNetwork.Variables[i], inputNetwork.Variables[j]);
                    var tempTupleReverse = new Tuple<string, string>(inputNetwork.Variables[j], inputNetwork.Variables[i]);
                    var relationList = Enum.GetValues(typeof(BAR)).Cast<BAR>().Where(rel => rel != BAR.None).ToList();
                    graphRelations.Add(tempTuple, relationList);
                    graphRelations.Add(tempTupleReverse, relationList);
                    pcList.Push(tempTuple);
                    pcList.Push(tempTupleReverse);
                }
            }

            // Set relations defined by the user overriding previously set relations
            foreach (var networkRelations in inputNetwork.NetworkRelations)
            {
                var tempBarList = new List<BAR>();
                foreach (var relation in networkRelations.Relations)
                {
                    var bar = (BAR)Enum.Parse(typeof(BAR), relation, true);
                    tempBarList.Add(bar);
                }
                var tempTuple = new Tuple<string, string>(networkRelations.FirstVar, networkRelations.SecondVar);
                graphRelations[tempTuple] = tempBarList;
            }

            // set inverse relations for reverse pair (b,a if a,b is set)
            foreach (var tuple in pcList)
            {
                if (graphRelations[tuple].Count != Enum.GetValues(typeof(BAR)).Cast<BAR>().Where(rel => rel != BAR.None).ToList().Count)
                {
                    var reverseTuple = new Tuple<string, string>(tuple.Item2, tuple.Item1);
                    if (graphRelations[reverseTuple].Count == Enum.GetValues(typeof(BAR)).Cast<BAR>().Where(rel => rel != BAR.None).ToList().Count)
                    {
                        graphRelations[reverseTuple] = graphRelations[tuple].Select(rel => GetInverseRelation(rel)).ToList();
                    }
                }
            }

            while (pc && pcList.Any())
            {
                var lastTuple = pcList.Pop();
                var varI = lastTuple.Item1;
                var varJ = lastTuple.Item2;

                foreach (var varK in inputNetwork.Variables)
                {
                    if (varI == varK || varJ == varK)
                    {
                        continue;
                    }
                    var ik = new Tuple<string, string>(varI, varK);
                    var ij = new Tuple<string, string>(varI, varJ);
                    var jk = new Tuple<string, string>(varJ, varK);
                    var ki = new Tuple<string, string>(varK, varI);
                    var kj = new Tuple<string, string>(varK, varJ);

                    var tempSet = new HashSet<BAR>();

                    foreach (var relIJ in graphRelations[ij])
                    {
                        foreach (var relJK in graphRelations[jk])
                        {
                            var rels = BooleanAlgebra.TransitiveTableRecord(relIJ, relJK);
                            foreach (var rel in rels)
                            {
                                tempSet.Add(rel);
                            }
                        }
                    }

                    var intersection = graphRelations[ik].Intersect(tempSet.ToList()).ToList();
                    if (!graphRelations[ik].All(intersection.Contains))
                    {
                        graphRelations[ik] = intersection;
                        graphRelations[ki] = intersection.Select(rel => BooleanAlgebra.GetInverseRelation(rel)).ToList();
                        if (!pcList.Contains(ik))
                        {
                            pcList.Push(ik);
                        }
                    }
                    if (!intersection.Any())
                    {
                        pc = false;
                    }

                    tempSet.Clear();
                    foreach (var relKI in graphRelations[ki])
                    {
                        foreach (var relIJ in graphRelations[ij])
                        {
                            var rels = BooleanAlgebra.TransitiveTableRecord(relKI, relIJ);
                            foreach (var rel in rels)
                            {
                                tempSet.Add(rel);
                            }
                        }
                    }
                    intersection = graphRelations[kj].Intersect(tempSet.ToList()).ToList();
                    if (!graphRelations[kj].All(intersection.Contains))
                    {
                        graphRelations[jk] = intersection.Select(rel => BooleanAlgebra.GetInverseRelation(rel)).ToList();
                        if (!pcList.Contains(kj))
                        {
                            pcList.Push(kj);
                        }
                    }
                    if (!intersection.Any())
                    {
                        pc = false;
                    }
                }
            }

            // save constrained relations back to network
            var constrainedNetwork = inputNetwork;
            constrainedNetwork.NetworkRelations = new List<Relationship>();
            foreach (var tuple in graphRelations.Keys)
            {
                constrainedNetwork.NetworkRelations.Add(new Relationship(tuple.Item1, tuple.Item2, graphRelations[tuple].Select(rel => rel.ToString()).ToList()));
            }

            return constrainedNetwork;
        }
    }
}