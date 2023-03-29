namespace Pizzeria;

public sealed class Mozzarella : Cheese
{
    public Mozzarella(int priceIfExtraTopping) : base(priceIfExtraTopping)
    {
    }

    public override string Name => "Mozzarella";
    public bool IsLight { get; }

    public override void Prepare() =>
        Console.WriteLine("Slice thinly and place on top of the pizza.");
}

//public class SpecialMozzarella : Mozzarella
//{

//}