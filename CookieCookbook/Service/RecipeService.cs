using CookieCookbook.Models;
using CookieCookbook.Repositories.Interfaces;
using CookieCookbook.View;

namespace CookieCookbook.Service
{
    public class RecipeService
    {
        private readonly IUserInterface _ui;
        private readonly IRecipeRepository _dataStore;
        private readonly IIngredientRepository _ingredientRepo;
        private readonly string _filePath;

        public RecipeService(
            IUserInterface ui,
            IRecipeRepository dataStore,
            IIngredientRepository ingredientRepo,
            string filePath)
        {
            _ui = ui;
            _dataStore = dataStore;
            _ingredientRepo = ingredientRepo;
            _filePath = filePath;
        }

        public void Run()
        {
            DisplayExistingRecipes();

            var newRecipe = CreateNewRecipe();

            if (!newRecipe.IsValid())
            {
                _ui.DisplayMessage("No ingredients have been selected. Recipe will not be saved.");
            }
            else
            {
                SaveRecipe(newRecipe);
                _ui.DisplayRecipeSaved(newRecipe);
            }

            _ui.WaitForExit();
        }

        private void DisplayExistingRecipes()
        {
            var existingRecipes = _dataStore.LoadRecipes(_filePath);
            _ui.DisplayExistingRecipes(existingRecipes);
        }

        private Recipe CreateNewRecipe()
        {
            var availableIngredients = _ingredientRepo.GetAllAvailable();
            _ui.DisplayAvailableIngredients(availableIngredients);

            var selectedIngredients = SelectIngredients();
            return new Recipe(selectedIngredients);
        }

        private List<Ingredient> SelectIngredients()
        {
            var ingredients = new List<Ingredient>();

            while (true)
            {
                var input = _ui.PromptForIngredientId();

                if (!int.TryParse(input, out int id))
                {
                    break;
                }

                var ingredient = _ingredientRepo.GetById(id);
                if (ingredient != null)
                {
                    ingredients.Add(ingredient);
                }
            }

            return ingredients;
        }

        private void SaveRecipe(Recipe recipe)
        {
            var existingRecipes = _dataStore.LoadRecipes(_filePath);
            existingRecipes.Add(recipe);
            _dataStore.SaveRecipes(_filePath, existingRecipes);
        }
    }
}