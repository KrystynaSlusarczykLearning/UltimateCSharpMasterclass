using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes;

public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }

    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    public override string ToString()
    {
        var steps = Ingredients
            .Select(ingredient =>
                $"{ingredient.Name}. {ingredient.PreparationInstructions}");
            
        return string.Join(Environment.NewLine, steps);
    }
}
