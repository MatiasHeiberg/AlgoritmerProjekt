using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAndSearch
{
    public class Node<T>
    {
        private T value;
        private List<Edge<T>> edges;
    }
}
