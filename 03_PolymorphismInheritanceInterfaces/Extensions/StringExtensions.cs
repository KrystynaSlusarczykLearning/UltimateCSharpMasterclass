namespace Polymorphism.Extensions
{
    public static class StringExtensions
    {
        public static int CountLines(this string input) =>
            input.Split(Environment.NewLine).Length;
    }
}
