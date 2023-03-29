//ValueTuples & Custom indexer - PairOfArrays
public class PairOfArrays<TLeft, TRight>
{
    private readonly TLeft[] _left;
    private readonly TRight[] _right;

    public PairOfArrays(
        TLeft[] left, TRight[] right)
    {
        _left = left;
        _right = right;
    }

    public (TLeft Left, TRight Right) this[int indexInLeft, int indexInRight]
    {
        get
        {
            return (_left[indexInLeft], _right[indexInRight]);
        }
        set
        {
            _left[indexInLeft] = value.Left;
            _right[indexInRight] = value.Right;
        }
    }
}

//HashSet - CreateUnion method
public static class HashSetsUnionExercise
{
    public static HashSet<T> CreateUnion<T>(
        HashSet<T> set1, HashSet<T> set2)
    {
        var result = new HashSet<T>(set1);

        foreach (var item in set2)
        {
            result.Add(item);
        }

        return result;
    }
}

//"params" keyword - Does Stack contain any of the given words?
public static class StackExtensions
{
    public static bool DoesContainAny(
        this Stack<string> stack, params string[] words)
    {
        return words.Any(word => stack.Contains(word));
    }
}

//yield statement - GetAllAfterLastNullReversed method
public class YieldExercise
{
    public static IEnumerable<T> GetAllAfterLastNullReversed<T>(
        IList<T> input)
    {
        for (int i = input.Count - 1; i >= 0; i--)
        {
            if (input[i] is null)
            {
                yield break;
            }
            yield return input[i];
        }
    }
}