using Moq;
using NUnit.Framework;

namespace _15_PasswordGeneratorTests;

[TestFixture]
public class PasswordGeneratorTests
{
    private PasswordGenerator _cut;
    private Mock<IRandom> _randomMock;

    [SetUp]
    public void SetUp()
    {
        _randomMock = new Mock<IRandom>();
        _cut = new PasswordGenerator(_randomMock.Object);
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-100)]
    public void MinLengthSmallerThan1_ShallThrowException(
        int minLength)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () => _cut.Generate(minLength, 10, true));
    }

    [TestCase(10)]
    [TestCase(5)]
    [TestCase(100)]
    public void MinLengthLargerThanMaxLength_ShallThrowException(
        int minLength)
    {
        const int MaxLength = 4;
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () => _cut.Generate(minLength, MaxLength, false));
    }

    [TestCase(1,1)]
    [TestCase(5,5)]
    [TestCase(3,4)]
    [TestCase(3,10)]
    [TestCase(10,20)]
    public void CorrectMinLengthAndMaxLength_ShallNotThrowException(
        int minLength, int maxLength)
    {
        Assert.DoesNotThrow(
            () => _cut.Generate(minLength, maxLength, false));
    }

    [Test]
    public void ShallGeneratePassword_WithoutSpecialCharacters()
    {
        const int MinLength = 3;
        const int MaxLength = 5;

        SetupRandomToGeneratePasswordLengthEqualTo(4, MinLength, MaxLength);
        SetupRandomToSelectCharactersAtIndexes(0, 1, 2, 3);

        var result = _cut.Generate(MinLength, MaxLength, false);

        Assert.AreEqual("ABCD", result);
    }

    [Test]
    public void ShallGeneratePassword_WithSpecialCharacters()
    {
        const int MinLength = 1;
        const int MaxLength = 7;

        SetupRandomToGeneratePasswordLengthEqualTo(6, MinLength, MaxLength);
        SetupRandomToSelectCharactersAtIndexes(0, 10, 15, 30, 40, 45);

        var result = _cut.Generate(MinLength, MaxLength, true);

        Assert.AreEqual("AKP4%)", result);
    }

    private void SetupRandomToGeneratePasswordLengthEqualTo(
        int passwordLengthToBeReturned, int minLength, int maxLength)
    {
        _randomMock
            .Setup(mock => mock.Next(minLength, maxLength + 1))
            .Returns(passwordLengthToBeReturned);
    }

    private void SetupRandomToSelectCharactersAtIndexes(params int[] indexes)
    {
        var sequence = _randomMock.SetupSequence(mock => mock.Next(It.IsAny<int>()));

        foreach(var index in indexes)
        {
            sequence = sequence.Returns(index);
        }
    }
}
