//HotelBooking class
public class HotelBooking
{
    public string GuestName;
    public DateTime StartDate;
    public DateTime EndDate;

    public HotelBooking(
        string guestName, 
        DateTime startDate, 
        int lengthOfStayInDays)
    {
        GuestName = guestName;
        StartDate = startDate;
        EndDate = startDate.AddDays(lengthOfStayInDays);
    }
}

//Triangle class
public class Triangle
{
    private int _base;
    private int _height;

    public Triangle(int @base, int height)
    {
        _base = @base;
        _height = height;
    }

    public int CalculateArea()
    {
        return (_base * _height) / 2;
    }

    public string AsString()
    {
        return $"Base is {_base}, height is {_height}";
    }
}

//Dog class
public class Dog
{
    private string _name;
    private string _breed;
    private int _weight;

    public Dog(string name, string breed, int weight)
    {
        _name = name;
        _breed = breed;
        _weight = weight;
    }

    public Dog(string name, int weight) : this(name, "mixed-breed", weight)
    {
    }

    public string Describe()
    {
        return $"This dog is named {_name}, it's a {_breed}, " +
        $"and it weighs {_weight} kilograms, so it's a {DescribeSize()} dog.";
    }

    private string DescribeSize()
    {
        if (_weight < 5)
        {
            return "tiny";
        }
        if (_weight < 30)
        {
            return "medium";
        }
        return "large";
    }
}

// Properties of the Order class
public class Order
{
    public string Item { get; }

    private DateTime _date;
    public DateTime Date
    {
        get { return _date; }
        set
        {
            if (value.Year == DateTime.Now.Year)
            {
                _date = value;
            }
        }
    }

    public Order(string item, DateTime date)
    {
        Item = item;
        Date = date;
    }
}

//Computed properties - DailyAccountState class
public class DailyAccountState
{
    public int InitialState { get; }

    public int SumOfOperations { get; }

    public DailyAccountState(
        int initialState,
        int sumOfOperations)
    {
        InitialState = initialState;
        SumOfOperations = sumOfOperations;
    }

    public int EndOfDayState => InitialState + SumOfOperations;

    public string Report =>
        $"Day: {DateTime.Now.Day}, " +
        $"month: {DateTime.Now.Month}, " +
        $"year: {DateTime.Now.Year}, " +
        $"initial state: {InitialState}, " +
        $"end of day state: {EndOfDayState}";
}

//Static classes - NumberToDayOfWeekTranslator
public static class NumberToDayOfWeekTranslator
{
    public static string Translate(int number)
    {
        switch (number)
        {
            case 1:
                return "Monday";
            case 2:
                return "Tuesday";
            case 3:
                return "Wednesday";
            case 4:
                return "Thursday";
            case 5:
                return "Friday";
            case 6:
                return "Saturday";
            case 7:
                return "Sunday";
            default:
                return "Invalid day of the week";
        }
    }
}

//string.Split and string.Join methods
public static class StringsTransformator
{
    public static string TransformSeparators(
        string input,
        string originalSeparator,
        string targetSeparator)
    {
        var stringPieces = input.Split(originalSeparator);
        return string.Join(targetSeparator, stringPieces);
    }
}