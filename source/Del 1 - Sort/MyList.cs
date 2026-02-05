using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Algoritmer_Projekt
{
    /// <summary>
    /// TODO
    /// Tilføjes indekser
    /// Length property
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyList<T> where T : IComparable<T>, INumber<T>
    {
        private T[] _arr;
        private int _pointer;

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

        public void Sort(int algorithm = 0)
        {

        }
        
        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        private void BubbleSort()
        { 
            throw new NotImplementedException(); 
        }

        private void InsertionSort()
        {
            if (_arr == null || _arr.Length == 0) 
                throw new Exception();

            for (int i = 1; i < _arr.Length; i++)
            {
                T key = _arr[i];      // Det tal vi vil placere
                int pointer = i - 1;   // Vi starter med at kigge til venstre
                int count = default;
                // HER sker magien!
                // Vi kombinerer begge stop-kriterier i én linje:
                // 1. pointer >= 0:      Vi må ikke ryge ud over kanten
                // 2. arr[pointer] > key: Tallet til venstre er større end vores key
                while ( true )
                {
                    count++;
                    if (pointer < 0) break;

                    count++;
                    if (_arr[pointer] < key) break;

                    _arr[pointer + 1] = _arr[pointer]; // Skub det store tal til højre
                    pointer--;                       // Ryk pointeren til venstre
                }

                // Når while-løkken stopper (enten pga. start af array eller et mindre tal),
                // så er "pointer + 1" det korrekte hul til vores key.
                _arr[pointer + 1] = key;
            }
        }
    }
}
