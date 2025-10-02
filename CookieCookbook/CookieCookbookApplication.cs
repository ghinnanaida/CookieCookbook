using CookieCookbook.Services;
using CookieCookbook.Views;
using CookieCookbook.Models;

namespace CookieCookbook
{
    public class CookieRecipeApplication
    {
        private readonly IUserInterface _ui;
        private readonly IRecipeService _recipeService;

        public CookieRecipeApplication(IUserInterface ui, IRecipeService recipeService)
        {
            _ui = ui;
            _recipeService = recipeService;
        }

        public void Run()
        {
            DisplayExistingRecipes();

            var newRecipe = CreateNewRecipe();

            if (!_recipeService.SaveRecipe(newRecipe))
            {
                _ui.DisplayMessage("No ingredients have been selected. Recipe will not be saved.");
            }
            else
            {
                _ui.DisplayRecipeSaved(newRecipe);
            }

            _ui.WaitForExit();
        }

        private void DisplayExistingRecipes()
        {
            var existingRecipes = _recipeService.GetExistingRecipes();
            _ui.DisplayExistingRecipes(existingRecipes);
        }

        private Recipe CreateNewRecipe()
        {
            var availableIngredients = _recipeService.GetAvailableIngredients();
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

                var ingredient = _recipeService.GetIngredientById(id);
                if (ingredient != null)
                {
                    ingredients.Add(ingredient);
                }
            }

            return ingredients;
        }
    }
}