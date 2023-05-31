using Moq;
using NUnit.Framework;

[TestFixture]
[SetCulture("es-ES")]
public class DatesFormatterTests
{
    [TestCase(2024, 1, 5, "5/1/2024")]
    [TestCase(1900, 12, 3, "3/12/1900")]
    [TestCase(1, 1, 1, "1/1/0001")]
    public void FormatCurrentDate_ShallFormatTodaysDate_AsShortDate(
        int year, int month, int day, string expected)
    {
        var dateTimeMock = new Mock<IDateTime>();
        dateTimeMock.Setup(mock => mock.Now).Returns(new DateTime(year, month, day));

        var result = new DatesFormatter(dateTimeMock.Object).FormatCurrentDate();

        Assert.AreEqual(expected, result);
    }
}
