using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using backend_learning_algorithm.Common;

namespace backend_learning_algorithm.Validation
{
    public class RelationValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var relations = value as List<string>;

            foreach (string relation in relations)
            {
                if (!Enum.IsDefined(typeof(BooleanAlgebraRelations), relation))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
