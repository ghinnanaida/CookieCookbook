using CookieCookbook.Models;

namespace CookieCookbook.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        IReadOnlyList<Ingredient> GetAllAvailable();
        Ingredient? GetById(int id);
    }
}