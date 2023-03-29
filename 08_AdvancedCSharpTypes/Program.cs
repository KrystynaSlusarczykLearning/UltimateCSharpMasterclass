using System.Text.Json;
using System.Text.Json.Serialization;

//Reflection
var converter = new ObjectToTextConverter();

Console.WriteLine(converter.Convert(
    new HouseRecord("123 Maple Road, Berrytown", 170.6d, 2)));

Console.WriteLine(converter.Convert(
    new Pet("Taiga", PetType.Dog, 30)));

//Attributes
var validPerson = new PersonToBeValidated("John", 1982);
var invalidDog = new Dog("R");
var validator = new Validator();

Console.WriteLine(validator.Validate(validPerson) ?
    "Person is valid" :
    "Person is not valid");
Console.WriteLine();
Console.WriteLine(validator.Validate(invalidDog) ?
    "Dog is valid" :
    "Dog is not valid");

//with expression
var weatherData = new WeatherData(25.1m, 65);
Console.WriteLine(weatherData);

var warmerWeatherData = weatherData with { Temperature = 30 };
Console.WriteLine(warmerWeatherData);

//Equals method and == operator
var john = new Person(1, "John");
var theSameAsJohn = new Person(1, "John");
var marie = new Person(2, "Marie");

var point1 = new Point(1, 5);
var point2 = new Point(1, 5);

Console.WriteLine(object.ReferenceEquals(null, null));
Console.WriteLine("Are references equal? " +
    object.ReferenceEquals(john, theSameAsJohn));

Console.WriteLine("point1.Equals(point2): " +
    point1.Equals(point2));

Console.WriteLine("1.Equals(1): " + 1.Equals(1));
Console.WriteLine("1.Equals(2): " + 1.Equals(2));
Console.WriteLine("1.Equals(null): " + 1.Equals(null));
Console.WriteLine(
    "\"abc\".Equals(\"abc\"): " + "abc".Equals("abc"));
Console.WriteLine();

Console.WriteLine(
    "john.Equals(theSameAsJohn): " + john.Equals(theSameAsJohn));

Console.WriteLine("john.Equals(marie): " + john.Equals(marie));
Console.WriteLine("john.Equals(null): " + john.Equals(null));


//GetHashCode
var point3 = new Point(27, 1);
var point4 = new Point(27, 1);
var point5 = new Point(6, -1);
Console.WriteLine(point3.GetHashCode());
Console.WriteLine(point4.GetHashCode());
Console.WriteLine(point5.GetHashCode());

var person1 = new Person(6, "Martin");
var person2 = new Person(6, "Martin");
var person3 = new Person(7, "Bella");
Console.WriteLine(person1.GetHashCode());
Console.WriteLine(person2.GetHashCode());
Console.WriteLine(person3.GetHashCode());


//Tuples
var tuple1 = new Tuple<string, bool>("aaa", false);
var tuple2 = Tuple.Create(10, true);
var tuple3 = Tuple.Create(10, true);
Console.WriteLine(tuple2 == tuple3);
Console.WriteLine(tuple2.Equals(tuple3));
Console.WriteLine(tuple2.GetHashCode());
Console.WriteLine(tuple3.GetHashCode());

var number = tuple2.Item1;

//this will not work - the properties of a tuple are readonly
//tuple2.Item1 = 20;

var valueTuple1 = new ValueTuple<int, string>(1, "bbb");
var valueTuple2 = (Number: 5, Text: "ccc");
valueTuple2.Item1 = 20;
valueTuple2.Text = "ddd";

//nullable types
#nullable disable
string nullableText = null; //no warning, because nullable is disabled
#nullable enable

string? nullableString = null;

int? numberOrNull = null;
Nullable<bool> boolOrNull = true;

if (numberOrNull.HasValue)
{
    int numberValue = numberOrNull.Value;
    Console.WriteLine("not null");
}
if (boolOrNull is not null)
{
    var someBool = boolOrNull.Value;
    Console.WriteLine(someBool);
}

//Querying an API

var baseAddress = "https://datausa.io/api/";
var requestUri = "data?drilldowns=Nation&measures=Population";

IApiDataReader apiDataReader = new ApiDataReader();
var json = await apiDataReader.Read(baseAddress, requestUri);

var root = JsonSerializer.Deserialize<Root>(json);

foreach (var yearlyData in root.data)
{
    Console.WriteLine($"Year: {yearlyData.Year}, " +
        $"population: {yearlyData.Population}");
}


Console.WriteLine("Press any key to close.");
Console.ReadKey();

//documentation comments
/// <summary>
/// Calculates the sum of the elements 
/// in the specified collection.
/// </summary>
/// <param name="numbers">Numbers to sum.</param>
/// <returns>The sum of the elements.</returns>
/// <exception cref="ArgumentNullException">
/// Thrown if `numbers` is null.
/// </exception>
/// <exception cref="OverflowException">
/// Thrown if the sum of the elements in `numbers` 
/// is larger than the max value of an `int`.
/// </exception>
static int Sum(IEnumerable<int> numbers)
{
    return numbers.Sum();
}

string FormatHousesData(IEnumerable<House> houses)
{
    return string.Join("\n",
        houses.Select(house =>
        $"Owner is {house.OwnerName}, " +
        $"address is {house.Address.Number} " +
        $"{house.Address.Street}"));
}

bool ValidateAddress(House house)
{
    if (house == null)
    {
        Console.WriteLine("house is null");
        return false;
    }
    if (house.Address == null)
    {
        Console.WriteLine("address is null");
        return false;
    }
    if (house.Address.Number == null)
    {
        Console.WriteLine("address/number is null");
        return false;
    }
    if (house.Address.Street == null)
    {
        Console.WriteLine("address/street is null");
        return false;
    }
    if (house.Address.Number.Length == 0)
    {
        Console.WriteLine("address/number is empty");
        return false;
    }
    if (house.Address.Street.Length == 0)
    {
        Console.WriteLine("address/street is empty");
        return false;
    }
    return true;
}

//Reflection
class ObjectToTextConverter
{
    public string Convert(object obj)
    {
        Type type = obj.GetType();

        var properties = type
            .GetProperties()
            .Where(property => property.Name != "EqualityContract");

        return string.Join(
            ", ",
            properties
                .Select(property =>
                $"{property.Name} is {property.GetValue(obj)}"));
    }
}

public record Pet(string Name, PetType PetType, float Weight);
public record HouseRecord(string Adderss, double Area, int Floors);
public enum PetType { Cat, Dog, Fish }

public class Dog
{
    [StringLengthValidate(2, 10)]
    public string Name { get; }
    public Dog(string name) => Name = name;
}

public class PersonToBeValidated
{
    [StringLengthValidate(2, 25)]
    public string Name { get; }
    public int YearOfBirth { get; }

    public PersonToBeValidated(string name, int yearOfBirth)
    {
        Name = name;
        YearOfBirth = yearOfBirth;
    }

    public PersonToBeValidated(string name) => Name = name;
}

//Attributes
[AttributeUsage(AttributeTargets.Property)]
class StringLengthValidateAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }

    public StringLengthValidateAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}

class Validator
{
    public bool Validate(object obj)
    {
        var type = obj.GetType();
        var propertiesToValidate = type
            .GetProperties()
            .Where(property =>
                Attribute.IsDefined(
                    property, typeof(StringLengthValidateAttribute)));

        foreach (var property in propertiesToValidate)
        {
            var attribute = (StringLengthValidateAttribute)
                property.GetCustomAttributes(
                    typeof(StringLengthValidateAttribute), true).First();
            object? propertyValue = property.GetValue(obj);
            if (propertyValue is not string)
            {
                throw new InvalidOperationException(
                    $"Attribute {nameof(StringLengthValidateAttribute)} " +
                    $"can only be applied to strings.");
            }
            var value = (string)propertyValue;
            if (value.Length < attribute.Min || value.Length > attribute.Max)
            {
                Console.WriteLine($"Property {property.Name} is invalid. " +
                    $"Value: {value}. The length must be between " +
                    $"{attribute.Min} and {attribute.Max}");
                return false;
            }
        }
        return true;
    }
}

//Structs and classes
//Readonly structs
readonly struct Point : IEquatable<Point>
{
    public int X { get; init; }
    public int Y { get; init; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Equals(Point other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is Point point &&
            Equals(point);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static bool operator ==(Point point1, Point point2) =>
        point1.Equals(point2);

    public static bool operator !=(Point point1, Point point2) =>
        !point1.Equals(point2);

    public static Point operator +(Point a, Point b) =>
        new Point(a.X + b.X, a.Y + b.Y);

    public static implicit operator Point(Tuple<int, int> tuple) =>
        new Point(tuple.Item1, tuple.Item2);

    public override string ToString() => $"X: {X}, Y: {Y}";
}

class Person
{
    public int Id { get; init; }
    public string Name { get; init; }

    public Person(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override bool Equals(object? obj)
    {
        return obj is Person other &&
            Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id;
    }
}

//Records and record structs
public readonly record struct Rectangle(int A, int B);

//this record behaves the same as the WeatherDataClass,
//but it is only 1-line long
public record WeatherData(decimal Temperature, int Humidity);

public class WeatherDataClass : IEquatable<WeatherDataClass?>
{
    public decimal Temperature { get; }
    public int Humidity { get; }

    public WeatherDataClass(decimal temperature, int humidity)
    {
        Temperature = temperature;
        Humidity = humidity;
    }

    public override string ToString() =>
        $"Temperature: {Temperature}, Humidity: {Humidity}";

    public override bool Equals(object? obj)
    {
        return Equals(obj as WeatherDataClass);
    }

    public bool Equals(WeatherDataClass? other)
    {
        return other is not null &&
               Temperature == other.Temperature &&
               Humidity == other.Humidity;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Temperature, Humidity);
    }

    public static bool operator ==(WeatherDataClass? left, WeatherDataClass? right)
    {
        return EqualityComparer<WeatherDataClass>.Default.Equals(left, right);
    }

    public static bool operator !=(WeatherDataClass? left, WeatherDataClass? right)
    {
        return !(left == right);
    }
}

//structs should not have members of reference types
struct FishyStruct
{
    public List<int> Numbers { get; init; }
}



public class House
{
    public string OwnerName { get; }
    public Address Address { get; }

    public House(string ownerName, Address address)
    {
        if (ownerName == null)
        {
            throw new ArgumentNullException(nameof(ownerName));
        }
        if (address == null)
        {
            throw new ArgumentNullException(nameof(address));
        }
        OwnerName = ownerName;
        Address = address;
    }
}

public class Address
{
    public string Street { get; }
    public string Number { get; }

    public Address(string street, string number)
    {
        Street = street;
        Number = number;
    }
}


