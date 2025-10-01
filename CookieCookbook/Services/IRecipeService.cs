using CookieCookbook.Models;

namespace CookieCookbook.Services
{
    public interface IRecipeService
    {
        List<Recipe> GetExistingRecipes();
        List<Ingredient> GetAvailableIngredients();
        Ingredient? GetIngredientById(int id);
        bool SaveRecipe(Recipe recipe);
    }
}