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
        private Node<T> _child { get; }
        private Node<T> _parent { get; }

        public Edge(Node<T> childNode, Node<T> parentNode)
        {
            _child = childNode;
            _parent = parentNode;
        }
    }
}
