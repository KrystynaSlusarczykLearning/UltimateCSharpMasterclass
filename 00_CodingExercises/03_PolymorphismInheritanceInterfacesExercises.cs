//Inheritance & Overriding - Animals
public class InheritanceAndOverridingAnimalsExercise
{
    public List<int> GetCountsOfAnimalsLegs()
    {
        var animals = new List<Animal>
            {
                new Lion(),
                new Tiger(),
                new Duck(),
                new Spider()
            };

        var result = new List<int>();
        foreach (var animal in animals)
        {
            result.Add(animal.NumberOfLegs);
        }
        return result;
    }
}

public class Animal
{
    public virtual int NumberOfLegs { get; } = 4;
}

public class Tiger : Animal
{
}

public class Lion : Animal
{
}

public class Duck : Animal
{
    public override int NumberOfLegs { get; } = 2;
}

public class Spider : Animal
{
    public override int NumberOfLegs { get; } = 8;
}

//Virtual methods - StringsProcessor classes
public class VirtualMethodsStringsProcessorClasses
{
    public List<string> ProcessAll(List<string> words)
    {
        var stringsProcessors = new List<StringsProcessor>
                {
                    new StringsTrimmingProcessor(),
                    new StringsUppercaseProcessor()
                };

        List<string> result = words;
        foreach (var stringsProcessor in stringsProcessors)
        {
            result = stringsProcessor.Process(result);
        }
        return result;
    }
}

public class StringsProcessor
{
    public List<string> Process(
        List<string> strings)
    {
        var result = new List<string>();
        foreach (var text in strings)
        {
            result.Add(ProcessSingle(text));
        }
        return result;
    }

    protected virtual string ProcessSingle(string input) => input;
}

public class StringsTrimmingProcessor : StringsProcessor
{
    protected override string ProcessSingle(string input) =>
        input.Substring(0, input.Length / 2);
}

public class StringsUppercaseProcessor : StringsProcessor
{
    protected override string ProcessSingle(string input) =>
        input.ToUpper();
}

//"is" operator and null object -NumericTypesDescriber class
public static class NumericTypesDescriber
{
    public static string Describe(object someObject)
    {
        if (someObject is int asInt)
        {
            return "Int of value " + asInt;
        }
        if (someObject is double asDouble)
        {
            return "Double of value " + asDouble;
        }
        if (someObject is decimal asDecimal)
        {
            return "Decimal of value " + asDecimal;
        }
        return null;
    }
}

//Abstract methods - Shapes
public static class AbstractMethodsShapesExercise
{
    public static List<double> GetShapesAreas(List<Shape> shapes)
    {
        var result = new List<double>();

        foreach (var shape in shapes)
        {
            result.Add(shape.CalculateArea());
        }

        return result;
    }
}

public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Square : Shape
{
    public double Side { get; }

    public Square(double side)
    {
        Side = side;
    }

    public override double CalculateArea() => Side * Side;
}

public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea() => Width * Height;
}

public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea() => Math.PI * Radius * Radius;
}

//Extension methods - List extensions
public static class ListExtensions
{
    public static List<int> TakeEverySecond(this List<int> list)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < list.Count; i += 2)
        {
            result.Add(list[i]);
        }
        return result;
    }
}

//Interfaces - Applying multiple transformations to a number
public static class InterfacesApplyingMutipleTransformationsToNumberExercise
{
    public static int Transform(
        int number)
    {
        var transformations = new List<INumericTransformation>
            {
                new By1Incrementer(),
                new By2Multiplier(),
                new ToPowerOf2Raiser()
            };

        var result = number;
        foreach (var transformation in transformations)
        {
            result = transformation.Transform(result);
        }
        return result;
    }
}

public interface INumericTransformation
{
    int Transform(int number);
}

public class By1Incrementer : INumericTransformation
{
    public int Transform(int number) => ++number;
}

public class By2Multiplier : INumericTransformation
{
    public int Transform(int number) => number * 2;
}

public class ToPowerOf2Raiser : INumericTransformation
{
    public int Transform(int number) => number * number;
}