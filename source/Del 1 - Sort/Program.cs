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
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            //list.Add(1000);
            //list.Add(-2);
            //list.Add(8);
            //list.Add(45);
            //list.Add(1);

            Console.WriteLine(list.LBubbleSort());
            Console.WriteLine(list.MBubbleSort());
        }
    }
}
