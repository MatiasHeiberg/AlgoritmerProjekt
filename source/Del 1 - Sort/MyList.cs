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
    /// TODO
    /// Unit test for algoritmerne: 1 elemement, flere ens elementer, allerede sorteret, reverse
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyList<T> : IEnumerable<T>, ICollection
    {
        private T[] _arr;
        private int _pointer;

        public int Count {  get { return _pointer; } }

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public T this[int index]
        {
            get { return _arr[index]; }
            set { _arr[index] = value;  }
        } 

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
        /*
        public void Remove(T value)
        {
            if (value == null)
                throw new ArgumentNullException("Value cannot be null");

            int removedItem = Array.FindLastIndex(_arr, _pointer - 1, _pointer, i => i != null &&  i.Compare(value) == 0);
            _arr[removedItem] = default;

            for (int i = removedItem; i < _pointer; i++)
            {
                _arr[i] = _arr[i + 1];
            }

            _pointer--;

            if (_pointer <  (_arr.Length / 2) / 2)
                Array.Resize(ref _arr, _arr.Length / 2);
        } */

        public void Clear()
        {
            Array.Clear(_arr);
        }

        public int Sort(IComparer<T>? comparer = null, int algorithm = 0)
        {
            var activeComparer = comparer ?? Comparer<T>.Default;

            if (algorithm == 0) return BubbleSort(activeComparer);
            if (algorithm == 1) return InsertionSort(activeComparer);
            else throw new ArgumentException();
        }
      

        private int BubbleSort(IComparer<T> comparer)
                {
            if (_arr.Length == 0) throw new ArgumentException();
            
                    int comparisonCount = default;
                    int unsorted = Count - 1;
                    bool swapped;
                    while (unsorted > 0)
                    {
                        swapped = false;
                        for (int i = 0; i < unsorted; i++)
                        {
                            var current = _arr[i];
                            var next = _arr[i + 1];

                            comparisonCount++;
                            if (comparer.Compare(current, next) > 0)
                            {
                                T temp = _arr[i];
                                _arr[i] = _arr[i + 1];
                                _arr[i + 1] = temp;

                                swapped = true;
                            }
                        }
                        if (!swapped)                                       // Hvis vi ingen værdier blev byttet efter at have itereret hele listen igennem, så er det fordi den allerede er sorteret. 
                            break;                                          // Stop sorteringen tidligt.

                        unsorted--;
                    }
                    return comparisonCount;
                }
        
        private int InsertionSort(IComparer<T> comparer)
        {
            int count = default;                                            // Vores comparison tæller

            count++;
            if (_arr == null)
                throw new Exception();

            count++;
            if (_arr.Length == 0)
                throw new ArgumentException();


            for (int i = 1; i < Count; i++)
            {
                T key = _arr[i];                                            // Det tal vi vil placere
                int pointer = i - 1;                                        // Vi starter med at kigge til venstre
                                                        
                while (true)
                {
                    count++;
                    if (pointer < 0) break;                                 // Pointer >= 0: Vi må ikke ryge ud over kanten

                    count++;
                    if (comparer.Compare(_arr[pointer], key) < 0) break;    // arr[pointer] < key: Tallet til venstre er mindre end vores key

                    _arr[pointer + 1] = _arr[pointer];                      // Skub det store tal til højre
                    pointer--;                                              // Ryk pointeren til venstre
                }

                                                                            // Når while-løkken stopper (enten pga. start af array eller et mindre tal),
                                                                            // så er "pointer + 1" det korrekte hul til vores key.
                _arr[pointer + 1] = key;
            }
            return count;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", _arr[.._pointer])}]";
        }

        public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            while (i < Count)
            {
                yield return _arr[i];
                i++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
    }
}