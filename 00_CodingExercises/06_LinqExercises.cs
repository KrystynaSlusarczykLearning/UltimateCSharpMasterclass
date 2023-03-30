public class LinqExercises
{
    //Any & All
    public static bool IsAnyWordWhitespace(List<string> words) =>
         words.Any(word => word.All(
             character => char.IsWhiteSpace(character)));

    //Count & Contains
    public static int CountListsContainingZeroLongerThan(
        int length,
        List<List<int>> listsOfNumbers) =>
            listsOfNumbers.Count(
                list => list.Contains(0) &&
                       !list.Any(number => number < 0));


    //OrderBy & First
    public static string FindShortestWord(
        List<string> words) =>
            words.OrderBy(word => word.Length).First();

    //Where & Distinct
    public static IEnumerable<DateTime> GetFridaysOfYear(
        int year, IEnumerable<DateTime> dates) =>
        dates
        .Where(date =>
            date.Year == year &&
            date.DayOfWeek == DayOfWeek.Friday)
        .Distinct();

    //Select & Average
    public static double CalculateAverageDurationInMilliseconds(
        IEnumerable<TimeSpan> timeSpans) =>
            timeSpans
            .Select(timeSpan => timeSpan.TotalMilliseconds)
            .Average();
}
