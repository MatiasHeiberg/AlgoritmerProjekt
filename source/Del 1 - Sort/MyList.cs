using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Algoritmer_Projekt
{
    /// <summary>
    /// TODO
    /// Tilføjes indekser 
    /// Implementere bubblesort og gøre den generisk, bruge IComparable og tælle sammenligninger
    /// Implementere Sort() metoden der skal bruge algortime metoderne
    /// Unit test for algoritmerne
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyList<T> where T : IComparable<T>, INumber<T>
    {
        private T[] _arr;
        private int _pointer;

        public int Length {  get { return _pointer; } }

        public MyList()
        {
            _arr = new T[0];
            _pointer = 0;
        }
        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException("value cannot be null");

            if (_arr.Length <= _pointer)
            {
                var newLength = _arr.Length == 0 ? 4 : _arr.Length * 2;
                Array.Resize(ref _arr, newLength);
            }

            _arr[_pointer] = value;
            _pointer++;

        }

        public void Remove(T value)
        {
            if (value == null)
                throw new ArgumentNullException("Value cannot be null");

            int removedItem = Array.FindLastIndex(_arr, _pointer - 1, _pointer, i => i != null &&  i.CompareTo(value) == 0);
            _arr[removedItem] = default;

            for (int i = removedItem; i < _pointer; i++)
            {
                _arr[i] = _arr[i + 1];
            }

            _pointer--;

            if (_pointer <  (_arr.Length / 2) / 2)
                Array.Resize(ref _arr, _arr.Length / 2);
        }

        public void Clear()
        {
            Array.Clear(_arr);
        }

        public int Sort(int algorithm = 0)
        {
            int count = default;
            return count;
        }
        
        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        private int BubbleSort()
        { 
            throw new NotImplementedException(); 
        }


        public int LBubbleSort()
        {
            int comparisonCount = 0;
            bool swapped; // bool der fortæller om der er lavet en bytning
            do
            {
                swapped = false;

                for (int i = 0; i < _arr.Length - 1; i++)
                {
                    comparisonCount++;

                    if (_arr[i] > _arr[i+1])
                      {
                        T temp = _arr[i];
                        _arr[i] = _arr[i + 1];
                        _arr[i + 1] = temp;

                        swapped = true;
                       }
                }
            }
            while (swapped);
            return comparisonCount;
        }



         public int MBubbleSort()
                {
                    int comparisonCount = default;
                    int unsorted = _arr.Length - 1;
                    bool swapped;
                    while (unsorted > 0)
                    {
                        swapped = false;
                        for (int i = 0; i < unsorted; i++)
                        {
                            comparisonCount++;
                            if (_arr[i] > _arr[i + 1])
                            {
                                T temp = _arr[i];
                                _arr[i] = _arr[i + 1];
                                _arr[i + 1] = temp;

                                swapped = true;
                            }
                        }
                        if (!swapped) // Hvis vi ingen værdier blev byttet efter at have itereret hele listen igennem, så er det fordi den allerede er sorteret. 
                            break; // Stop sorteringen tidligt.

                        unsorted--;
                    }
                    return comparisonCount;
                }

        /*
        private void ABubbleSort()
        {
            bool swapped = true;

            while (swapped)
            {
                swapped = false;
                for (int i = 1; i < B.Length; i++)
                {
                    if (B[i - 1] > B[i])
                    {
                        int var = B[i]; // midlertidig variabel til at holde værdien
                        B[i] = (B[i - 1]); // flytter den anden værdi
                        B[i - 1] = var; // sætter den gemte værdi ind

                        swapped = true;
                    }
                }
            }
        }
         */
        private int InsertionSort()
        {
            int count = default;                        // Vores comparison tæller

            count++;
            if (_arr == null)
                throw new Exception();

            count++;
            if (_arr.Length == 0)
                throw new Exception();


            for (int i = 1; i < _arr.Length; i++)
            {
                T key = _arr[i];                        // Det tal vi vil placere
                int pointer = i - 1;                    // Vi starter med at kigge til venstre
                                                        
                while ( true )
                {
                    count++;
                    if (pointer < 0) break;             // Pointer >= 0: Vi må ikke ryge ud over kanten

                    count++;
                    if (_arr[pointer] < key) break;     // arr[pointer] < key: Tallet til venstre er mindre end vores key

                    _arr[pointer + 1] = _arr[pointer];  // Skub det store tal til højre
                    pointer--;                          // Ryk pointeren til venstre
                }

                                                        // Når while-løkken stopper (enten pga. start af array eller et mindre tal),
                                                        // så er "pointer + 1" det korrekte hul til vores key.
                _arr[pointer + 1] = key;
            }
            return count;
        }
    }
}
