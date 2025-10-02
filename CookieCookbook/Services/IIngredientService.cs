using CookieCookbook.Models;

namespace CookieCookbook.Services
{
    public interface IIngredientService
    {
        IReadOnlyList<Ingredient> GetAvailableIngredients();
        Ingredient? GetIngredientById(int id);
    }
}