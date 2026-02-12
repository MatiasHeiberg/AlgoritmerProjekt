using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAndSearch
{
    /// <summary>
    /// Repræsenterer en node i en graf.
    /// Bruges til at repræsentere forlystelser i en forlystelsespark.
    /// Hver node kan have flere kanter til andre noder.
    /// </summary>
    /// <typeparam name="T">Typen af værdien som noden indeholder.</typeparam>
    public class Node<T>
    {
        private List<Edge<T>> _edges;
        private T _value;
        public T Value { get => _value; }
        public List<Edge<T>> Edges { get => _edges; }

        /// <summary>
        /// Initialiserer en ny node med den angivne værdi, som i dette projekt er forlystelsesnavnet.
        /// Noden startes uden nogen kanter.
        /// </summary>
        /// <param name="value">Værdien som noden skal indeholde.</param>
        public Node(T value)
        {
            _edges = [];
            _value = value;
        }
        
        /// <summary>
        /// Initialiserer en ny node med den angivne værdi og tilknytter den til en parent node.
        /// Opretter automatisk en kant fra parent til denne node.
        /// </summary>
        /// <param name="value">Værdien som noden skal indeholde.</param>
        /// <param name="parent">Den parent node som denne node skal knyttes til.</param>
        public Node(T value, Node<T> parent)
        {
            var edge = new Edge<T>(this, parent);
            _edges = [];
            _value = value;
            if (parent != null)
                parent.AddEdge(edge);
        }
        
        /// <summary>
        /// Tilføjer en kant til nodens liste af kanter.
        /// Bruges til at oprette forbindelser til andre noder.
        /// </summary>
        /// <param name="edge">Kanten der skal tilføjes.</param>
        public void AddEdge(Edge<T> edge)
        {
            _edges.Add(edge);
        }

        /// <summary>
        /// Returnerer en string-repræsentation af noden.
        /// Viser nodens værdi.
        /// </summary>
        /// <returns>Nodens værdi som string.</returns>
        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
