using CookieCookbook.Models;

namespace CookieCookbook.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        List<Recipe> LoadRecipes(string path);
        void SaveRecipes(string path, List<Recipe> recipes);
    }
}