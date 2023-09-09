//Composition approach
interface IPersonalDataReader
{
    IEnumerable<Person> ReadPeople();
}

class PersonalDataFormatter
{
    private readonly IPersonalDataReader _personalDataReader;

    public PersonalDataFormatter(IPersonalDataReader personalDataReader)
    {
        _personalDataReader = personalDataReader;
    }

    public string Format()
    {
        var people = _personalDataReader.ReadPeople();
        return string.Join("\n",
            people.Select(p => $"{p.Name} born in" +
            $" {p.Country} on {p.YearOfBirth}"));
    }
}

class DatabaseSourcedPersonalDataReader : IPersonalDataReader
{
    public IEnumerable<Person> ReadPeople()
    {
        Console.WriteLine("Reading from database");
        return new List<Person>
        {
            new Person("John", 1982, "USA"),
            new Person("Aja", 1992, "India"),
            new Person("Tom", 1954, "Australia"),
        };
    }
}

class ExcelSourcedPersonalDataReader : IPersonalDataReader
{
    public IEnumerable<Person> ReadPeople()
    {
        Console.WriteLine("Reading from an Excel file");
        return new List<Person>
        {
            new Person("Martin", 1972, "France"),
            new Person("Aiko", 1995, "Japan"),
            new Person("Selene", 1944, "Great Britain"),
        };
    }
}

//Inheritance approach
//bool shallReadFromDatabase = false;

//PersonalDataFormatter personalDataFormatter = shallReadFromDatabase ?
//    new DatabaseSourcedPersonalDataFormatter() :
//    new ExcelSourcedPersonalDataFormatter();
//Console.WriteLine(personalDataFormatter.Format());

//Console.ReadKey();

//abstract class PersonalDataFormatter
//{
//    public string Format()
//    {
//        var people = ReadPeople();
//        return string.Join("\n",
//            people.Select(p => $"{p.Name} born in" +
//            $" {p.Country} on {p.YearOfBirth}"));
//    }

//    public abstract IEnumerable<Person> ReadPeople();
//}

//class DatabaseSourcedPersonalDataFormatter : PersonalDataFormatter
//{
//    public override IEnumerable<Person> ReadPeople()
//    {
//        Console.WriteLine("Reading from database");
//        return new List<Person>
//        {
//            new Person("John", 1982, "USA"),
//            new Person("Aja", 1992, "India"),
//            new Person("Tom", 1954, "Australia"),
//        };
//    }
//}

//class ExcelSourcedPersonalDataFormatter : PersonalDataFormatter
//{
//    public override IEnumerable<Person> ReadPeople()
//    {
//        Console.WriteLine("Reading from an Excel file");
//        return new List<Person>
//        {
//            new Person("Martin", 1972, "France"),
//            new Person("Aiko", 1995, "Japan"),
//            new Person("Selene", 1944, "Great Britain"),
//        };
//    }
//}

public record Person(string Name, int YearOfBirth, string Country);