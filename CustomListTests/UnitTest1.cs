using System;
using CustomList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomListTests
{
    [TestClass]
    public class CustomListTests
    {
        // if i add something to a populated customlist, it should go to last index
        [TestMethod]
        public void Add_AddToPopulatedList_ItemShouldGoToLastIndex()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 10;
            int actual;
            // act
            test.Add(8);
            test.Add(10);
            actual = test[test.Count];
            // assert
            Assert.AreEqual(expected, actual);
        }
        // if i add something to customlist whose inner array is full, it should still add the item
        [TestMethod]
        public void Add_AddToFullList_ItemShouldBeAdded()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 16;
            int actual;
            // act
            test.Add(8);
            test.Add(10);
            test.Add(12);
            test.Add(14);
            test.Add(16);
            actual = test[test.Count];
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Add_AddToEmptyList_ItemShouldGoToIndexZero()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 8;
            int actual;
            // act
            test.Add(8);
            actual = test[0];
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Add_AddToEmptyList_CountShouldIncreaseToOne()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 1;
            int actual;
            // act
            test.Add(8);
            actual = test.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
