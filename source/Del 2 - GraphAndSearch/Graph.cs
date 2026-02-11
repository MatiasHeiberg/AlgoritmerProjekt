using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace GraphAndSearch
{
    public class Graph<T> where T : notnull
    {
        public readonly Dictionary<T, Node<T>> _nodes;
        private readonly Node<T> _root;
        public Graph(T rootKey) 
        {
            _nodes = [];
            _nodes[rootKey] = _root = new Node<T>(rootKey);

        }
        public void AddNode(T value, Node<T> parent)
        {
            _nodes.Add(value, new Node<T>(value, parent));
        }

        public void BFS(Node<T> target)
        {
            Queue<Node<T>> queue = new([_root]);

            while (queue.Count > 0)
            { 
                var node = queue.Dequeue();
                Console.WriteLine(node);
                if (node == target) break;

                foreach(Edge<T> edge in node.Edges)
                {
                    queue.Enqueue(edge.Child);
                }
            }
        }

        public void DFS()
        {
            Stack<Node<T>> stack = [];

            foreach (var node in _nodes)
            {

            }
        }
    }
}
