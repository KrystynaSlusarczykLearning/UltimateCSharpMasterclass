using System.Collections;
using System.Diagnostics;

//our custom collection
var customCollection = new CustomCollection(
    new string[] { "aaa", "bbb", "ccc" });

foreach (var word in customCollection)
{
    Console.WriteLine(word);
}

//this is what a foreach loop is translated to
IEnumerator wordsEnumerator = customCollection.GetEnumerator();
object currentWord;
while (wordsEnumerator.MoveNext())
{
    currentWord = wordsEnumerator.Current;
    Console.WriteLine(currentWord);
}

//Binary search

var sortedList = new List<int>
{
    1, 3, 4, 5, 6, 11, 12, 14, 16, 18
};

//our implementation of Binary search
var indexOf1 = sortedList.FindIndexInSorted(1);
var indexOf11 = sortedList.FindIndexInSorted(11);
var indexOf12 = sortedList.FindIndexInSorted(12);
var indexOf18 = sortedList.FindIndexInSorted(18);
var indexOf13 = sortedList.FindIndexInSorted(13);

//Built-in Binary search
int builtInSearch_indexOf1 = sortedList.BinarySearch(1);
int builtInSearch_indexOf11 = sortedList.BinarySearch(11);
int builtInSearch_indexOf12 = sortedList.BinarySearch(12);
int builtInSearch_indexOf18 = sortedList.BinarySearch(18);
int builtInSearch_indexOf13 = sortedList.BinarySearch(13);

//List performance

var input = Enumerable.Range(0, 100_000_000).ToArray();

Stopwatch stopwatch = Stopwatch.StartNew();
var list1 = new List<int>(input);
stopwatch.Stop();
Console.WriteLine($"Creating a List from existing collection took: {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Restart();
var list2 = new List<int>();
foreach (var item in input)
{
    list2.Add(item);
}
stopwatch.Stop();
Console.WriteLine($"Creating a List with resizing: {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Restart();
var list3 = new List<int>(input.Length);
foreach (var item in input)
{
    list3.Add(item);
}
stopwatch.Stop();
Console.WriteLine($"Creating a List without resizing took: {stopwatch.ElapsedMilliseconds} ms");


//To get distinct items, we can use HashSet or
//Distinct method (which also uses HashSetUnder the hood)
var numbersWithDuplicates = new int[] { 1, 2, 4, 1, 3, 1, 1 };
var distinct1 = new HashSet<int>(numbersWithDuplicates).ToList();
var distinct2 = numbersWithDuplicates.Distinct().ToList();

//Queue
var queue = new Queue<string>();
queue.Enqueue("a");
queue.Enqueue("b");
queue.Enqueue("c");
queue.Enqueue("d");

var first = queue.Dequeue();
var second = queue.Peek();

//PriorityQueue
var priorityQueue = new PriorityQueue<string, int>();
priorityQueue.Enqueue("a", 5);
priorityQueue.Enqueue("b", 5);
priorityQueue.Enqueue("c", 2);
priorityQueue.Enqueue("d", 3);

var firstPriority = priorityQueue.Dequeue();

//Stack
var stack = new Stack<string>();
stack.Push("a");
stack.Push("b");
stack.Push("c");

var top = stack.Pop();
var secondToTop = stack.Peek();

//Built-in LinkedList (it is doubly-linked)
var linkedList = new LinkedList<int>();
linkedList.AddFirst(1);
linkedList.AddFirst(2);
linkedList.AddFirst(3);
linkedList.Remove(2);

//params
Console.WriteLine(Calculator.Add(1, 2));
Console.WriteLine(Calculator.Add(1, 2, 3));
Console.WriteLine(Calculator.Add(1, 2, 3, 4));
Console.WriteLine(Calculator.Add());


//yield statement
var smallSubset = GenerateEvenNumbers()
    .Skip(5)
    .Take(50);

foreach (var number in GenerateEvenNumbers())
{
    if (number == 50)
    {
        break;
    }
    Console.WriteLine(number);
}

var evenNumbers = GenerateEvenNumbers();
var firstThreeEvenNumbers = evenNumbers.Take(3).ToList();
foreach (var evenNumber in firstThreeEvenNumbers)
{
    Console.WriteLine($"Number is {evenNumber}");
}
foreach (var evenNumber in firstThreeEvenNumbers)
{
    Console.WriteLine($"Number is {evenNumber}");
}

foreach (var number in GetSingleDigitNumbers())
{
    Console.WriteLine(number);
}

var letters = new[] { "a", "b", "a", "c", "d", "b" };
foreach (var item in Distinct(letters))
{
    Console.WriteLine(item);
}

var numbers = new int[] { 1, 4, 2, -5, 6, -2, 1 };
foreach (var number in GetBeforeFirstNegative(numbers))
{
    Console.WriteLine(number);
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();


//yield statement
IEnumerable<int> GenerateEvenNumbers()
{
    for (int i = 0; i < int.MaxValue; i += 2)
    {
        Console.WriteLine($"Yielding {i}");
        yield return i;
    }
}

IEnumerable<int> GetSingleDigitNumbers()
{
    yield return 0;
    yield return 1;
    yield return 2;
    yield return 3;
    yield return 4;
    yield return 5;
    yield return 6;
    yield return 7;
    yield return 8;
    yield return 9;
}

IEnumerable<T> Distinct<T>(
    IEnumerable<T> input)
{
    var hashSet = new HashSet<T>();
    foreach (var item in input)
    {
        if (!hashSet.Contains(item))
        {
            hashSet.Add(item);
            yield return item;
        }
    }
}

IEnumerable<int> GetBeforeFirstNegative(
    IEnumerable<int> input)
{
    foreach (var number in input)
    {
        if (number >= 0)
        {
            yield return number;
        }
        else
        {
            yield break;
        }
    }
}

public class CustomCollection : IEnumerable<string>
{
    public string[] Words { get; }

    public CustomCollection(string[] words)
    {
        Words = words;
    }

    public string this[int index]
    {
        get => Words[index];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<string> GetEnumerator()
    {
        return new WordsEnumerator(Words);
    }
}

public class WordsEnumerator : IEnumerator<string>
{
    private const int InitialPosition = -1;
    private int _currentPosition = InitialPosition;
    private readonly string[] _words;

    public WordsEnumerator(string[] words)
    {
        _words = words;
    }

    object IEnumerator.Current => Current;

    public string Current
    {
        get
        {
            try
            {
                return _words[_currentPosition];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException(
                    $"{nameof(CustomCollection)}'s end reached.",
                    ex);
            }
        }
    }

    public bool MoveNext()
    {
        ++_currentPosition;
        return _currentPosition < _words.Length;
    }

    public void Reset()
    {
        _currentPosition = InitialPosition;
    }

    public void Dispose()
    {

    }
}


//Binary search
public static class ListExtensions
{
    public static int? FindIndexInSorted<T>(
        this IList<T> list, T itemToFind)
        where T : IComparable<T>
    {
        int leftBound = 0;
        int rightBound = list.Count - 1;

        while (leftBound <= rightBound)
        {
            int middleIndex = (leftBound + rightBound) / 2;
            if (itemToFind.Equals(list[middleIndex]))
            {
                return middleIndex;
            }
            else if (itemToFind.CompareTo(list[middleIndex]) < 0)
            {
                rightBound = middleIndex - 1;
            }
            else
            {
                leftBound = middleIndex + 1;
            }
        }

        return null;
    }
}

//HashSet
public class SpellChecker
{
    private readonly HashSet<string> _correctWords = new()
    {
        "dog", "cat", "fish"
    };

    public bool IsCorrect(string word) =>
        _correctWords.Contains(word);

    public void AddCorrectWord(string word) =>
        _correctWords.Add(word);
}

//params
public static class Calculator
{
    public static int Add(params int[] numbers) =>
        numbers.Sum();
}

public class CustomCollectionWithYield : IEnumerable<string>
{
    public string[] Words { get; }

    public CustomCollectionWithYield(string[] words)
    {
        Words = words;
    }

    public CustomCollectionWithYield()
    {
        Words = new string[10];
    }

    private int _currentIndex = 0;
    public void Add(string item)
    {
        Words[_currentIndex] = item;
        ++_currentIndex;
    }

    public string this[int index]
    {
        get => Words[index];
        set => Words[index] = value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<string> GetEnumerator()
    {
        foreach(var word in Words)
        {
            yield return word;
        }
    }
}

























