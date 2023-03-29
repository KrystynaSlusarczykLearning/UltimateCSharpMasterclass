using Pizzeria;
using System.Text.Json;

var person = new Person
{
    FirstName = "John",
    LastName = "Smith",
    YearOfBirth = 1972
};

var asJson = JsonSerializer.Serialize(person);
Console.WriteLine("As JSON:");
Console.WriteLine(asJson);

var personJson =
    "{\"FirstName\":\"John\",\"LastName\":\"Smith\",\"YearOfBirth\":1972}";

var personFromJson = JsonSerializer.Deserialize<Person>(personJson);

var numbers = new List<int> { 1, 4, 6, -1, 12, 44, -8, -19 };
bool shallAddPositiveOnly = false;

NumbersSumCalculator calculator =
    shallAddPositiveOnly ?
    new PositiveNumbersSumCalculator() :
    new NumbersSumCalculator();

int sum = calculator.Calculate(numbers);
Console.WriteLine("Sum is: " + sum);

Console.ReadKey();

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int YearOfBirth { get; set; }
}

