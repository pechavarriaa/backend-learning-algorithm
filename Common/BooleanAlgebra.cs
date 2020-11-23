using System;
using System.Collections.Generic;

namespace backend_learning_algorithm.Common
{
    public class BooleanAlgebra
    {
        public static List<BooleanAlgebraRelations> TransitiveTableRecord(string firstRelation, string secondRelation)
        {
            if (firstRelation.Equals("None") || secondRelation.Equals("None"))
            {
                return new List<BooleanAlgebraRelations>();
            }
            var firstRelationEnum = (BooleanAlgebraRelations)Enum.Parse(typeof(BooleanAlgebraRelations), firstRelation, true);
            var secondRelationEnum = (BooleanAlgebraRelations)Enum.Parse(typeof(BooleanAlgebraRelations), secondRelation, true);
            if (!Enum.IsDefined(typeof(BooleanAlgebraRelations), firstRelationEnum) || !Enum.IsDefined(typeof(BooleanAlgebraRelations), secondRelationEnum))
            {
                return new List<BooleanAlgebraRelations>();
            }
            var transitiveTable = new Dictionary<Tuple<BooleanAlgebraRelations, BooleanAlgebraRelations>, List<BooleanAlgebraRelations>>();
            return transitiveTable[new Tuple<BooleanAlgebraRelations, BooleanAlgebraRelations>(firstRelationEnum, secondRelationEnum)];
        }

        public static Dictionary<BooleanAlgebraRelations, BooleanAlgebraRelations> GetInverseRelations()
        {
            return new Dictionary<BooleanAlgebraRelations, BooleanAlgebraRelations>(){
                { BooleanAlgebraRelations.Contains, BooleanAlgebraRelations.During },
                { BooleanAlgebraRelations.During, BooleanAlgebraRelations.Contains },
                { BooleanAlgebraRelations.Finishes, BooleanAlgebraRelations.Finished_by },
                { BooleanAlgebraRelations.Finished_by, BooleanAlgebraRelations.Finishes },
                { BooleanAlgebraRelations.Start, BooleanAlgebraRelations.Started_by },
                { BooleanAlgebraRelations.Started_by, BooleanAlgebraRelations.Start },
                { BooleanAlgebraRelations.Equal, BooleanAlgebraRelations.Equal }
            };
        }

        public static BooleanAlgebraRelations GetInverseRelation(BooleanAlgebraRelations booleanAlgebraRelation)
        {
            var inverseRelations = BooleanAlgebra.GetInverseRelations();

            return inverseRelations.ContainsKey(booleanAlgebraRelation) ?
                   inverseRelations[booleanAlgebraRelation] :
                   BooleanAlgebraRelations.None;
        }
    }
}