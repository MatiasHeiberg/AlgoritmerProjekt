using System.Collections.Generic;

namespace Algoritmer_Projekt
{
    /// <summary>
    /// TODO:
    /// Indlæse JSON
    /// Gemme det i en MyList
    /// Sorteres
    /// Eksporteres til ny JSON eller txt
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list1 = new MyList<int>();

            Add(list1);

            Console.WriteLine($"Bubble sort: {list1.Sort(algorithm : 1)}\n{list1}");
        }
        public static MyList<int> Add(MyList<int> list)
        {
            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.Add(1000);
            list.Add(-2);
            list.Add(8);
            list.Add(45);
            list.Add(1);
            return list;
        }
    }
}
