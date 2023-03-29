namespace Pizzeria;

public class Pizza : IBakeable
{
    private List<Ingredient> _ingredients = new List<Ingredient>();

    public void AddIngredient(Ingredient ingredient) =>
        _ingredients.Add(ingredient);

    public string GetInstructions() =>
        "Bake at 250 degrees Celsius for 10 minutes, " +
        "ideally on a stone";

    public override string ToString() =>
        $"This is a pizza with {string.Join(", ", _ingredients)}";
}


