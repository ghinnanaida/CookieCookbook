using CookieCookbook.Repositories.Interfaces;
using CookieCookbook.Models;
using System.Text.Json;

namespace CookieCookbook.Repositories
{
    public class JsonRecipeRepository : IRecipeRepository
    {
        private readonly IIngredientRepository _ingredientRepository;

        public JsonRecipeRepository(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public List<Recipe> LoadRecipes(string path)
        {
            if (!File.Exists(path))
                return new List<Recipe>();

            var json = File.ReadAllText(path);
            var recipeStrings = JsonSerializer.Deserialize<List<string>>(json);

            return recipeStrings?.Select(ParseRecipe).ToList() ?? new List<Recipe>();
        }

        public void SaveRecipes(string path, List<Recipe> recipes)
        {
            var recipeStrings = recipes.Select(r => 
                string.Join(",", r.Ingredients.Select(i => i.Id))
            ).ToList();

            var json = JsonSerializer.Serialize(recipeStrings);
            File.WriteAllText(path, json);
        }

        private Recipe ParseRecipe(string recipeString)
        {
            var ids = recipeString.Split(',').Select(int.Parse);
            var ingredients = ids.Select(id => _ingredientRepository.GetById(id))
                                 .Where(i => i != null)
                                 .ToList();
            return new Recipe(ingredients!);
        }
    }

}