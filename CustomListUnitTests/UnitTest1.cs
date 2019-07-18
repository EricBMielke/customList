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
        [TestMethod]
        public void Override_MultipleIntToString_IntsInOneString()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            string expected = "4,6";
            string actual;
            // act
            test.Add(4);
            test.Add(6);
            actual = test.ToString();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Override_MultipleStringsToString_StringsInOneString()
        {
            // arrange
            CustomList<string> test = new CustomList<string>();
            string expected = "turtle,turkey";
            string actual;
            // act
            test.Add("turtle");
            test.Add("turkey");
            actual = test.ToString();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Override_IntToString_IntBecomesString()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            string expected = "10";
            string actual;
            // act
            test.Add(10);
            actual = test.ToString();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Override_DoubleToString_DoubleBecomesString()
        {
            // arrange
            CustomList<double> test = new CustomList<double>();
            string expected = "10.22";
            string actual;
            // act
            test.Add(10.22);
            actual = test.ToString();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Override_StringToString_StringStaysString()
        {
            // arrange
            CustomList<string> test = new CustomList<string>();
            string expected = "JohnnyBravo";
            string actual;
            // act
            test.Add("JohnnyBravo");
            actual = test.ToString();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Overload_AddTwoCustomLists_IndexReflectsBothListsAdded()
        {
            // arrange
            CustomList<int> test1 = new CustomList<int>();
            CustomList<int> test2 = new CustomList<int>();
            int expected = 6;
            // act
            test1.Add(1);
            test1.Add(3);
            test1.Add(5);
            test2.Add(2);
            test2.Add(4);
            test2.Add(6);
            CustomList<int> result = test1 + test2;
            int actual = result[5];
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Overload_AddTwoCustomLists_IndexesAreAddedInTheProperOrder()
        {
            // arrange
            CustomList<int> test1 = new CustomList<int>();
            CustomList<int> test2 = new CustomList<int>();
            int expected = 2;
            // act
            test1.Add(1);
            test1.Add(3);
            test1.Add(5);
            test2.Add(2);
            test2.Add(4);
            test2.Add(6);
            CustomList<int> result = test1 + test2;
            int actual = result[3];
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Overload_AddTwoCustomLists_TwoEmptyListsCreateNewEmptyList()
        {
            // arrange
            CustomList<int> test1 = new CustomList<int>();
            CustomList<int> test2 = new CustomList<int>();
            int expected = 0;
            // act
            CustomList<int> result = test1 + test2;
            int actual = result.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Overload_AddTwoCustomLists_TwoListsTogetherGoBeyondCapacityAndNewListUpdatesCapacity()
        {
            // arrange
            CustomList<int> test1 = new CustomList<int>();
            CustomList<int> test2 = new CustomList<int>();
            int expected = 6;
            // act
            test1.Add(1);
            test1.Add(3);
            test1.Add(5);
            test1.Add(7);
            test1.Add(9);
            test1.Add(11);
            test2.Add(2);
            test2.Add(4);
            test2.Add(6);
            test2.Add(8);
            test2.Add(10);
            test2.Add(12);
            CustomList<int> result = test1 + test2;
            int actual = result[8];
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Overload_ZipTwoListsTogether_CheckFirstIndexIsFromSecondList()
        {
            // arrange
            CustomList<int> test1 = new CustomList<int>();
            CustomList<int> test2 = new CustomList<int>();
            int expected = 2;
            // act
            test1.Add(1);
            test1.Add(3);
            test1.Add(5);
            test2.Add(2);
            test2.Add(4);
            test2.Add(6);
            CustomList<int> result = test1.Zip(test2);
            int actual = result[1];
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Overload_ZipTwoListsTogether_CheckNoIndexesAreDropped()
        {
            // arrange
            CustomList<int> test1 = new CustomList<int>();
            CustomList<int> test2 = new CustomList<int>();
            int expected = 6;
            // act
            test1.Add(1);
            test1.Add(3);
            test1.Add(5);
            test2.Add(2);
            test2.Add(4);
            test2.Add(6);
            CustomList<int> result = test1.Zip(test2);
            int actual = result[5];
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Overload_ZipTwoListsTogether_EmptyListAndPopulatedListStillKeepProperOrder()
        {
            // arrange
            CustomList<int> test1 = new CustomList<int>();
            CustomList<int> test2 = new CustomList<int>();
            int expected = 5;
            // act
            test1.Add(1);
            test1.Add(3);
            test1.Add(5);
            CustomList<int> result = test1.Zip(test2);
            int actual = result[2];
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Overload_ZipTwoListsTogether_TwoEmptyListsDontThrowError()
        {
            // arrange
            CustomList<int> test1 = new CustomList<int>();
            CustomList<int> test2 = new CustomList<int>();
            int expected = 0;
            // act
            CustomList<int> result = test1.Zip(test2);
            int actual = result.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Overload_ZipTwoListsTogether_TwoListsDifferentSizeKeepOrder()
        {
            // arrange
            CustomList<int> test1 = new CustomList<int>();
            CustomList<int> test2 = new CustomList<int>();
            int expected = 3;
            // act
            test1.Add(1);
            test1.Add(3);
            test1.Add(5);
            test2.Add(2);
            CustomList<int> result = test1.Zip(test2);
            int actual = result[2];
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Overload_ZipTwoListsTogether_TwoListsDifferentSizeKeepOrderOtherVariation()
        {
            // arrange
            CustomList<int> test1 = new CustomList<int>();
            CustomList<int> test2 = new CustomList<int>();
            int expected = 6;
            // act
            test1.Add(1);
            test1.Add(3);
            test1.Add(5);
            test2.Add(2);
            test2.Add(4);
            test2.Add(6);
            test2.Add(8);
            CustomList<int> result = test1.Zip(test2);
            int actual = result[5];
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}