using NUnit.Framework;

namespace LinkedListTests
{
    [TestFixture]
    public class SinglyLinkedListTests
    {
        [Test]
        public void NewlyCreatedList_ShallBeEmpty()
        {
            var list = new SinglyLinkedList<string>();

            Assert.AreEqual(0, list.Count);
            CollectionAssert.IsEmpty(list);
        }

        [Test]
        public void AddToEmptyList_ShallCreateListOfLength1()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");

            Assert.AreEqual(1, list.Count);
            CollectionAssert.AreEqual(
                new string[] { "a" }, list);
        }

        [Test]
        public void Adding3ItemsToEmptyList_ShallCreateListOfLength3()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(
                new string[] { "a", "b", "c" }, list);
        }

        [Test]
        public void AddingNull_ShallIncludeItInList()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");
            list.Add(null);
            list.Add("c");

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(
                new string?[] { "a", null, "c" }, list);
        }

        [Test]
        public void AddToEndOfEmptyList_ShallCreateListOfLength1()
        {
            var list = new SinglyLinkedList<string>();
            list.AddToEnd("a");

            Assert.AreEqual(1, list.Count);
            CollectionAssert.AreEqual(
                new string[] { "a" }, list);
        }

        [Test]
        public void Adding3ItemsToEndOfEmptyList_ShallCreateListOfLength3()
        {
            var list = new SinglyLinkedList<string>();
            list.AddToEnd("a");
            list.AddToEnd("b");
            list.AddToEnd("c");

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(
                new string[] { "a", "b", "c" }, list);
        }

        [Test]
        public void AddToFrontToEmptyList_ShallCreateListOfLength1()
        {
            var list = new SinglyLinkedList<string>();
            list.AddToFront("a");

            Assert.AreEqual(1, list.Count);
            CollectionAssert.AreEqual(
                new string[] { "a" }, list);
        }

        [Test]
        public void Adding3ItemsToFrontOfEmptyList_ShallCreateListOfLength3()
        {
            var list = new SinglyLinkedList<string>();
            list.AddToFront("a");
            list.AddToFront("b");
            list.AddToFront("c");

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(
                new string[] { "c", "b", "a" }, list);
        }

        [Test]
        public void Clear_ShallNotChangeAnEmptyList()
        {
            var list = new SinglyLinkedList<string>();
            list.Clear();

            Assert.AreEqual(0, list.Count);
            CollectionAssert.IsEmpty(list);
        }

        [Test]
        public void Clear_ShallEmptyTheList()
        {
            var list = new SinglyLinkedList<string>();
            list.AddToFront("a");
            list.AddToFront("b");
            list.AddToFront("c");
            list.Clear();

            Assert.AreEqual(0, list.Count);
            CollectionAssert.IsEmpty(list);
        }

        [Test]
        public void EnumeratingTheList_ShallGiveItsItemsInCorrectOrder()
        {
            var list = new SinglyLinkedList<string>();
            list.AddToFront("a");
            list.AddToFront("b");
            list.AddToFront("c");
            list.Add("d");
            var expectedResults = new string[] { "c", "b", "a", "d" };

            int counter = 0;
            foreach (var item in list)
            {
                Assert.AreEqual(expectedResults[counter], item);
                ++counter;
            }
        }

        [Test]
        public void RemoveOfNonexistentItem_ShallNotChangeTheList_AndReturnFalse()
        {
            var list = new SinglyLinkedList<string>();
            list.AddToFront("a");
            list.AddToFront("b");

            var isRemoved = list.Remove("c");

            Assert.False(isRemoved);
            Assert.AreEqual(2, list.Count);
            CollectionAssert.AreEqual(
                new string[] { "b", "a" }, list);
        }

        [Test]
        public void RemoveOfHead_ShallMakeTheSecondItemNewHead_AndReturnTrue()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");

            var isRemoved = list.Remove("a");

            Assert.True(isRemoved);
            Assert.AreEqual(2, list.Count);
            CollectionAssert.AreEqual(
                new string[] { "b", "c" }, list);
        }

        [Test]
        public void RemoveOfTail_ShallMakeTheSecondToLastItemNewTail_AndReturnTrue()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");

            var isRemoved = list.Remove("c");

            Assert.True(isRemoved);
            Assert.AreEqual(2, list.Count);
            CollectionAssert.AreEqual(
                new string[] { "a", "b" }, list);
        }

        [Test]
        public void RemoveOfEachItem_ShallMakeTheListEmpty()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");

            list.Remove("a");
            list.Remove("b");
            list.Remove("c");

            Assert.AreEqual(0, list.Count);
            CollectionAssert.IsEmpty(list);
        }

        [Test]
        public void RemoveFromTheMiddle_ShallReturnTrue()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");

            var isRemoved = list.Remove("c");

            Assert.True(isRemoved);
            Assert.AreEqual(4, list.Count);
            CollectionAssert.AreEqual(
                new string[] { "a", "b", "d", "e" }, list);
        }

        [Test]
        public void Remove_ShallRemoveFirstInstanceEqualToArgument_AndReturnTrue()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("c");
            list.Add("d");

            var isRemoved = list.Remove("c");

            Assert.True(isRemoved);
            Assert.AreEqual(4, list.Count);
            CollectionAssert.AreEqual(
                new string[] { "a", "b", "c", "d" }, list);
        }

        [Test]
        public void RemoveNull_ShallRemoveFirstNull_AndReturnTrue()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");
            list.Add(null);
            list.Add("c");
            list.Add(null);
            list.Add("e");

            var isRemoved = list.Remove(null);

            Assert.True(isRemoved);
            Assert.AreEqual(4, list.Count);
            CollectionAssert.AreEqual(
                new string?[] { "a", "c", null, "e" }, list);
        }

        [Test]
        public void CopyTo_ShallCopyAllItemsToArray_IfSomeSpareRoomLeft()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");
            list.Add(null);
            list.Add("c");
            list.Add("e");

            var array = new string[7];
            list.CopyTo(array, 2);

            CollectionAssert.AreEqual(
                new string?[] { null, null, "a", null, "c", "e", null },
                array);
        }

        [Test]
        public void CopyTo_ShallCopyAllItemsToArray_IfNoSpareRoomLeft()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");
            list.Add(null);
            list.Add("c");
            list.Add("e");

            var array = new string[6];
            list.CopyTo(array, 2);

            CollectionAssert.AreEqual(
                new string?[] { null, null, "a", null, "c", "e" },
                array);
        }

        [Test]
        public void CopyTo_ShallThrow_ForNullArray()
        {
            var list = new SinglyLinkedList<string>();

            Assert.Throws<ArgumentNullException>(
                () => list.CopyTo(null!, 2));
        }

        [Test]
        public void CopyTo_ShallThrow_ForNegativeIndex()
        {
            var list = new SinglyLinkedList<string>();

            var array = new string[7];
            Assert.Throws<ArgumentOutOfRangeException>(
                () => list.CopyTo(array, -1));
        }

        [Test]
        public void CopyTo_ShallThrow_ForIndexAfterArraysEnd()
        {
            var list = new SinglyLinkedList<string>();

            var array = new string[7];
            Assert.Throws<ArgumentOutOfRangeException>(
                () => list.CopyTo(array, 11));
        }

        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void CopyTo_ShallThrow_IfArrayIsTooShortForAllItems(
            int arrayLength)
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");
            list.Add(null);
            list.Add("c");
            list.Add("e");

            var array = new string[arrayLength];
            Assert.Throws<ArgumentException>(
                () => list.CopyTo(array, 2));
        }

        [TestCase("a")]
        [TestCase("c")]
        [TestCase("e")]
        [TestCase(null)]
        public void Contains_ShallReturnTrue_IfItemExistsInList(
            string itemToCheck)
        {
            var list = new SinglyLinkedList<string>();
            list.Add("a");
            list.Add(null);
            list.Add("c");
            list.Add("e");

            Assert.True(list.Contains(itemToCheck));
        }

        [TestCase("a")]
        [TestCase("b")]
        [TestCase("c")]
        [TestCase(null)]
        public void Contains_ShallReturnFalse_IfItemDoesNotExistInList(
           string itemToCheck)
        {
            var list = new SinglyLinkedList<string>();
            list.Add("e");

            Assert.False(list.Contains(itemToCheck));
        }

        [Test]
        public void ShallWorkProperlyForNonNullableValueTypes()
        {
            var list = new SinglyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(
                new int[] { 1, 2, 3 }, list);
        }

        [Test]
        public void ShallWorkProperlyForNullableValueTypes()
        {
            var list = new SinglyLinkedList<DateTime?>();
            var date1 = new DateTime(2024, 5, 1);
            var date2 = new DateTime(2024, 5, 2);

            list.Add(date1);
            list.Add(null);
            list.Add(date2);

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(
                new DateTime?[] { date1, null, date2 }, list);
        }
    }
}
