namespace StarWarsPlanetsStats.Utilities;

public static class StringExtensions
{
    public static int? ToIntOrNull(this string? input)
    {
        return int.TryParse(input, out int resultParsed) ?
            resultParsed :
            null;
    }

    public static long? ToLongOrNull(this string? input)
    {
        return long.TryParse(input, out long resultParsed) ?
            resultParsed :
            null;
    }
}