using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Search;

namespace Algorithms.Tests.Search
{
    [TestClass]
    public class BinarySearchTests
    {
        IList<string> _haystack;

        [TestInitialize]
        public void Initialize()
        {
            _haystack = new string[] { "a", "b", "c", "d", "e" };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Search_NeedleNull_ThrowsException()
        {
            BinarySearch.Search(null, _haystack);
        }

        [TestMethod]
        public void Search_ElementInArray_ReturnsIndex()
        {
            Assert.AreEqual(0, BinarySearch.Search("a", _haystack));
            Assert.AreEqual(1, BinarySearch.Search("b", _haystack));
            Assert.AreEqual(2, BinarySearch.Search("c", _haystack));
            Assert.AreEqual(3, BinarySearch.Search("d", _haystack));
            Assert.AreEqual(4, BinarySearch.Search("e", _haystack));
        }

        [TestMethod]
        public void Search_ElementNotInArray_ReturnsNull()
        {
            Assert.AreEqual(null, BinarySearch.Search("f", _haystack));
        }
    }
}
