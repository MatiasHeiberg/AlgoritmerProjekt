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
        private Node<T> _parent;

        public Node<T> Child { get; }

        public Edge(Node<T> child, Node<T> parent)
        {
            Child = child;
            _parent = parent;
        }
    }
}
