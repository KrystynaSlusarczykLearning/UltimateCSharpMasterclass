using System.Diagnostics;
using System.Numerics;

var test = new SimpleList<int>();
test.Add(1);
test.Add(2);
test.Add(3);
test.Add(4);
test.Add(5);

test.RemoveAt(0);
test.RemoveAt(1);
test.RemoveAt(2);
test.RemoveAt(1);

var numbers = new List<int> { 5, 3, 2, 8, 16, 7, -10, -11};
Tuple<int, int> minAndMax = GetMinAndMax(numbers);
Console.WriteLine("Smallest number is " + minAndMax.Item1);
Console.WriteLine("Largest number is " + minAndMax.Item2);

var decimals = new List<decimal> { 1.1m, 0.5m, 22.5m, 12m };
var ints = decimals.ConvertTo<decimal, int>();

var floats = new List<float> { 1.4f, -100.01f };
List<long> longs = floats.ConvertTo<float, long>();

var strings = new List<string> { "abc" };
strings.Prepend("a");

//type constraints
var randomLengthCollectionOfInts = 
    CreateCollectionOfRandomLength<int>(5);

//this will not compile because Point
//does not have a parameterless constructor
//var randomLengthCollectionOfPoints = 
//    CreateCollectionOfRandomLength<Point>(5);

var people = new List<Person>
{
    new Person {Name = "John", YearOfBirth = 1980},
    new Person {Name = "Anna", YearOfBirth = 1915},
    new Person {Name = "Bill", YearOfBirth = 2011},
};

var employeesDerivedFromPerson = new List<EmployeeDerivedFromPerson>
{
    new EmployeeDerivedFromPerson {Name = "John", YearOfBirth = 1980},
    new EmployeeDerivedFromPerson {Name = "Anna", YearOfBirth = 1815},
    new EmployeeDerivedFromPerson {Name = "Bill", YearOfBirth = 2150},
};

var validPeople = GetOnlyValid(people);
var validEmployees = GetOnlyValid(employeesDerivedFromPerson);

foreach (var employee in validEmployees)
{
    employee.GoToWork();
}

numbers.Sort();

var words = new List<string> { "ddd", "aaa", " ccc", "bbb" };
words.Sort();
people.Sort();


//measuring the time of execution
Stopwatch stopwatch = Stopwatch.StartNew();

var dates = CreateCollectionOfRandomLength<DateTime>(0);

stopwatch.Stop();
Console.WriteLine($"Execution took {stopwatch.ElapsedMilliseconds} ms.");

//Generic math
Console.WriteLine("Square of 2 is: " + Calculator.Square(2));
Console.WriteLine("Square of 4m is: " + Calculator.Square(4m));
Console.WriteLine("Square of 6d is: " + Calculator.Square(6d));

//IComparable
var john = new Person { Name = "John", YearOfBirth = 1980 };
var anna = new Person { Name = "Anna", YearOfBirth = 1915 };

PrintInOrder(10, 5);
PrintInOrder("aaa", "bb");
PrintInOrder(anna, john);

//Dictionaries
var countryToCurrencyMapping = new Dictionary<string, string>
{
    ["USA"] = "USD",
    ["India"] = "INR",
    ["Spain"] = "EUR",
};

//this will throw an exception,
//because such a key already exists in the Dictonary
//countryToCurrencyMapping.Add("USA", "USD");

countryToCurrencyMapping.Add("Italy", "EUR");

Console.WriteLine("Currency in Spain is " +
    countryToCurrencyMapping["Spain"]);

if (countryToCurrencyMapping.ContainsKey("Italy"))
{
    Console.WriteLine("Currency in Italy is " +
        countryToCurrencyMapping["Italy"]);
}

countryToCurrencyMapping["Poland"] = "PLN";

foreach (var countryCurrencyPair in countryToCurrencyMapping)
{
    Console.WriteLine(
        $"Country: {countryCurrencyPair.Key}, " +
        $"currency: {countryCurrencyPair.Value}");
}

var employees = new List<Employee>
{
    new Employee("Jake Smith", "Space Navigation", 25000),
    new Employee("Anna Blake", "Space Navigation", 29000),
    new Employee("Barbara Oak", "Xenobiology", 21500 ),
    new Employee("Damien Parker", "Xenobiology", 22000),
    new Employee("Nisha Patel", "Machanics", 21000),
    new Employee("Gustavo Sanchez", "Machanics", 20000),
};

var result = CalculateAverageSalaryPerDepartment(employees);

//Strategy design pattern
var filteringStrategySelector = new FilteringStrategySelector();

Console.WriteLine("Select filter:");
Console.WriteLine(
    string.Join(
        Environment.NewLine,
        filteringStrategySelector.FilteringStrategiesNames));

var userInput = Console.ReadLine();

var filteringStrategy = filteringStrategySelector.Select(userInput);
var filteringResult = new Filter().FilterBy(filteringStrategy, numbers);

Print(filteringResult);

var wordsToBeFiltered = new[] { "zebra", "ostrich", "otter" };
var oWords = new Filter().FilterBy(
    word => word.StartsWith("o"),
    wordsToBeFiltered);

Console.WriteLine("Press any key to close.");
Console.ReadKey();

Tuple<int, int> GetMinAndMax(IEnumerable<int> input)
{
    if (!input.Any())
    {
        throw new InvalidOperationException(
            $"The input collection cannot be empty.");
    }
    int min = input.First();
    int max = input.First();

    foreach (var number in input)
    {
        if (number > max)
        {
            max = number;
        }
        if (number < min)
        {
            min = number;
        }
    }

    return new Tuple<int, int>(min, max);
}

IEnumerable<T> CreateCollectionOfRandomLength<T>(
    int maxLength) where T : new()
{
    var length = new Random().Next(maxLength + 1);

    var result = new List<T>(length);

    for (int i = 0; i < length; ++i)
    {
        result.Add(new T());
    }

    return result;
}

IEnumerable<TPerson> GetOnlyValid<TPerson>(
    IEnumerable<TPerson> persons)
    where TPerson : Person
{
    var result = new List<TPerson>();

    foreach (var person in persons)
    {
        if (person.YearOfBirth > 1900 &&
            person.YearOfBirth < DateTime.Now.Year)
        {
            result.Add(person);
        }
    }

    return result;
}

void SomeMethod<TPet, TOwner>(TPet pet, TOwner owner)
    where TPet : Pet, IComparable<TPet>
    where TOwner : new()
{

}

void PrintInOrder<T>(T first, T second) where T : IComparable<T>
{
    if (first.CompareTo(second) > 0)
    {
        Console.WriteLine($"{second} {first}");
    }
    else
    {
        Console.WriteLine($"{first} {second}");
    }
}

Dictionary<string, decimal> CalculateAverageSalaryPerDepartment(
    IEnumerable<Employee> employees)
{
    var employeesPerDepartments = new Dictionary<string, List<Employee>>();

    foreach (var employee in employees)
    {
        if (!employeesPerDepartments.ContainsKey(employee.Department))
        {
            employeesPerDepartments[employee.Department] = new List<Employee>();
        }

        employeesPerDepartments[employee.Department].Add(employee);
    }

    var result = new Dictionary<string, decimal>();

    foreach (var employeesPerDepartment in employeesPerDepartments)
    {
        decimal sumOfSalaries = 0;

        foreach (var employee in employeesPerDepartment.Value)
        {
            sumOfSalaries += employee.MonthlySalary;
        }

        var average = sumOfSalaries / employeesPerDepartment.Value.Count;

        result[employeesPerDepartment.Key] = average;
    }

    return result;
}

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(", ", numbers));
}

public class Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }
}

public class Person : IComparable<Person>
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }

    public override string ToString() => $"{Name} born in {YearOfBirth}";

    public int CompareTo(Person other)
    {
        if (YearOfBirth < other.YearOfBirth)
        {
            return 1;
        }
        else if (YearOfBirth > other.YearOfBirth)
        {
            return -1;
        }
        return 0;
    }
}

public class EmployeeDerivedFromPerson : Person
{
    public void GoToWork() => Console.WriteLine("Going to work");
}

public class Employee
{
    public Employee(string name, string department, decimal monthlySalary)
    {
        Name = name;
        Department = department;
        MonthlySalary = monthlySalary;
    }

    public string Name { get; init; }
    public string Department { get; init; }
    public decimal MonthlySalary { get; init; }
}

public static class Calculator
{
    public static T Square<T>(T input) where T : INumber<T>
        => input * input;
}

public class Pet { }
public class PetOwner { }

public class FilteringStrategySelector
{
    private readonly Dictionary<string, Func<int, bool>> _filteringStrategies =
        new Dictionary<string, Func<int, bool>>
        {
            ["Even"] = number => number % 2 == 0,
            ["Odd"] = number => number % 2 == 1,
            ["Positive"] = number => number > 0,
            ["Negative"] = number => number < 0,
        };

    public IEnumerable<string> FilteringStrategiesNames =>
        _filteringStrategies.Keys;

    public Func<int, bool> Select(string filteringType)
    {
        if (!_filteringStrategies.ContainsKey(filteringType))
        {
            throw new NotSupportedException(
                    $"{filteringType} is not a valid filter");
        }

        return _filteringStrategies[filteringType];
    }
}

public class Filter
{
    public IEnumerable<T> FilterBy<T>(
        Func<T, bool> predicate,
        IEnumerable<T> numbers)
    {
        var result = new List<T>();

        foreach (var number in numbers)
        {
            if (predicate(number))
            {
                result.Add(number);
            }
        }

        return result;
    }
}

