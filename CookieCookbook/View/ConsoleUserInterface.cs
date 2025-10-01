using CookieCookbook.Models;

namespace CookieCookbook.View
{
    public class ConsoleUserInterface : IUserInterface
    {
        public void DisplayExistingRecipes(List<Recipe> recipes)
        {
            if (recipes == null || recipes.Count == 0)
                return;

            Console.WriteLine("Existing recipes are:");
            Console.WriteLine("");

            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"***** {i + 1} *****");
                DisplayRecipe(recipes[i]);
                if (i < recipes.Count - 1)
                    Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        public void DisplayAvailableIngredients(List<Ingredient> ingredients)
        {
            Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
            }
        }

        public string? PromptForIngredientId()
        {
            Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
            return Console.ReadLine();
        }

        public void DisplayRecipeSaved(Recipe recipe)
        {
            Console.WriteLine("Recipe added:");
            DisplayRecipe(recipe);
        }

        public void DisplayRecipe(Recipe recipe)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine(ingredient.ToString());
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void WaitForExit()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        
    }
}