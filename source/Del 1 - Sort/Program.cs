using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Algoritmer_Projekt
{
    // Vi fjerner <T> fra selve klassenavnet her, så Main kan køre uden problemer.
    // I stedet gør vi metoderne generiske eller kalder en generisk hjælper.
    public class Program
    {
        static void Main(string[] args)
        {
            // Input filerne
            string[] files = ["notSorted.json", "sorted.json", "reverseSorted.json"];

            // Vi starter sorterings-motoren specifikt for heltal (int)
            SorteringsMotor<int>.KørAlle(files);

            Console.WriteLine("Færdig! Tjek output-mappen.");
        }

        // Indlejret klasse til at håndtere Generics logikken (så vi undgår static problemer i Main)
        public static class SorteringsMotor<T>
        {
            public static void KørAlle(string[] files)
            {
                // Definition af dine algoritmer (ID og Navn)
                var algoritmer = new Dictionary<int, string>()
                {
                    { 0, "BubbleSort" },
                    { 1, "InsertionSort" }
                };

                // Ydre løkke: Gennemgå hver fil (notSorted, sorted, etc.)
                foreach (var filNavn in files)
                {
                    // Find filens "tilstand" (f.eks. "notSorted" fra "notSorted.json")
                    string inputState = Path.GetFileNameWithoutExtension(filNavn);

                    // Indre løkke: Kør alle algoritmer på den aktuelle fil
                    foreach (var algo in algoritmer)
                    {
                        // VIGTIGT: Vi indlæser filen på ny HVER gang. 
                        // Hvis vi genbrugte listen, ville InsertionSort få en liste, 
                        // som BubbleSort lige havde sorteret!
                        MyList<T> list = ImportFile(filNavn);

                        // Kør sortering
                        list.Sort(algorithm: algo.Key);

                        // Generer output navn: "BubbleSort_notSorted.txt"
                        string outputFilNavn = $"{algo.Value}_{inputState}.txt";

                        // Gem resultatet
                        Write(list, outputFilNavn);

                        Console.WriteLine($"Gemte: {outputFilNavn}");
                    }
                }
            }

            private static void Write(MyList<T> list, string filNavn)
            {
                // Bruger MyList's ToString metode
                string output = list.ToString();
                string outputMappe = GetOutputFolder();
                string filSti = Path.Combine(outputMappe, filNavn);

                File.WriteAllText(filSti, output);
            }

            private static MyList<T> ImportFile(string file)
            {
                MyList<T> list = new MyList<T>();

                // Vi bruger BaseDirectory til at finde input-filerne (som typisk ligger i bin/Debug)
                string basePath = AppContext.BaseDirectory;
                string filePath = Path.Combine(basePath, file);

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Kunne ikke finde filen: {filePath}");
                }

                string jsonString = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<NumbersData>(jsonString);

                if (data != null && data.Values != null)
                {
                    foreach (T i in data.Values)
                    {
                        list.Add(i);
                    }
                }

                return list;
            }

            // Hjælpeklasse til JSON deserialisering
            private class NumbersData
            {
                [JsonPropertyName("values")]
                public T[] Values { get; set; }
            }
        }

        // Denne metode behøver ikke være generisk, da den kun arbejder med stier
        private static string GetOutputFolder()
        {
            DirectoryInfo directory = new DirectoryInfo(AppContext.BaseDirectory);

            // Leder efter både .sln og .slnx for en sikkerheds skyld
            while (directory != null &&
                   directory.GetFiles("*.sln").Length == 0 &&
                   directory.GetFiles("*.slnx").Length == 0)
            {
                directory = directory.Parent;
            }

            if (directory == null)
                throw new DirectoryNotFoundException("Kunne ikke finde rodmappen med .sln filen.");

            string outputPath = Path.Combine(directory.FullName, "output");

            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);

            return outputPath;
        }
    }
}

//using System.Collections.Generic;
//using System.IO;
//using System.Text.Json;
//using System.Text.Json.Serialization;

//namespace Algoritmer_Projekt
//{
//    /// <summary>
//    /// TODO:
//    /// Indlæse JSON
//    /// Gemme det i en MyList
//    /// Sorteres
//    /// Eksporteres til ny JSON eller txt
//    /// </summary>

//    public class Program<T>
//    {
//        static void Main(string[] args)
//        {

//            string[] files = ["notSorted.json", "sorted.json", "reverseSorted.json"];

//            Program.Sort(files);

//        }

//        private static void Write<T>(MyList<T> list, string filNavn)
//        {
//            string output = list.ToString();
//            string outputMappe = GetOutputFolder();
//            string filSti = Path.Combine(outputMappe, filNavn);

//            File.WriteAllText(filSti, output);
//        }

//        public class NumbersData<T>
//        {
//            [JsonPropertyName("values")]
//            public T[] Values { get; set; } = Array.Empty<T>();
//        }

//        private static string GetOutputFolder()
//        {
//            // 1. Start der hvor programmet kører (nede i bin/Debug/...)
//            DirectoryInfo directory = new DirectoryInfo(AppContext.BaseDirectory);

//            // 2. Gå opad indtil vi finder mappen, der indeholder .sln filen
//            while (directory != null && directory.GetFiles("*.slnx").Length == 0)
//            {
//                directory = directory.Parent;
//            }

//            // Sikkerhedscheck: Hvis directory er null, fandt vi aldrig roden
//            if (directory == null)
//            {
//                throw new DirectoryNotFoundException("Kunne ikke finde rodmappen med .sln filen.");
//            }

//            // 3. Vi er nu i Root. Find eller opret "output" mappen herfra.
//            string outputPath = Path.Combine(directory.FullName, "output");

//            if (!Directory.Exists(outputPath))
//            {
//                Directory.CreateDirectory(outputPath);
//            }

//            return outputPath;
//        }

//        private static void Sort(string[] files)
//        {
//            foreach (string file in files)
//            {
//                MyList<T> list = ImportFile(file);

//                list.Sort(algorithm: 0);
//                Program<T>.Write<T>(list, "bubbleSort_notSorted.txt");
//            }
//        }

//        private static MyList<T> ImportFile(string file)
//        {
//            MyList<T> list = new MyList<T>();
//            string basePath = AppContext.BaseDirectory;
//            string filePath = Path.Combine(basePath, file);
//            string jsonString = File.ReadAllText(filePath);

//            var data = JsonSerializer.Deserialize<NumbersData<T>>(jsonString);
//            T[]? arr = data?.Values;

//            foreach (T i in arr)
//            {
//                list.Add(i);
//            }

//            return list;
//        }

//        private static navn(MyList<T> list)
//        {
//            list.Sort(algorithm: 0);
//        }
//    }
//}
