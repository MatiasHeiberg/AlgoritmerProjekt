using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace GraphAndSearch
{
    /// <summary>
    /// Repræsenterer en graf-datastruktur med søgefunktionalitet.
    /// Grafen består af noder forbundet med kanter og understøtter BFS og DFS søgning.
    /// </summary>
    /// <typeparam name="T">Typen af værdier som noderne indeholder. Skal være non-null.</typeparam>
    public class Graph<T> where T : notnull
    {
        public readonly Dictionary<T, Node<T>> _nodes;
        private readonly Node<T> _root;
        
        /// <summary>
        /// Initialiserer en ny graf med en root node.
        /// Root fungerer som startpunkt for søgninger i grafen.
        /// </summary>
        /// <param name="rootKey">Værdien for grafens root node.</param>
        public Graph(T rootKey) 
        {
            _nodes = [];
            _nodes[rootKey] = _root = new Node<T>(rootKey);

        }
        
        /// <summary>
        /// Tilføjer en ny node til grafen og knytter den til en parent node.
        /// Noden registreres i grafens dictionary for hurtig opslag.
        /// </summary>
        /// <param name="value">Værdien for den nye node.</param>
        /// <param name="parent">Den parent som den nye node skal knyttes til.</param>
        public void AddNode(T value, Node<T> parent)
        {
            _nodes.Add(value, new Node<T>(value, parent));
        }

        /// <summary>
        /// Udfører en Breadth-First Search i grafen for at finde target noden.
        /// Søger lag for lag startende fra root.
        /// Udskriver søgningsvejen til konsollen.
        /// </summary>
        /// <param name="target">Den node der søges efter.</param>
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

        /// <summary>
        /// Udfører en Depth-First Search i grafen for at finde target-noden.
        /// Søger i dybden inden den fortsætter til næste gren.
        /// Udskriver søgningsvejen til konsollen.
        /// </summary>
        /// <param name="target">Den node der søges efter.</param>
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
