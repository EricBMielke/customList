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
            actual = test[1];
            // assert
            Assert.AreEqual(expected, actual);
        }
        // if i add something to customlist whose inner array is full, it should still add the item
        [TestMethod]
        public void Add_AddToFullList_ItemShouldBeAdded()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 18;
            int actual;
            // act
            test.Add(8);
            test.Add(10);
            test.Add(12);
            test.Add(14);
            test.Add(16);
            test.Add(18);
            actual = test[5];
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
        // if i remove a specific value in a list, the specific value should not be part of the list
        [TestMethod]
        public void Remove_SubtractFromPopulatedList_SpecificSingularInstanceWillBeRemoved()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 8;
            int actual;
            // act
            test.Add(10);
            test.Add(8);
            test.Remove(10);
            actual = test[0];
            // assert
            Assert.AreEqual(expected, actual);
        }
        // if i remove a specific value(that occupies more than one index), the first value will not be part of the list
        [TestMethod]
        public void Remove_SubtractFromPopulatedListWithSameValueInMultipleIndexes_SpecificSingularInstanceWillBeRemoved()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 10;
            int actual;
            // act
            test.Add(10);
            test.Add(10);
            test.Add(8);
            test.Remove(10);
            actual = test[0];
            // assert
            Assert.AreEqual(expected, actual);
        }

        // if i remove a specific value, the size of the list will reduce by one
        [TestMethod]
        public void Remove_SubtractFromPopulatedList_ListSizeReducesByOne()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 8;
            int actual;
            // act
            test.Add(10);
            test.Add(8);
            test.Remove(10);
            actual = test[0];
            // assert
            Assert.AreEqual(expected, actual);
        }
        // if i remove a specific value that doesn't exist, the list will remain the same size
        [TestMethod]
        public void Remove_SubtractFromPopulatedListWithNotExistentValue_ListSaysTheSameSize()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 12;
            int actual;
            // act
            test.Add(12);
            test.Add(12);
            test.Add(12);
            test.Add(12);
            test.Add(12);
            test.Remove(10);
            actual = test[4];
            // assert
            Assert.AreEqual(expected, actual);
        }
        // if i remove a specific value of an empty list, an error is not thrown
        [TestMethod]
        public void Remove_SubtractFromEmptyList_ListRemainsEmpty()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 0;
            int actual;
            // act
            test.Remove(10);
            actual = test.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}