namespace CookieCookbook.Recipes.Ingredients;

public class Butter : Ingredient
{
    public override int Id => 3;
    public override string Name => "Butter";
    public override string PreparationInstructions =>
        $"Melt on low heat. {base.PreparationInstructions}";
}

