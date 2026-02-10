using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace GraphAndSearch
{
    public class Graph<T>
    {
        private readonly Dictionary<T, Node<T>> _nodes = new();



        public void AddNode(T value)
        {
            _nodes[value] = new Node<T>(value);
        }

        public void AddEdges(T from, T to)
        {

        }
    }
}
