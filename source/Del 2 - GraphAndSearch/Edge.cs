using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAndSearch
{
    /// <summary>
    /// Stier mellem forlystelser
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Edge<T>
    {
        private Node<T> _node1 { get; }
        private Node<T> _node2 { get; }

        public Edge(Node<T> childNode, Node<T> parentNode)
        {
            _node1 = childNode;
            _node2 = parentNode;
        }
    }
}
