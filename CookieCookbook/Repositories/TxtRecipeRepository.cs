using CookieCookbook.Repositories.Interfaces;
using CookieCookbook.Models;

namespace CookieCookbook.Repositories
{
    public class TxtRecipeRepository : IRecipeRepository
    {
        private readonly IIngredientRepository _ingredientRepository;

        public TxtRecipeRepository(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public List<Recipe> LoadRecipes(string path)
        {
            if (!File.Exists(path))
                return new List<Recipe>();

            var lines = File.ReadAllLines(path);
            return lines.Select(ParseRecipe).ToList();
        }

        public void SaveRecipes(string path, List<Recipe> recipes)
        {
            var lines = recipes.Select(r => 
                string.Join(",", r.Ingredients.Select(i => i.Id))
            );
            File.WriteAllLines(path, lines);
        }

        private Recipe ParseRecipe(string line)
        {
            var ids = line.Split(',').Select(int.Parse);
            var ingredients = ids.Select(id => _ingredientRepository.GetById(id))
                                 .Where(i => i != null)
                                 .ToList();
            return new Recipe(ingredients!);
        }
    }
}