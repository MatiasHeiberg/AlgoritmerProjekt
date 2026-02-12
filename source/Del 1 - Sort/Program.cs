using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Algoritmer_Projekt
{
    /// <summary>
    /// Hovedprogrammet for sorteringsalgoritme-demonstration.
    /// Læser testdata fra JSON-filer, sorterer dem og gemmer resultaterne.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Programmets indgangspunkt.
        /// Kører alle sorteringsalgoritmer på de definerede testfiler.
        /// </summary>
        /// <param name="args">Kommandolinjeargumenter.</param>
        static void Main(string[] args)
        {
            string[] files = ["notSorted.json", "sorted.json", "reverseSorted.json"];

            SortEngine<int>.RunAll(files);

            Console.WriteLine("Færdig! Tjek output-mappen.");
        }

        /// <summary>
        /// Klasse til at køre og teste sorteringsalgoritmer.
        /// Håndterer indlæsning, sortering og eksport af testdata.
        /// </summary>
        /// <typeparam name="T">Typen af elementer der skal sorteres.</typeparam>
        public static class SortEngine<T>
        {
            /// <summary>
            /// Kører alle sorteringsalgoritmer på alle angivne filer.
            /// For hver kombination af fil og algoritme gemmes resultatet i output-mappen.
            /// </summary>
            /// <param name="files">Array af filnavne der skal behandles.</param>
            public static void RunAll(string[] files)
            {
                var algoritmer = new Dictionary<int, string>()
                {
                    { 0, "BubbleSort" },
                    { 1, "InsertionSort" }
                };

                foreach (var filNavn in files)
                {
                    string inputState = Path.GetFileNameWithoutExtension(filNavn);

                    foreach (var algo in algoritmer)
                    {
                        MyList<T> list = ImportFile(filNavn);

                        int comparisons = list.Sort(algorithm: algo.Key);

                        string outputFilNavn = $"{algo.Value}_{inputState}.txt";

                        Write(list, outputFilNavn, comparisons);

                        Console.WriteLine($"Gemte: {outputFilNavn}");
                    }
                }
            }

            /// <summary>
            /// Skriver den sorterede liste og antallet af sammenligninger til en fil.
            /// Opretter output-mappen hvis den ikke eksisterer.
            /// </summary>
            /// <param name="list">Den sorterede liste der skal gemmes.</param>
            /// <param name="filNavn">Navnet på output-filen.</param>
            /// <param name="comparisons">Antallet af sammenligninger udført under sorteringen.</param>
            private static void Write(MyList<T> list, string filNavn, int comparisons)
            {
                string output = $"Comparison count: {comparisons} \nResult:  {list.ToString()}";
                string outputMappe = GetOutputFolder();
                string filSti = Path.Combine(outputMappe, filNavn);

                File.WriteAllText(filSti, output);
            }

            /// <summary>
            /// Importerer data fra en JSON-fil og opretter en MyList med værdierne.
            /// </summary>
            /// <param name="file">Filnavnet på JSON-filen der skal indlæses.</param>
            /// <returns>En MyList indeholdende værdierne fra filen.</returns>
            /// <exception cref="FileNotFoundException">Kastes hvis filen ikke findes.</exception>
            private static MyList<T> ImportFile(string file)
            {
                MyList<T> list = new MyList<T>();

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

            /// <summary>
            /// Hjælpeklasse til deserialisering af JSON-data.
            /// </summary>
            private class NumbersData
            {
                [JsonPropertyName("values")]
                public T[] Values { get; set; }
            }
        }

        /// <summary>
        /// Finder eller opretter output-mappen i solution-roden.
        /// Søger opad i mappehierarkiet for at finde .sln eller .slnx filen.
        /// </summary>
        /// <returns>Den fulde sti til output-mappen.</returns>
        /// <exception cref="DirectoryNotFoundException">Kastes hvis solution-filen ikke kan findes.</exception>
        private static string GetOutputFolder()
        {
            DirectoryInfo directory = new DirectoryInfo(AppContext.BaseDirectory);

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
            {
                Directory.CreateDirectory(outputPath);
                Console.WriteLine("Oprettede mappen output");
            }

            return outputPath;
        }
    }
}
