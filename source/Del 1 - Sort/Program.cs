using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

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

            MyList<int> list = new MyList<int>();
            string basePath = AppContext.BaseDirectory;
            string filePath = Path.Combine(basePath, "notSorted.json");
            string jsonString = File.ReadAllText(filePath);

            var data = JsonSerializer.Deserialize<NumbersData>(jsonString);
            int[]? arr = data?.Values;

            foreach (int i in arr)
            {
                list.Add(i);
            }

            Console.WriteLine($"Bubble sort: {list.Sort()}\n{list}");
        }

        //private static void Write<T>(MyList<T> list)
        //{
        //    T[] arr = list.ToArray();
        //    string outPath = App
        //}

        public class NumbersData
        {
            [JsonPropertyName("values")]
            public int[] Values { get; set; } = Array.Empty<int>();
        }
    }
}
