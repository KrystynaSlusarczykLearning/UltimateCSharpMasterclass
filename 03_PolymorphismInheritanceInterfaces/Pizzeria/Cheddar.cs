namespace Pizzeria;

public class Cheddar : Cheese
{
    public Cheddar(int priceIfExtraTopping, int agedForMonths)
        : base(priceIfExtraTopping)
    {
        AgedForMonths = agedForMonths;
        Console.WriteLine(
            "Constructor from the Cheddar class");
    }

    public override string Name =>
        $"{base.Name}, more specifically, " +
        $"a Cheddar cheese aged for {AgedForMonths} months";

    public int AgedForMonths { get; }

    public override void Prepare() =>
        Console.WriteLine("Grate and sprinkle over pizza.");

    public void UseMethodsFromBaseClass()
    {
        Console.WriteLine(PublicMethod());
        Console.WriteLine(ProtectedMethod());
        //Console.WriteLine(PrivateMethod());
    }
}


