using System.Collections.Generic;

namespace backend_learning_algorithm.Contracts
{
    public class Network
    {
        public List<string> Variables { get; set; }
        public List<Relationship> NetworkRelations { get; set; }
        public Network() { }

        public Network(List<string> variables, List<Relationship> networkRelations)
        {
            this.Variables = variables;
            this.NetworkRelations = networkRelations;
        }
    }
}