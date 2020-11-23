using System.Collections.Generic;

namespace backend_learning_algorithm.Contracts
{
    public class Network
    {
        public List<string> Variables { get; set; }
        public List<Relationship> Relations { get; set; }
        public Network() { }

        public Network(List<string> variables, List<Relationship> relations)
        {
            this.Variables = variables;
            this.Relations = relations;
        }
    }
}