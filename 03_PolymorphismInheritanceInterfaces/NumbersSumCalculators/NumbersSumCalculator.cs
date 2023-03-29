public class NumbersSumCalculator
{
    public int Calculate(List<int> numbers)
    {
        int sum = 0;
        foreach (var number in numbers)
        {
            if (ShallBeAdded(number))
            {
                sum += number;
            }
        }
        return sum;
    }

    protected virtual bool ShallBeAdded(int number)
    {
        return true;
    }
}































//using Pizzeria;
//using System.Text.Json;

//var person = new Person
//{
//    FirstName = "John",
//    LastName = "Smith",
//    YearOfBirth = 1972
//};

//var asJson = JsonSerializer.Serialize(person);
//Console.WriteLine("As JSON:");
//Console.WriteLine(asJson);

//var personJson = 
//    "{\"FirstName\":\"John\",\"LastName\":\"Smith\",\"YearOfBirth\":1972}";

//var personFromJson = JsonSerializer.Deserialize<Person>(personJson);

//Console.ReadKey();

//public class Person
//{
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public int YearOfBirth { get; set; }
//}

