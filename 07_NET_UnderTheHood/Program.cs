//value types vs reference types
using System.Collections;

int number = 5;
int anotherNumber = number;
anotherNumber++;
Console.WriteLine("number is " + number);
Console.WriteLine("anotherNumber is " + anotherNumber);

var john = new Person { Name = "John", Age = 34 };
var person = john;
person.Age = 35;
Console.WriteLine("John's age is " + john.Age);
Console.WriteLine("person's age is " + person.Age);

AddOneToNumber(number);
AddOneToPersonsAge(john);

Console.WriteLine("Number is now " + number);
Console.WriteLine("John's age is now " + john.Age);

//boxing and unboxing
object boxedNumber = number;
int unboxedNumber = (int)boxedNumber;

//boxing also happens here:
IComparable<int> intAsComparable = number;

var numbers1 = new List<int> { 1, 2, 3, 4, 5 };
//ArrayList stores everything as object,
//so each of those numbers must be boxed
var numbers2 = new ArrayList { 1, 2, 3, 4, 5 };

//Here it is the same: each int is boxed to be stored as interface type
var numbers3 = new List<IComparable<int>> { 1, 2, 3, 4, 5 };

var variousObjects = new List<object>
{
    1,
    1.5m,
    new DateTime(2024, 6, 1),
    "hello",
    new Person {Name = "Anna", Age = 61}
};

foreach (object someObject in variousObjects)
{
    Console.WriteLine(
        someObject.GetType().Name);
}

//Dipose method and the using statement
const string filePath = "file.txt";
using (var writer = new FileWriter(filePath))
{
    writer.Write("some text");
    writer.Write("some other text");
}

using var reader = new SpecificLineFromTextFileReader(filePath);
var third = reader.ReadLineNumber(3);
var fourth = reader.ReadLineNumber(4);

Console.WriteLine("Third line is: " + third);
Console.WriteLine("Fourth line is: " + fourth);

Console.WriteLine("Press any key to close.");
Console.ReadKey();

void AddOneToNumber(int number)
{
    ++number;
}

void AddOneToNumberWithRef(ref int number)
{
    ++number;
}

void AddOneToPersonsAge(Person person)
{
    ++person.Age;
}

//ref can also be used with reference types
void AddOneToList(ref List<int> numbers)
{
    numbers = null;
}


//non-destructive mutation
Person AddOneToPersonsAgeNonDestructive(Person person)
{
    return new Person { Name = person.Name, Age = person.Age + 1 };
}

class Person
{
    public string Name { get; init; }
    public int Age { get; set; }

    ~Person()
    {
        Console.WriteLine($"Person called {Name} is being destructed.");
    }

    //this will not compile
    //we can only define Finalizers as shown above
    //protected override void Finalize()
    //{
    //    Console.WriteLine($"Person called {Name} is being destructed.");
    //}
}

public class FileWriter : IDisposable
{
    private readonly StreamWriter _streamWriter;

    public FileWriter(string filePath)
    {
        _streamWriter = new StreamWriter(filePath, true);
    }

    public void Write(string text)
    {
        _streamWriter.WriteLine(text);
        _streamWriter.Flush();
    }

    public void Dispose()
    {
        _streamWriter.Dispose();
    }
}

public class SpecificLineFromTextFileReader : IDisposable
{
    private readonly StreamReader _streamReader;

    public SpecificLineFromTextFileReader(string filePath)
    {
        _streamReader = new StreamReader(filePath);
    }

    public string ReadLineNumber(int lineNumber)
    {
        _streamReader.DiscardBufferedData();
        _streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

        for(var i = 0; i < lineNumber - 1; ++i)
        {
            _streamReader.ReadLine();
        }

        return _streamReader.ReadLine();
    }

    public void Dispose()
    {
        _streamReader.Dispose();
    }
}

