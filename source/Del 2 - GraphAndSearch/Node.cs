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
        private List<Edge<T>> _edges;
        public T Value { get; }
        public List<Edge<T>> Edges { get; }

        public Node(T value) : this(value, parent: null)
        {
        
        }
        public Node(T value, Node<T> parent)
        {
            var edge = new Edge<T>(this, parent);
            _edges = [edge];
            Value = value;
            if (parent != null)
                parent.AddEdge(edge);
        }
        public void AddEdge(Edge<T> edge)
        {
            _edges.Add(edge);
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
    
