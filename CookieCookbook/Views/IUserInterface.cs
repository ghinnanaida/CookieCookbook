using CookieCookbook.Models;

namespace CookieCookbook.Views
{
    public interface IUserInterface
    {
        void DisplayExistingRecipes(List<Recipe> recipes);
        void DisplayAvailableIngredients(List<Ingredient> ingredients);
        string? PromptForIngredientId();
        void DisplayRecipeSaved(Recipe recipe);
        void DisplayRecipe(Recipe recipe);
        void DisplayMessage(string message);
        void WaitForExit();
    }
}