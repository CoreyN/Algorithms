using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Algorithms.Tests.DataStructures
{
    [TestClass]
    public class StackTests
    {
        Stack<int> _stack;

        [TestInitialize]
        public void Initialize()
        {
            _stack = new Stack<int>();
        }

        [TestMethod]
        public void EmptyStack_CountWorks()
        {
            Assert.AreEqual(0, _stack.Count);
        }

        [TestMethod]
        public void EmptyStack_PushElements_CountWorks()
        {
            _stack.Push(1);
            Assert.AreEqual(1, _stack.Count);

            _stack.Push(1);
            Assert.AreEqual(2, _stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyStack_Peek_ThrowsInvalidOperationException()
        {
            _stack.Peek();
        }

        [TestMethod]
        public void StackWithElements_Peek_Works()
        {
            _stack.Push(1);
            Assert.AreEqual(1, _stack.Peek());

            _stack.Push(2);
            Assert.AreEqual(2, _stack.Peek());
        }

        [TestMethod]
        public void StackWithElements_Pop_Works()
        {
            PushElements(new int[] { 1, 2, 3 });

            Assert.AreEqual(3, _stack.Pop());
            Assert.AreEqual(2, _stack.Pop());
            Assert.AreEqual(1, _stack.Pop());
        }

        [TestMethod]
        public void StackWithElements_PoppingElements_DecreasesCount()
        {
            PushElements(new int[] { 1, 2, 3 });

            _stack.Pop();
            Assert.AreEqual(2, _stack.Count);

            _stack.Pop();
            Assert.AreEqual(1, _stack.Count);

            _stack.Pop();
            Assert.AreEqual(0, _stack.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyStack_Pop_ThrowsInvalidOperationException()
        {
            _stack.Pop();
        }

        private void PushElements(int[] elements)
        {
            foreach (int n in elements)
                _stack.Push(n);
        }
    }
}
