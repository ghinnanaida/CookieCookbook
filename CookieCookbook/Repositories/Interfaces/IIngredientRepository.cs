using CookieCookbook.Models;

namespace CookieCookbook.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        List<Ingredient> GetAllAvailable();
        Ingredient? GetById(int id);
    }
}