using System;

namespace Algorithms.DataStructures
{
    public class DynamicArray<T>
    {
        T[] _items;
        int _count;

        public DynamicArray()
        {
            _items = new T[1];
            _count = 0;
        }

        public void Append(T item)
        {
            IncreaseSizeIfFull();
            InsertItemAtEnd(item);
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Tried to Pop() when Count == 0.");

            T item = PopItem();
            DecreaseBufferSizeIfItemsTooBig();
            return item;
        }

        public T this[int key]
        {
            get
            {
                return _items[key];
            }
            set
            {
                if (key >= _count)
                    throw new ArgumentOutOfRangeException();

                _items[key] = value;
            }
        }

        public int Count
        {
            get { return _count; }
        }

        public int BufferSize
        {
            get { return _items.Length; }
        }

        private void IncreaseSizeIfFull()
        {
            if (_count == _items.Length)
                ResetArraySize();
        }

        private void ResetArraySize()
        {
            int newSize = _count * 2 > 0 ? _count * 2 : 1; 

            T[] newArray = new T[newSize];
            Array.Copy(_items, newArray, _count);
            _items = newArray;
        }

        private void InsertItemAtEnd(T item)
        {
            _items[_count] = item;
            _count++;
        }

        private T PopItem()
        {
            T item = _items[_count - 1];
            _count--;

            DecreaseBufferSizeIfItemsTooBig();

            return item;
        }

        private void DecreaseBufferSizeIfItemsTooBig()
        {
            if (BufferSize > 4 * Count)
                ResetArraySize();
        }
    }
}
