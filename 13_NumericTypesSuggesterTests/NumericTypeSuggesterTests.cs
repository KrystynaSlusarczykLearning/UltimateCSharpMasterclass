using NumericTypesSuggester;
using NUnit.Framework;
using System.Numerics;

[TestFixture]
public class NumericTypeSuggesterTests
{
    [Test]
    public void ShallSuggestBigInteger_IfMaxAboveMaxLong()
    {
        var result = NumericTypeSuggester.GetName(
            -1,
            new BigInteger(long.MaxValue) + 1,
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.BigInteger, result);
    }

    [Test]
    public void ShallSuggestBigInteger_IfMinBelowMinLong()
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(long.MinValue) - 1,
            0,
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.BigInteger, result);
    }

    [Test]
    public void ShallSuggestULong_IfMaxAboveUInt_AndMinZero()
    {
        var result = NumericTypeSuggester.GetName(
            0,
            new BigInteger(uint.MaxValue) + 1,
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.ULong, result);
    }

    [Test]
    public void ShallSuggestUInt_IfMaxAboveUShort_AndMinZero()
    {
        var result = NumericTypeSuggester.GetName(
            0,
            new BigInteger(ushort.MaxValue) + 1,
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.UInt, result);
    }

    [Test]
    public void ShallSuggestUShort_IfMaxAboveByte_AndMinZero()
    {
        var result = NumericTypeSuggester.GetName(
            0,
            new BigInteger(byte.MaxValue) + 1,
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.UShort, result);
    }

    [Test]
    public void ShallSuggestByte_IfMaxBelowUShort_AndMinZero()
    {
        var result = NumericTypeSuggester.GetName(
            0,
            new BigInteger(byte.MaxValue),
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.Byte, result);
    }

    [Test]
    public void ShallSuggestLong_IfMaxAboveInt()
    {
        var result = NumericTypeSuggester.GetName(
            -1,
            new BigInteger(uint.MaxValue) + 1,
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.Long, result);
    }

    [Test]
    public void ShallSuggestLong_IfMinBelowInt()
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(int.MinValue) - 1,
            1,
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.Long, result);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(short.MaxValue)]
    [TestCase(int.MaxValue)]
    public void ShallSuggestDecimal_IfMustBePrecise(long value)
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(-value),
            new BigInteger(value),
            false,
            true);

        Assert.AreEqual(
            NumericTypeSuggester.Decimal, result);
    }

    [Test]
    public void ShallSuggestDecimal_ForExtremeDecimalValue_IfMustBePrecise()
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(decimal.MinValue),
            new BigInteger(decimal.MaxValue),
            false,
            true);

        Assert.AreEqual(
            NumericTypeSuggester.Decimal, result);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(short.MaxValue)]
    [TestCase(int.MaxValue)]
    public void ShallSuggestFloat(long value)
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(-value),
            new BigInteger(value),
            false,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.Float, result);
    }

    [Test]
    public void ShallSuggestFloat_ForExtremeFloatValue()
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(float.MinValue),
            new BigInteger(float.MaxValue),
            false,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.Float, result);
    }

    [Test]
    public void ShallSuggestDouble_IfLessThanMinFloat()
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger((double)float.MinValue * 2),
            0,
            false,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.Double, result);
    }

    [Test]
    public void ShallSuggestDouble_IfMoreThanMaxFloat()
    {
        var result = NumericTypeSuggester.GetName(
            0,
            new BigInteger((double)float.MaxValue * 2),
            false,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.Double, result);
    }

    [Test]
    public void ShallSuggestDouble_ForExtremeDoubleValue()
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(double.MinValue),
            new BigInteger(double.MaxValue),
            false,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.Double, result);
    }

    [TestCase(long.MaxValue)]
    [TestCase(2147483648)] //max int + 1
    [TestCase(999999999999999999)]
    public void ShallSuggestLong(long value)
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(-value),
            new BigInteger(value),
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.Long, result);
    }

    [TestCase(int.MaxValue)]
    [TestCase(32768)] //max short + 1
    [TestCase(250000)]
    public void ShallSuggestInt(long value)
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(-value),
            new BigInteger(value),
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.Int, result);
    }

    [TestCase(short.MaxValue)]
    [TestCase(128)] //max sbyte + 1
    [TestCase(4000)]
    public void ShallSuggestShort(long value)
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(-value),
            new BigInteger(value),
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.Short, result);
    }

    [TestCase(sbyte.MaxValue)]
    [TestCase(1)]
    public void ShallSuggestSbyte(long value)
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(-value),
            new BigInteger(value),
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.SByte, result);
    }

    [TestCase(ulong.MaxValue)]
    [TestCase((ulong)4294967296)] //max uint + 1
    [TestCase(9999999999999999999)]
    public void ShallSuggestULong(ulong value)
    {
        var result = NumericTypeSuggester.GetName(
            0,
            new BigInteger(value),
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.ULong, result);
    }

    [TestCase(uint.MaxValue)]
    [TestCase(65536)] //max ushort + 1
    [TestCase(80000)]
    public void ShallSuggestUInt(long value)
    {
        var result = NumericTypeSuggester.GetName(
            0,
            new BigInteger(value),
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.UInt, result);
    }

    [TestCase(ushort.MaxValue)]
    [TestCase(266)] //max byte + 1
    [TestCase(40000)]
    public void ShallSuggestUShort(long value)
    {
        var result = NumericTypeSuggester.GetName(
            0,
            new BigInteger(value),
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.UShort, result);
    }

    [TestCase(byte.MaxValue)]
    [TestCase(140)]
    public void ShallSuggestByte(long value)
    {
        var result = NumericTypeSuggester.GetName(
            0,
            new BigInteger(value),
            true,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.Byte, result);
    }

    [Test]
    public void ShallReturnImpossible_IfMustBePreciseButIsLargerThanMaxDecimal()
    {
        var result = NumericTypeSuggester.GetName(
            0,
            new BigInteger(decimal.MaxValue) * 2,
            false,
            true);

        Assert.AreEqual(
            NumericTypeSuggester.ImpossibleRepresentation, result);
    }

    [Test]
    public void ShallReturnImpossible_IfMustBePreciseButIsSmallerThanMinDecimal()
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(decimal.MinValue) * 2,
            0,
            false,
            true);

        Assert.AreEqual(
            NumericTypeSuggester.ImpossibleRepresentation, result);
    }

    [Test]
    public void ShallReturnImpossible_IfNonIntegral_ButLargerThanMaxDouble()
    {
        var result = NumericTypeSuggester.GetName(
            0,
            new BigInteger(double.MaxValue) * 2,
            false,
            false);

        Assert.AreEqual(
            NumericTypeSuggester.ImpossibleRepresentation, result);
    }

    [Test]
    public void ShallReturnImpossible_IfNonIntegral_ButSmallerThanMinDouble()
    {
        var result = NumericTypeSuggester.GetName(
            new BigInteger(double.MinValue) * 2,
            0,
            false,
            true);

        Assert.AreEqual(
            NumericTypeSuggester.ImpossibleRepresentation, result);
    }
}