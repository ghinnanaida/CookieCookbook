using CookieCookbook.Enumerations;
using CookieCookbook.Repositories.Interfaces;
using CookieCookbook.Repositories;
using CookieCookbook.Service;
using CookieCookbook.View;
using System.IO.Enumeration;

namespace CookieCookbook
{
    public class Program
    {
        private const FileFormat SELECTED_FORMAT = FileFormat.txt; // FileFormat.txt or FileFormat.Json
        private const string FILE_NAME = "recipes";

        public static void Main(string[] args)
        {
            var ingredientRepo = new IngredientRepository();
            var dataStore = CreateDataStore(SELECTED_FORMAT, ingredientRepo);
            var ui = new ConsoleUserInterface();
            var filePath = FILE_NAME + "." +SELECTED_FORMAT;

            var app = new RecipeService(ui, dataStore, ingredientRepo, filePath);
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