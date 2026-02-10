using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace GraphAndSearch
{
    public class Graph<T> where T : notnull
    {
        private readonly Dictionary<T, Node<T>> _nodes;

        public Graph(T rootKey) 
        {
            _nodes = [];
           // _nodes[rootKey] = new Node<T>(rootKey);

        }
        public void AddNode(T value)
        {
        }

        public void AddEdges(T from, T to)
        {

        }
    }
}
