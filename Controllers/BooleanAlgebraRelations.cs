using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend_learning_algorithm.Common;

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
    }
}