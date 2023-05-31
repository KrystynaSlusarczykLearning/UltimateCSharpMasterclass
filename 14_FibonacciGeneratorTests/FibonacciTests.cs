using FibonacciGenerator;
using NUnit.Framework;

namespace FibonacciGeneratorTests;

[TestFixture]
public class FibonacciTests
{
    [TestCase(-1)]
    [TestCase(-5)]
    [TestCase(-100)]
    public void Generate_ShallThrowException_IfNIsSmallerThanZero(
        int n)
    {
        Assert.Throws<ArgumentException>(
            () => Fibonacci.Generate(n));
    }

    [TestCase(47)]
    [TestCase(100)]
    [TestCase(1000)]
    public void Generate_ShallThrowException_IfNIsLargerThan46(
        int n)
    {
        Assert.Throws<ArgumentException>(
            () => Fibonacci.Generate(n));
    }

    [Test]
    public void Generate_ShallProduceEmptySequence_ForNEqualTo0()
    {
        var result = Fibonacci.Generate(0);
        Assert.IsEmpty(result);
    }

    [Test]
    public void Generate_ShallProduceSequenceWith_0_ForNEqualTo1()
    {
        var result = Fibonacci.Generate(1);
        Assert.AreEqual(new int[] { 0 }, result);
    }

    [Test]
    public void Generate_ShallProduceSequenceWith_0_1_ForNEqualTo2()
    {
        var result = Fibonacci.Generate(2);
        Assert.AreEqual(new int[] { 0, 1 }, result);
    }

    [TestCase(3, new int[] {0, 1, 1})]
    [TestCase(5, new int[] {0, 1, 1, 2, 3})]
    [TestCase(10, new int[] {0, 1, 1, 2, 3, 5, 8, 13, 21, 34})]
    public void Generate_ShallProduceValidFibonacciSequence(
        int n, int[] expected)
    {
        var result = Fibonacci.Generate(n);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Generate_ShallProduceSequenceWithLastNumber_1134903170_ForNEqualTo46()
    {
        var result = Fibonacci.Generate(46);
        const int FibonacciNumber46 = 1134903170;
        Assert.AreEqual(FibonacciNumber46, result.Last());
    }
}













//[TestCase(-1)]
//[TestCase(-5)]
//[TestCase(-100)]
//public void Generate_ShallThrowException_IfNIsLessThenZero(int n)
//{
//    Assert.Throws<ArgumentException>(
//        () => Fibonacci.Generate(n));
//}

//[TestCase(47)]
//[TestCase(100)]
//[TestCase(1000)]
//public void Generate_ShallThrowException_IfNIsMoreThan46(int n)
//{
//    Assert.Throws<ArgumentException>(
//        () => Fibonacci.Generate(n));
//}

//[Test]
//public void Generate_ShallCreateEmptySequence_ForNEqualTo0()
//{
//    var result = Fibonacci.Generate(0);
//    Assert.IsEmpty(result);
//}

//[Test]
//public void Generate_ShallCreateSequenceWith_0_ForNEqualTo1()
//{
//    var result = Fibonacci.Generate(1);
//    Assert.AreEqual(new int[] { 0 }, result);
//}

//[Test]
//public void Generate_ShallCreateSequenceWith_0_1_ForNEqualTo2()
//{
//    var result = Fibonacci.Generate(2);
//    Assert.AreEqual(new int[] { 0, 1 }, result);
//}

//[TestCase(3, new int[] { 0, 1, 1 })]
//[TestCase(5, new int[] { 0, 1, 1, 2, 3 })]
//[TestCase(10, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
//public void Generate_ShallCreateValidFibonacciSequence(
//    int n, int[] expected)
//{
//    var result = Fibonacci.Generate(n);
//    Assert.AreEqual(expected, result);
//}

//[TestCase(3)]
//[TestCase(30)]
//[TestCase(46)]
//public void Generate_ShallCreateCollectionOfCountEqualToN(
//    int n)
//{
//    var result = Fibonacci.Generate(n);
//    Assert.AreEqual(n, result.Count());
//}

//[Test]
//public void Generate_ShallCreateSequenceWithLastNumber_1134903170_ForNEqualTo46()
//{
//    var result = Fibonacci.Generate(46);
//    const int fibonacciNumber46 = 1134903170;
//    Assert.AreEqual(fibonacciNumber46, result.Last());
//}