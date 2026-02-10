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

            list.Sort(algorithm: 0);
            Program.Write<int>(list, "bubbleSort_notSorted.json");
        }

        private static void Write<T>(MyList<T> list, string filNavn)
        {
            string output = list.ToString();
            string outputMappe = GetOutputFolder();
            string filSti = Path.Combine(outputMappe, filNavn);

            File.WriteAllText(filSti, output);
        }

        public class NumbersData
        {
            [JsonPropertyName("values")]
            public int[] Values { get; set; } = Array.Empty<int>();
        }

        private static string GetOutputFolder()
        {
            // 1. Start der hvor programmet kører (nede i bin/Debug/...)
            DirectoryInfo directory = new DirectoryInfo(AppContext.BaseDirectory);

            // 2. Gå opad indtil vi finder mappen, der indeholder .sln filen
            while (directory != null && directory.GetFiles("*.slnx").Length == 0)
            {
                directory = directory.Parent;
            }

            // Sikkerhedscheck: Hvis directory er null, fandt vi aldrig roden
            if (directory == null)
            {
                throw new DirectoryNotFoundException("Kunne ikke finde rodmappen med .sln filen.");
            }

            // 3. Vi er nu i Root. Find eller opret "output" mappen herfra.
            string outputPath = Path.Combine(directory.FullName, "output");

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            return outputPath;
        }
    }
}
