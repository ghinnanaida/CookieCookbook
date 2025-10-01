using CookieCookbook.Models;
using CookieCookbook.Repositories.Interfaces;
using CookieCookbook.Views;

namespace CookieCookbook.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepo;
        private readonly IIngredientRepository _ingredientRepo;
        private readonly string _filePath;

        public RecipeService(
            IRecipeRepository recipeRepo,
            IIngredientRepository ingredientRepo,
            string filePath)
        {
            _recipeRepo = recipeRepo;
            _ingredientRepo = ingredientRepo;
            _filePath = filePath;
        }

        public List<Recipe> GetExistingRecipes()
        {
            return _recipeRepo.LoadRecipes(_filePath);
        }

        public List<Ingredient> GetAvailableIngredients()
        {
            return _ingredientRepo.GetAllAvailable();
        }

        public Ingredient? GetIngredientById(int id)
        {
            return _ingredientRepo.GetById(id);
        }

        public bool SaveRecipe(Recipe recipe)
        {
            if (!recipe.IsValid())
            {
                return false;
            }

            var existingRecipes = _recipeRepo.LoadRecipes(_filePath);
            existingRecipes.Add(recipe);
            _recipeRepo.SaveRecipes(_filePath, existingRecipes);
            return true;
        }
    }
}