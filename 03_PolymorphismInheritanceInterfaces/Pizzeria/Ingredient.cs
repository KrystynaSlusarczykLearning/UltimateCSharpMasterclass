namespace Pizzeria;

public abstract class Ingredient
{
    public Ingredient(int priceIfExtraTopping)
    {
        Console.WriteLine(
            "Constructor from the Ingredient class");
        PriceIfExtraTopping = priceIfExtraTopping;
    }

    public int PriceIfExtraTopping { get; }

    public override string ToString() => Name;

    public virtual string Name { get; } = "Some ingredient";

    public abstract void Prepare();

    public int PublicField;

    public string PublicMethod() =>
        "This method is PUBLIC in the Ingredient class.";

    protected string ProtectedMethod() =>
        "This method is PROTECTED in the Ingredient class.";

    private string PrivateMethod() =>
        "This method is PRIVATE in the Ingredient class.";
}


