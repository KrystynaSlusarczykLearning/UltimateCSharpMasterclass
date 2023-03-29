//Attributes - MustBeLargerThanAttribute

[AttributeUsage(AttributeTargets.Property)]
class MustBeLargerThanAttribute : Attribute
{
    public int Min { get; }

    public MustBeLargerThanAttribute(int min)
    {
        Min = min;
    }
}

//Immutable struct - Time
public struct Time
{
    public int Hour { get; }
    public int Minute { get; }

    public Time(int hour, int minute)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentOutOfRangeException(
                "Hour is out of range of 0-23");
        }
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException(
                "Hour is out of range of 0-23");
        }
        Hour = hour;
        Minute = minute;
    }

    public override string ToString() =>
        $"{Hour.ToString("00")}:{Minute.ToString("00")}";
}

//Equals - overriding it in the FullName class
public class FullNameWithEquals
{
    public string First { get; init; }
    public string Last { get; init; }

    public override bool Equals(object? obj)
    {
        return obj is FullNameWithEquals fullName &&
            fullName.First == First &&
            fullName.Last == Last;
    }

    public override string ToString() => $"{First} {Last}";
}

//Operators overloading - Time structs
public struct TimeWithOperatorsOverloaded
{
    public int Hour { get; }
    public int Minute { get; }

    public TimeWithOperatorsOverloaded(int hour, int minute)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentOutOfRangeException(
                "Hour is out of range of 0-23");
        }
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException(
                "Hour is out of range of 0-23");
        }
        Hour = hour;
        Minute = minute;
    }

    public override string ToString() =>
        $"{Hour.ToString("00")}:{Minute.ToString("00")}";

    public static bool operator ==(
        TimeWithOperatorsOverloaded time1, 
        TimeWithOperatorsOverloaded time2) =>
        time1.Hour == time2.Hour &&
        time1.Minute == time2.Minute;

    public static bool operator !=(
        TimeWithOperatorsOverloaded time1, 
        TimeWithOperatorsOverloaded time2) =>
        !(time1 == time2);

    public static TimeWithOperatorsOverloaded operator +(
        TimeWithOperatorsOverloaded time1, 
        TimeWithOperatorsOverloaded time2)
    {
        var hour = (time1.Hour + time2.Hour) % 24;
        var minute = (time1.Minute + time2.Minute);
        if (minute > 59)
        {
            hour++;
            minute -= 60;
        }

        return new TimeWithOperatorsOverloaded(hour, minute);
    }
}

//GetHashCode - Time struct
public struct TimeWithGetHashCodeAndEquals
{
    public int Hour { get; }
    public int Minute { get; }

    public TimeWithGetHashCodeAndEquals(int hour, int minute)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentOutOfRangeException(
                "Hour is out of range of 0-23");
        }
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException(
                "Hour is out of range of 0-23");
        }
        Hour = hour;
        Minute = minute;
    }

    public override string ToString() =>
        $"{Hour.ToString("00")}:{Minute.ToString("00")}";

    public override bool Equals(object? obj)
    {
        return obj is TimeWithGetHashCodeAndEquals time &&
            time.Hour == Hour &&
            time.Minute == Minute;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hour, Minute);
    }
}

//Record - GpsCoordinates
public record GpsCoordinates(double Latitude, double Longitude);