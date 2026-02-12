using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAndSearch
{
    /// <summary>
    /// Repræsenterer en kant (edge) mellem to noder i en graf.
    /// Bruges til at definere stier mellem forlystelser i en forlystelsespark.
    /// </summary>
    /// <typeparam name="T">Typen af værdier som noderne indeholder.</typeparam>
    public class Edge<T>
    {
        private Node<T> _parent;

        public Node<T> Child { get; }

        /// <summary>
        /// Initialiserer en ny kant mellem en barn-node og en forælder-node.
        /// </summary>
        /// <param name="child">Den node som kanten peger til.</param>
        /// <param name="parent">Den node som kanten kommer fra.</param>
        public Edge(Node<T> child, Node<T> parent)
        {
            Child = child;
            _parent = parent;
        }
    }
}
