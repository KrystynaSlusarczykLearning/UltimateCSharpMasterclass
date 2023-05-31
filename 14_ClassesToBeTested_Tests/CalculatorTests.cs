using NUnit.Framework;

[TestFixture]
public class CalculatorTests
{
    [TestCase(1, 2, 3)]
    [TestCase(1, -1, 0)]
    [TestCase(0, 0, 0)]
    [TestCase(100, -50, 50)]
    [TestCase(11, 12, 23)]
    public void Sum_ShallAddNumbersCorrectly(
        int a, int b, int expected)
    {
        var result = Calculator.Sum(a, b);
        Assert.AreEqual(expected, result,
            $"Adding {a} to {b} shall give {expected}, " +
            $"but the result was {result}.");
    }
}