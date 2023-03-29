public static class ListExtensions
{
    public static List<TTarget> ConvertTo<TSource, TTarget>(
        this List<TSource> input)
    {
        var result = new List<TTarget>();

        foreach (var item in input)
        {
            TTarget itemAfterCasting =
                (TTarget)Convert.ChangeType(item, typeof(TTarget));

            result.Add(itemAfterCasting);
        }

        return result;
    }

    public static void AddToFront<T>(this List<T> list, T item)
    {
        list.Insert(0, item);
    }
}
