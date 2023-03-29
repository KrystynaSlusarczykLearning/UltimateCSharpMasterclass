namespace Pizzeria;

public class Panettone : Dessert, IBakeable
{
    public string GetInstructions() =>
        "Bake at 180 degrees Celsius for 35 minutes.";
}


