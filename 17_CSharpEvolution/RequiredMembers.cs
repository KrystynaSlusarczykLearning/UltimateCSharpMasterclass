using System.Diagnostics.CodeAnalysis;

namespace RequiredMembers;

class RequiredMembers
{
    public void Example()
    {
        var person = new Person
        {
            Name = "Ben",
            Age = 35,
            Nationality = "Brazilian"
        };

        //use SetsRequiredMembers carefully
        //here the Age is not set, yet the compiler does not complain
        var personWithConstructor = new PersonWithConstructor("Italian")
        {
            Name = "Giovanni"
        };
    }
}

public class Person
{
    public required string Name { get; init; }
    public required int Age { get; init; }
    public required string Nationality;
}

public class PersonWithConstructor
{
    public required string Name { get; init; }
    public required int Age { get; init; }
    public required string Nationality;

    //use SetsRequiredMembers carefully
    //if you use it, make sure to set EACH required member in the constructor
    [SetsRequiredMembers]
    public PersonWithConstructor(string nationality)
    {
        Nationality = nationality;
    }
}

//in the derived type, all required members
//from the base type are also required
public class Employee : Person
{
    public required string Position { get; init; }
}
