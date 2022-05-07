using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using backend_learning_algorithm.Common;
using backend_learning_algorithm.Contracts;
using static backend_learning_algorithm.Common.BooleanAlgebra;

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
            return PathConsistency(network);
        }

        [HttpPost("solveNetwork")]
        public Network solveNetwork([FromBody] Network network)
        {
            return NetworkSolver.solver(network);
        }

        [HttpPost("solveNetworkWithPreferences")]
        public Network solveNetworkWithPreferences([FromBody] NetworkWithPreferences networkWithPreferences)
        {
            return NetworkWithPreferencesSolver.solver(networkWithPreferences);
        }

    }
}