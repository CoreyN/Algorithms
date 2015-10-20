using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorts;

namespace Algorithms.Tests.Sorts
{
    [TestClass]
    public class SelectionSortTests
    {
        int[] _array;
        int[] _actualSortedArray;

        [TestInitialize]
        public void Initialize()
        {
            _array = new int[] { 1, -2, 5, 12, -99};
            _actualSortedArray = new int[] { -99, -2, 1, 5, 12 };
        }

        [TestMethod]
        public void TestSelectionSort()
        {
            var sortedA = GetSortedArray(_array);
            AssertArraysEqual(sortedA, _actualSortedArray);
        }

        private int[] GetSortedArray(int[] array)
        {
            var newArray = new int[array.Length];
            Array.Copy(array, newArray, array.Length);
            SelectionSort.Sort(newArray);
            return newArray;
        }

        private void AssertArraysEqual(int[] a, int[] b)
        {
            Assert.IsTrue(a.SequenceEqual(b), "Arrays are not equal.");
        }
    }
}
