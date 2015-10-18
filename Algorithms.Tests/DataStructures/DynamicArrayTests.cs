using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Algorithms.Tests.DataStructures
{
    [TestClass]
    public class DynamicArrayTests
    {
        DynamicArray<int> _dynamicArray;

        [TestInitialize]
        public void Initialize()
        {
            _dynamicArray = new DynamicArray<int>();
        }

        [TestMethod]
        public void DynamicArray_AddItem_CanIndexIt()
        {
            _dynamicArray.Append(1);
                
            Assert.AreEqual(1, _dynamicArray[0]);
        }

        [TestMethod]
        public void DynamicArray_AddItems_CanIndexThem()
        {
            _dynamicArray.Append(1);
            _dynamicArray.Append(2);
            _dynamicArray.Append(3);
            _dynamicArray.Append(4);

            Assert.AreEqual(1, _dynamicArray[0]);
            Assert.AreEqual(2, _dynamicArray[1]);
            Assert.AreEqual(3, _dynamicArray[2]);
            Assert.AreEqual(4, _dynamicArray[3]);
        }

        [TestMethod]
        public void DynamicArray_SetByIndex_Works()
        {
            _dynamicArray.Append(1);
            _dynamicArray.Append(2);

            _dynamicArray[0] = 11;
            _dynamicArray[1] = 12;

            Assert.AreEqual(11, _dynamicArray[0]);
            Assert.AreEqual(12, _dynamicArray[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DynamicArray_SetByIndexOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            _dynamicArray[0] = 2;

            Assert.AreEqual(2, _dynamicArray[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DynamicArray_Pop_ThrowsIfEmpty()
        {
            _dynamicArray.Pop();
        }

        [TestMethod]
        public void DynamicArray_Pop_ReturnsCorrectItem()
        {
            _dynamicArray.Append(1);
            _dynamicArray.Append(2);
            _dynamicArray.Append(3);

            Assert.AreEqual(3, _dynamicArray.Pop());
            Assert.AreEqual(2, _dynamicArray.Pop());
            Assert.AreEqual(1, _dynamicArray.Pop());
        }

        [TestMethod]
        public void DynamicArray_Pop_DecrementsCount()
        {
            _dynamicArray.Append(1);
            _dynamicArray.Append(2);
            _dynamicArray.Append(3);

            _dynamicArray.Pop();
            Assert.AreEqual(2, _dynamicArray.Count);

            _dynamicArray.Pop();
            Assert.AreEqual(1, _dynamicArray.Count);

            _dynamicArray.Pop();
            Assert.AreEqual(0, _dynamicArray.Count);
        }

        [TestMethod]
        public void DynamicArray_ManyPops_DecreaseBufferSize()
        {
            for (int i = 0; i < 20; i++)
                _dynamicArray.Append(i);

            for (int i = 0; i < 20; i++)
                _dynamicArray.Pop();

            Assert.IsTrue(_dynamicArray.BufferSize <= 4);
        }
    }
}
