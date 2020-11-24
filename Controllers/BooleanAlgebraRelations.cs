using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using backend_learning_algorithm.Common;
using backend_learning_algorithm.Contracts;

namespace backend_learning_algorithm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooleanAlgebra : ControllerBase
    {
        [HttpGet("relations")]
        public Dictionary<string, int> GetBooleanAlgebraRelations()
        {
            var relations = new Dictionary<string, int>();
            foreach (BooleanAlgebraRelations relation in Enum.GetValues(typeof(BooleanAlgebraRelations)))
            {
                if ((int)relation != 0)
                {
                    relations.Add(relation.ToString(), (int)relation);
                }
            }
            return relations;
        }

        [HttpPost("constraintNetwork")]
        public Network PostConstraintNetwork([FromBody] Network network)
        {
            var constrainedNetwork = backend_learning_algorithm.Common.BooleanAlgebra.ConstraintPropagation(network);
            return network;
        }
    }
}