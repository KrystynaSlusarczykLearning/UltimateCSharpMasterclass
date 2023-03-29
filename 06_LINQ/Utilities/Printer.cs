namespace _6_LINQ.Utilities;

//this class helps to print collections nicely
public static class Printer
{
    public static void Print<T>(T item, string itemName)
    {
        Console.WriteLine($"{itemName}: {item}");
    }

    public static void Print<T>(IEnumerable<T> collection, string collectionName)
    {
        Print(collection, collectionName, "collection");
    }

    public static void Print<T>(IOrderedEnumerable<T> collection, string collectionName)
    {
        Print(collection as IEnumerable<T>, collectionName, "collection");
    }

    public static void Print<T>(List<T> collection, string collectionName)
    {
        Print(collection as IEnumerable<T>, collectionName, "collection");
    }

    public static void Print<T>(HashSet<T> hashSet, string hashSetName)
    {
        Print(hashSet, hashSetName, "HashSet");
    }

    private static void Print<T>(IEnumerable<T> collection, string collectionName, string collectionType)
    {
        Console.WriteLine($"{collectionName}:");
        if (collection.Any())
        {
            Console.WriteLine(string.Join("\n", collection.Select(elem => elem.ToString())));
        }
        else
        {
            Console.WriteLine($"The {collectionType} is empty!");
        }
    }

    public static void Print<TKey, TValue>(Dictionary<TKey, TValue> dictionary, string dictionaryName)
    {
        Console.WriteLine($"{dictionaryName}:");
        if (dictionary.Any())
        {
            Console.WriteLine(string.Join("\n", dictionary.Select(
                elem => $"Key: {elem.Key}, Value: {elem.Value}")));
        }
        else
        {
            Console.WriteLine("The dictionary is empty!");
        }
    }

    public static void Print<TKey, TValue>(ILookup<TKey, TValue> lookup, string lookupName)
    {
        Console.WriteLine($"{lookupName}:");
        if (lookup.Any())
        {
            Console.WriteLine(string.Join("\n", lookup.Select(
                elem => $"Key: {elem.Key}, Values (count: {lookup[elem.Key].Count()}): {string.Join(", ", lookup[elem.Key])}")));
        }
        else
        {
            Console.WriteLine("The lookup is empty!");
        }
    }
}