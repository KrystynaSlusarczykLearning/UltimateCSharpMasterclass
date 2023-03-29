using CookieCookbook.Recipes.Ingredients;
using CookieCookbook.Recipes;

namespace CookieCookbook.App;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}



