using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Search;

namespace Algorithms.Tests.Search
{
    [TestClass]
    public class LinearSearchTests
    {
        IList<string> _haystack;

        [TestInitialize]
        public void Initialize()
        {
            _haystack = new string[] { "a", "b", "c" };
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Search_NeedleNull_ThrowsException()
        {
            LinearSearch.Search<string>(null, _haystack);
        }

        [TestMethod]
        public void Search_ElementInArray_ReturnsIndex()
        {
            Assert.AreEqual(0, LinearSearch.Search<string>("a", _haystack));
            Assert.AreEqual(1, LinearSearch.Search<string>("b", _haystack));
            Assert.AreEqual(2, LinearSearch.Search<string>("c", _haystack));
        }

        [TestMethod]
        public void Search_ElementNotInArray_ReturnsNull()
        {
            Assert.AreEqual(null, LinearSearch.Search<string>("d", _haystack));
        }
    }
}
