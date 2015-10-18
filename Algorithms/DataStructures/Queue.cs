using System;

namespace Algorithms.DataStructures
{
    public class Queue<T>
    {
        Node _head;
        Node _tail;
        int _count;

        public int Count { get { return _count; } }

        public Queue()
        {
        }

        public void Enqueue(T item)
        {
            var newNode = new Node { Item = item };

            if (Count == 0)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }

            _count++;
        }

        public T Dequeue()
        {
            ThrowInvalidOperationExceptionIfEmpty("Dequeue");
            T item = _head.Item;
            _head = _head.Next;
            _count--;
            return item;
        }

        public T Peek()
        {
            ThrowInvalidOperationExceptionIfEmpty("Peek");
            return _head.Item;
        }

        private void ThrowInvalidOperationExceptionIfEmpty(string methodName)
        {
            string errorMessage = $"Cannot {methodName}() when Count == 0.";

            if (Count == 0)
                throw new InvalidOperationException(errorMessage);
        }

        class Node
        {
            public Node Next { get; set; }
            public T Item { get; set; }
        }
    }
}
