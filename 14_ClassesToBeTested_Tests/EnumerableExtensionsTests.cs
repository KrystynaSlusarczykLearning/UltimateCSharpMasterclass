using NUnit.Framework;

[TestFixture]
public class EnumerableExtensionsTests
{
    [Test]
    public void SumOfEvenNumbers_ShallReturnZero_ForEmptyCollection()
    {
        var input = Enumerable.Empty<int>();

        var result = input.SumOfEvenNumbers();

        Assert.AreEqual(0, result);
    }

    //[TestCase(new int[] { 3, 1, 4, 6, 9 }, 10)]
    //[TestCase(new List<int> { 100, 200, 1 }, 300)]
    [TestCaseSource(nameof(GetSumOfEvenNumbersTestCases))]
    public void SumOfEvenNumbers_ShallReturnNonZeroResult_IfEvenNumbersArePresent(
        IEnumerable<int> input, int expected)
    {
        var result = input.SumOfEvenNumbers();

        var inputAsString = string.Join(", ", input);
        Assert.AreEqual(expected, result, $"For input {inputAsString} " +
            $"the result shall be {expected} but it was {result}.");
    }

    private static IEnumerable<object> GetSumOfEvenNumbersTestCases()
    {
        return new[]
        {
             new object[] { new int[] { 3, 1, 4, 6, 9 }, 10 },
             new object[] { new List<int> { 100, 200, 1 }, 300 },
             new object[] { new List<int> { -3, -5, 0 }, 0 },
             new object[] { new List<int> { -4, -8 }, -12 },
         };
    }

    [TestCase(8)]
    [TestCase(-8)]
    [TestCase(6)]
    [TestCase(0)]
    public void SumOfEvenNumbers_ShallReturnValueOfTheOnlyItem_IfItIsEven(int number)
    {
        var input = new int[] { number };

        var result = input.SumOfEvenNumbers();

        Assert.AreEqual(number, result);
    }

    [TestCase(1)]
    [TestCase(-7)]
    [TestCase(33)]
    public void SumOfEvenNumbers_ShallReturnZero_IfOnlyNumberInInputIsOdd(int number)
    {
        var input = new int[] { number };

        var result = input.SumOfEvenNumbers();

        Assert.AreEqual(0, result);
    }

    [Test]
    public void SumOfEvenNumbers_ShallThrowException_ForNullInput()
    {
        IEnumerable<int>? input = null;

        var exception = Assert.Throws<ArgumentNullException>(
            () => input!.SumOfEvenNumbers());
    }

    [Test]
    public void SomeTest()
    {
        bool someVariable = true;
        Assert.True(someVariable);
        //Assert.False(someVariable); //will fail

        Assert.AreEqual(true, someVariable);

        //Assert.Null(someVariable); //will fail
        Assert.NotNull(someVariable);

        var collection1 = new List<int> { 1, 2, 3 };
        var collection2 = new List<int> { 3, 2, 1 };

        CollectionAssert.AreEquivalent(collection2, collection1);

        //both will fail, as the order is different
        //if it was the same, both would pass
        //Assert.AreEqual(collection2, collection1);
        //CollectionAssert.AreEqual(collection2, collection1);
    }
}
