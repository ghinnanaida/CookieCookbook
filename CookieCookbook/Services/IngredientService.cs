using CookieCookbook.Models;
using CookieCookbook.Repositories.Interfaces;
using CookieCookbook.Views;

namespace CookieCookbook.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepo;

        public IngredientService(
            IIngredientRepository ingredientRepo)
        {
            _ingredientRepo = ingredientRepo;
        }

        public IReadOnlyList<Ingredient> GetAvailableIngredients()
        {
            return _ingredientRepo.GetAllAvailable();
        }

        public Ingredient? GetIngredientById(int id)
        {
            return _ingredientRepo.GetById(id);
        }

    }
}