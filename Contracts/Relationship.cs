using System;
using System.Collections.Generic;
using backend_learning_algorithm.Validation;

namespace backend_learning_algorithm.Contracts
{
    public class Relationship
    {
        public string FirstVar { get; set; }

        public string SecondVar { get; set; }

        [RelationValidation(ErrorMessage="Invalid relation string")]
        public List<string> Relations { get; set; }

        public Relationship() { }

        public Relationship(string firstVar, string secondVar, List<string> relations)
        {
            this.FirstVar = firstVar;
            this.SecondVar = secondVar;
            this.Relations = relations;
        }
    }
}
   