using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Algorithms.Tests.DataStructures
{
    [TestClass]
    public class QueueTests
    {
        Queue<int> _queue;

        [TestInitialize]
        public void Initialize()
        {
            _queue = new Queue<int>();
        }

        [TestMethod]
        public void EmptyQueue_CountWorks()
        {
            Assert.AreEqual(0, _queue.Count);
        }

        [TestMethod]
        public void EmptyQueue_EnqueueElements_CountWorks()
        {
            _queue.Enqueue(1);
            Assert.AreEqual(1, _queue.Count);

            _queue.Enqueue(1);
            Assert.AreEqual(2, _queue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyQueue_Peek_ThrowsInvalidOperationException()
        {
            _queue.Peek();
        }

        [TestMethod]
        public void Queue_Peek_Works()
        {
            _queue.Enqueue(1);
            Assert.AreEqual(1, _queue.Peek());
            Assert.AreEqual(1, _queue.Count);

            _queue.Enqueue(2);
            Assert.AreEqual(1, _queue.Peek());
            Assert.AreEqual(2, _queue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyQueue_Dequeue_ThrowsInvalidOperationException()
        {
            _queue.Dequeue();
        }

        [TestMethod]
        public void QueueWithElements_Dequeue_Works()
        {
            EnqueueElements(new int[] { 1, 2, 3 });

            Assert.AreEqual(1, _queue.Dequeue());
            Assert.AreEqual(2, _queue.Dequeue());
            Assert.AreEqual(3, _queue.Dequeue());
        }

        [TestMethod]
        public void StackWithElements_PoppingElements_DecreasesCount()
        {
            EnqueueElements(new int[] { 1, 2, 3 });

            _queue.Dequeue();
            Assert.AreEqual(2, _queue.Count);

            _queue.Dequeue();
            Assert.AreEqual(1, _queue.Count);

            _queue.Dequeue();
            Assert.AreEqual(0, _queue.Count);
        }

        private void EnqueueElements(int[] elements)
        {
            elements.ToList().ForEach(e => _queue.Enqueue(e));
        }
    }
}
