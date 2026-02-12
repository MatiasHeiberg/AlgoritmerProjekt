using GraphAndSearch;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Algoritmer_Projekt
{
    /// <summary>
    /// En generisk dynamisk liste-implementering med støtte for forskellige sorteringsalgoritmer.
    /// Listen kan vokse automatisk når der tilføjes elementer.
    /// </summary>
    /// <typeparam name="T">Typen af elementer der opbevares i listen.</typeparam>
    public class MyList<T> : IEnumerable<T>, ICollection
    {
        private T[] _arr;
        private int _pointer;

        public int Count {  get { return _pointer; } }
        public bool IsSynchronized => throw new NotImplementedException();
        public object SyncRoot => throw new NotImplementedException();
        public T this[int index]
        {
            get 
            { 
                ValidateIndex(index); 
                return _arr[index]; 
            }
            set 
            {
                ValidateIndex(index);
                _arr[index] = value;
            }
        } 

        /// <summary>
        /// Initialiserer en ny instans af MyList-klassen som er tom.
        /// Starter med et internt array af størrelse 0 som udvides ved første tilføjelse.
        /// </summary>
        public MyList()
        {
            _arr = new T[0];
            _pointer = 0;
        }
        
        /// <summary>
        /// Tilføjer et element til slutningen af listen.
        /// Fordobler automatisk kapaciteten af det interne array når det bliver fyldt.
        /// </summary>
        /// <param name="value">Elementet der skal tilføjes til listen.</param>
        /// <exception cref="ArgumentNullException">Kastes hvis value er null.</exception>
        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException("value cannot be null");

            if (_arr.Length <= Count)
            {
                var newLength = _arr.Length == 0 ? 4 : _arr.Length * 2;
                Array.Resize(ref _arr, newLength);
            }

            _arr[_pointer] = value;
            _pointer++;
        }
        
        /// <summary>
        /// Sorterer elementerne i listen ved hjælp af den angivne algoritme.
        /// Returnerer antallet af sammenligninger der blev udført under sorteringen.
        /// </summary>
        /// <param name="comparer">Comparer til sammenligning af elementer. Hvis null, bruges standardcomparer.</param>
        /// <param name="algorithm">Sorteringsalgoritmen der skal bruges: 0 = BubbleSort, 1 = InsertionSort.</param>
        /// <returns>Antallet af sammenligninger der blev udført under sorteringen.</returns>
        /// <exception cref="ArgumentException">Kastes hvis et ugyldigt algoritmenummer er angivet.</exception>
        public int Sort(IComparer<T>? comparer = null, int algorithm = 0)
        {
            var activeComparer = comparer ?? Comparer<T>.Default;

            if (algorithm == 0) return BubbleSort(activeComparer);
            if (algorithm == 1) return InsertionSort(activeComparer);
            else throw new ArgumentException();
        }
      
        /// <summary>
        /// Sorterer listen ved hjælp af Bubble Sort-algoritmen.
        /// Implementerer optimering som stopper tidligt hvis listen allerede er sorteret.
        /// Sammenligner tilstødende elementer og bytter dem hvis de er i forkert rækkefølge.
        /// </summary>
        /// <param name="comparer">Comparer der bruges til at sammenligne elementer.</param>
        /// <returns>Antallet af sammenligninger der blev udført.</returns>
        /// <exception cref="ArgumentException">Kastes hvis array-længden er 0.</exception>
        /// <exception cref="NullReferenceException">Kastes hvis arrayet er null.</exception>
        private int BubbleSort(IComparer<T> comparer)
        {
            int count = default;
            if (_arr.Length == 0) throw new ArgumentException();
            if (_arr == null) throw new NullReferenceException();
            
            int unsorted = Count - 1;
            bool swapped;

            while (unsorted > 0)
            {
                swapped = false;
                for (int i = 0; i < unsorted; i++)
                {
                    var current = this[i];
                    var next = this[i + 1];

                    count++; 
                    if (comparer.Compare(current, next) > 0)
                    {
                        T temp = this[i];
                        this[i] = this[i + 1];
                        this[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)                                       // Hvis vi ingen værdier blev byttet efter at have itereret hele listen igennem, så er det fordi den allerede er sorteret. 
                    break;                                          // Stop sorteringen tidligt.

                unsorted--;
            }
            return count;
        }
        
        /// <summary>
        /// Sorterer listen ved hjælp af Insertion Sort-algoritmen.
        /// Finder først det mindste element og placerer det først, derefter indsætter hvert element på den korrekte position.
        /// </summary>
        /// <param name="comparer">Comparer der bruges til at sammenligne elementer.</param>
        /// <returns>Antallet af sammenligninger der blev udført.</returns>
        /// <exception cref="NullReferenceException">Kastes hvis arrayet er null.</exception>
        /// <exception cref="ArgumentException">Kastes hvis Count er 0.</exception>
        private int InsertionSort(IComparer<T> comparer)
        {
            int count = default;                                            // Vores comparison tæller

            if (_arr == null) throw new NullReferenceException();
            if (Count == 0) throw new ArgumentException();
            if (Count == 1) return count;

            int minIndex = 0;
            for (int i = 1; i < Count; i++)
            {
                count++;
                if (comparer.Compare(this[i], this[minIndex]) <= 0) minIndex = i;
            }
            Swap(0, minIndex);

            for (int i = 2; i < Count; i++)
            {
                T key = this[i];                                            // Det tal vi vil placere
                int pointer = i - 1;                                        // Vi starter med at kigge til venstre

                while (true)
                {
                    count++;
                    if (comparer.Compare(this[pointer], key) <= 0) break;    // arr[pointer] <= key: Tallet til venstre er mindre, eller lig med key. 

                    this[pointer + 1] = this[pointer];                      // Skub det store tal til højre
                    pointer--;                                              // Ryk pointeren til venstre
                }
                                                                            // Når while-løkken stopper (enten pga. start af array eller et mindre tal),
                                                                            // så er "pointer + 1" det korrekte hul til vores key.
                this[pointer + 1] = key;
            }
            return count;

            void Swap(int targetIndex, int sourceIndex)
            {
                T temp = this[targetIndex];
                this[targetIndex] = this[sourceIndex];
                this[sourceIndex] = temp;
            }
        }
        
        /// <summary>
        /// Returnerer en string-repræsentation af listen i formatet [element1, element2, ...].
        /// Viser kun de elementer der faktisk er i brug (Count), ikke hele det interne array.
        /// </summary>
        /// <returns>En string der repræsenterer listens indhold.</returns>
        public override string ToString()
        {
            return $"[{string.Join(", ", _arr[..Count])}]";
        }
        
        /// <summary>
        /// Returnerer en enumerator der itererer gennem MyList-samlingen.
        /// Gør det muligt at bruge listen i foreach-løkker.
        /// </summary>
        /// <returns>En IEnumerator der kan bruges til at iterere gennem samlingen.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            while (i < Count)
            {
                yield return _arr[i];
                i++;
            }
        }
        
        /// <summary>
        /// Returnerer en ikke-generisk enumerator der itererer gennem samlingen.
        /// Implementering af IEnumerable.GetEnumerator().
        /// </summary>
        /// <returns>En IEnumerator der kan bruges til at iterere gennem samlingen.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Validerer at et givet indeks er inden for grænserne af listen.
        /// Bruges af indexeren for at sikre sikker adgang til elementer.
        /// </summary>
        /// <param name="index">Indekset der skal valideres.</param>
        /// <exception cref="IndexOutOfRangeException">Kastes hvis indekset er uden for listens grænser.</exception>
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _pointer)
                throw new IndexOutOfRangeException($"Index {index} is out of range. Count is {_pointer}");
        }
    }
}