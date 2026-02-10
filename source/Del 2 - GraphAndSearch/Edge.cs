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
        public Node<T> From { get; }

        public Node<T> To { get; }

        public Edge(Node<T> from, Node<T> to)
        {
            From = from;
            To = to;
        }
    }
}
