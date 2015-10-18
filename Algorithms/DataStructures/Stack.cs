using System;

namespace Algorithms.DataStructures
{
    public class Stack<T>
    {
        DynamicArray<T> _array;

        public int Count { get { return _array.Count; } }

        public Stack()
        {
            _array = new DynamicArray<T>();
        }

        public void Push(T element)
        {
            _array.Append(element);
        }

        public T Pop()
        {
            ThrowInvalidOperationExceptionIfEmpty("Pop");
            return _array.Pop();
        }

        public T Peek()
        {
            ThrowInvalidOperationExceptionIfEmpty("Peek");
            return _array[Count - 1];
        }

        private void ThrowInvalidOperationExceptionIfEmpty(string methodName)
        {
            string errorMessage = $"Cannot {methodName}() when Count == 0.";

            if (Count == 0)
                throw new InvalidOperationException(errorMessage);
        }
    }
}
