using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAndSearch
{
    /// <summary>
    /// Forlystelser
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public T Value { get; }
        private List<Edge<T>> _edges;

        public Node(T value, Node<T> parent) 
        {
            Edge<T> edge = new Edge<T>(this, parent);
            Value = value;
            _edges = new List<Edge<T>>();
        }
        public void AddEdge(Edge<T> edge)
        {
            _edges.Add(edge);
        }
    }
}
    
