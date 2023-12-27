namespace _16_QuoteFinder;

public static class StringExtensions
{
    public static bool ContainsWord(this string input, string requiredWord)
    {
        var split = input.Split(
            new[] { ' ', '.', ',', '!', '?', ';', ':' },
            StringSplitOptions.RemoveEmptyEntries);

        return split
            .Any(word => string.Equals(
                word, requiredWord, StringComparison.OrdinalIgnoreCase));
    }
}