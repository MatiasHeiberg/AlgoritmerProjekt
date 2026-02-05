using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmer_Projekt
{
    public class MyList<T> where T : IComparable<T>
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
            throw new NotImplementedException(); 
        }
    }
}
