//Generic types - Pair class
public class Pair<T>
{
    public T First { get; private set; }
    public T Second { get; private set; }

    public Pair(T first, T second)
    {
        First = first;
        Second = second;
    }

    public void ResetFirst() =>
        First = default;

    public void ResetSecond() =>
        Second = default;
}

//Generic methods - SwapTupleItems method
public static class GenericMethodsSwapTupleItemsExercise
{
    public static Tuple<TSecond, TFirst> SwapTupleItems<TFirst, TSecond>(
        Tuple<TFirst, TSecond> tuple) =>
            new Tuple<TSecond, TFirst>(tuple.Item2, tuple.Item1);
}

//Type constraints & IComparable - SortedList of FullNames
public class SortedList<T> where T : IComparable<T>
{
    public IEnumerable<T> Items { get; }

    public SortedList(IEnumerable<T> items)
    {
        var asList = items.ToList();
        asList.Sort();
        Items = asList;
    }
}

public class FullName : IComparable<FullName>
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public override string ToString() => $"{FirstName} {LastName}";

    public int CompareTo(FullName other)
    {
        var lastNameComparisonResult = LastName.CompareTo(other.LastName);
        if (lastNameComparisonResult != 0)
        {
            return lastNameComparisonResult;
        }
        else return FirstName.CompareTo(other.FirstName);
    }
}

//Basics of Funcs and Actions
public class BasicsOfFuncsAndActionsExercise
{
    public void TestMethod()
    {
        Func<int, bool, double> someMethod1 = Method1;
        Func<DateTime> someMethod2 = Method2;
        Action<string, string> someMethod3 = Method3;
    }

    public double Method1(int a, bool b) => 0;
    public DateTime Method2() => default(DateTime);
    public void Method3(string a, string b) { }
}

//Basics of lambda expressions
public class BasicsOfLambdaExpressionsExercise
{
    private static readonly Random _random = new();

    public Func<string, int> GetLength = (text) => text.Length;
    public Func<int> GetRandomNumberBetween1And10 = () => _random.Next(1, 11);
}

//Dictionaries - FindMaxWeights of pets
public static class DictionariesFindMaxWeightsExercise
{
    public static Dictionary<PetType, double> FindMaxWeights(List<Pet> pets)
    {
        var result = new Dictionary<PetType, double>();

        foreach (var pet in pets)
        {
            if (!result.ContainsKey(pet.PetType) ||
               pet.Weight > result[pet.PetType])
            {
                result[pet.PetType] = pet.Weight;
            }
        }

        return result;
    }
}

public class Pet
{
    public PetType PetType { get; }
    public double Weight { get; }

    public Pet(PetType petType, double weight)
    {
        PetType = petType;
        Weight = weight;
    }

    public override string ToString() => $"{PetType}, {Weight} kilos";
}

public enum PetType { Dog, Cat, Fish }