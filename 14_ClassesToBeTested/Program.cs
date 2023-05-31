
Console.ReadKey();

public interface IDateTime
{
    public DateTime Now { get; }
}

public class DateTimeWrapper : IDateTime
{
    public DateTime Now => DateTime.Now;
}

public class DatesFormatter
{
    private readonly IDateTime _dateTime;

    public DatesFormatter(IDateTime dateTime)
    {
        _dateTime = dateTime;
    }

    public string FormatCurrentDate()
    {
        return _dateTime.Now.ToShortDateString();
    }
}

public class Shape
{

}

public class Circle : Shape
{
    public double CalculateArea() => 1;
}