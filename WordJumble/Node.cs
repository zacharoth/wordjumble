using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordJumble
{
    public class Node
    {
        public string Word { get; set; }
        public bool IsValid { get; set; }
        public Dictionary<string, Node> Edges { get; private set; }

        public Node()
        {
            Edges = new Dictionary<string, Node>();
            IsValid = false;
        }
    }
}
