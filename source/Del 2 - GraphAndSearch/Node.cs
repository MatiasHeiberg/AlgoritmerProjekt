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
        private T _value;
        public T Value { get => _value; }
        public List<Edge<T>> Edges { get => _edges; }

        public Node(T value)
        {
            _edges = [];
            _value = value;
        }
        public Node(T value, Node<T> parent)
        {
            var edge = new Edge<T>(this, parent);
            _edges = [];
            _value = value;
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
    
