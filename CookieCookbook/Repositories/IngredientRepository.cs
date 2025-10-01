using CookieCookbook.Repositories.Interfaces;
using CookieCookbook.Models;

namespace CookieCookbook.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly Dictionary<int, Ingredient> _ingredients;

        public IngredientRepository()
        {
            _ingredients = new Dictionary<int, Ingredient>
            {
                { 1, new Ingredient(1, "Wheat flour", "Sieve. Add to other ingredients.") },
                { 2, new Ingredient(2, "Coconut flour", "Sieve. Add to other ingredients.") },
                { 3, new Ingredient(3, "Butter", "Melt on low heat. Add to other ingredients.") },
                { 4, new Ingredient(4, "Chocolate", "Melt in a water bath. Add to other ingredients.") },
                { 5, new Ingredient(5, "Sugar", "Add to other ingredients.") },
                { 6, new Ingredient(6, "Cardamom", "Take half a teaspoon. Add to other ingredients.") },
                { 7, new Ingredient(7, "Cinnamon", "Take half a teaspoon. Add to other ingredients.") },
                { 8, new Ingredient(8, "Cocoa powder", "Add to other ingredients.") }
            };
        }

        public List<Ingredient> GetAllAvailable()
        {
            return _ingredients.Values.OrderBy(i => i.Id).ToList();
        }

        public Ingredient? GetById(int id)
        {
            return _ingredients.TryGetValue(id, out var ingredient) ? ingredient : null;
        }
    }

}