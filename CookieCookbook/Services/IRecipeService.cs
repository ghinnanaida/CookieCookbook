using CookieCookbook.Models;

namespace CookieCookbook.Services
{
    public interface IRecipeService
    {
        List<Recipe> GetExistingRecipes();
        bool SaveRecipe(Recipe recipe);
    }
}