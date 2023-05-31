using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("14_ClassesToBeTested_Tests")]

internal static class EnumerableExtensions
{
    public static int SumOfEvenNumbers(
        this IEnumerable<int> numbers)
    {
        return numbers.Where(IsEven).Sum();
    }

    private static bool IsEven(int number) => number % 2 == 0;
}
