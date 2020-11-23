using System;
using System.Linq;
using System.Collections.Generic;
using BAR = backend_learning_algorithm.Common.BooleanAlgebraRelations;

namespace backend_learning_algorithm.Common
{
    public class BooleanAlgebra
    {
        private static List<List<BAR>> TransitiveTable = new List<List<BAR>>
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
        public static List<BAR> TransitiveTableRecord(string firstRelation, string secondRelation)
        {
            if (firstRelation.Equals("None") || secondRelation.Equals("None"))
            {
                return new List<BAR>();
            }
            var firstRelationEnum = (BAR)Enum.Parse(typeof(BAR), firstRelation, true);
            var secondRelationEnum = (BAR)Enum.Parse(typeof(BAR), secondRelation, true);
            if (!Enum.IsDefined(typeof(BAR), firstRelationEnum) || !Enum.IsDefined(typeof(BAR), secondRelationEnum))
            {
                return new List<BAR>();
            }

            var tableRecord = new List<BAR>();
            foreach (var pair in BooleanAlgebra.TransitiveTable)
            {
                if (pair[0].Equals(firstRelationEnum) && pair[1].Equals(secondRelationEnum))
                {
                    // skip first two relations wich are the input
                    tableRecord = pair.Skip(2).ToList();
                }
            }
            return tableRecord;
        }

        public static Dictionary<BAR, BAR> GetInverseRelations()
        {
            return new Dictionary<BAR, BAR>(){
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
    }
}