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
            Console.WriteLine($"BFS target: {target}");

            Queue<Node<T>> queue = new([_root]);

            while (queue.Count > 0)
            { 
                var node = queue.Dequeue();

                if (node == target)
                {
                    Console.Write($"{target} found!\n\n");
                    break;
                }
                Console.Write($"{node} -> ");

                foreach (Edge<T> edge in node.Edges)
                {
                    queue.Enqueue(edge.Child); 
                }
                if (queue.Count == 0)
                    Console.Write($"{target} not found!\n\n");
            }
        }

        public void DFS(Node<T> target)
        {
            Console.WriteLine($"DFS target: {target}");
            Stack<Node<T>> stack = new([_root]);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                if (node == target)
                {
                    Console.Write($"{target} found!\n\n");
                    return;
                }

                Console.Write($"{node} -> ");

                foreach (Edge<T> edge in node.Edges)
                {
                    stack.Push(edge.Child); 
                }
            }
            Console.Write($"{target} not found\n\n");
        }
    }
}
