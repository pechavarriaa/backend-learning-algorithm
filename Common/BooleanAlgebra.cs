using System.Collections.Generic;
namespace backend_learning_algorithm.Common
{
    public class BooleanAlgebra
    {
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