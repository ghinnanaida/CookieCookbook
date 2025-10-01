using CookieCookbook.Enumerations;
using CookieCookbook.Repositories.Interfaces;
using CookieCookbook.Repositories;
using CookieCookbook.Controllers;
using CookieCookbook.Services;
using CookieCookbook.Views;

namespace CookieCookbook
{
    public class Program
    {
        private const FileFormat SELECTED_FORMAT = FileFormat.txt; // FileFormat.txt or FileFormat.Json
        private const string FILE_NAME = "recipes";

        public static void Main(string[] args)
        {
            var ingredientRepo = new IngredientRepository();
            var recipeRepo = CreateDataStore(SELECTED_FORMAT, ingredientRepo);
            var ui = new ConsoleUserInterface();
            var filePath = FILE_NAME + "." +SELECTED_FORMAT;
            var recipeService = new RecipeService(recipeRepo, ingredientRepo, filePath);

            var app = new CookieRecipeController(ui, recipeService);
            app.Run();
        }

        private static IRecipeRepository CreateDataStore(FileFormat format, IIngredientRepository ingredientRepo)
        {
            return format switch
            {
                FileFormat.Json => new JsonRecipeRepository(ingredientRepo),
                FileFormat.txt => new TxtRecipeRepository(ingredientRepo),
                _ => throw new ArgumentException("Invalid file format")
            };
        }
    }
}