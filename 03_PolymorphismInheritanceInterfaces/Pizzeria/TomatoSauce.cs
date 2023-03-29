namespace Pizzeria;

public class TomatoSauce : Ingredient
{
    public TomatoSauce(int priceIfExtraTopping) : base(priceIfExtraTopping)
    {
    }

    public override string Name => "Tomato sauce";
    public int TomatoesIn100Grams { get; }

    public sealed override void Prepare() =>
        Console.WriteLine("Cook tomatoes with basil, garlic and salt. " +
            "Spread on pizza.");
}


