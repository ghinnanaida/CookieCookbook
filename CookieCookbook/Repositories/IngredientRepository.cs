using CookieCookbook.Repositories.Interfaces;
using CookieCookbook.Models;

namespace CookieCookbook.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly List<Ingredient> _ingredients;

        public IngredientRepository()
        {
            _ingredients = new List<Ingredient>
            {
                new WheatFlour(),
                new CoconutFlour(),
                new Butter(),
                new Chocolate(),
                new Sugar(),
                new Cinnamon(),
                new Cardamom(),
                new CocoaPowder()
            };
        }

        public IReadOnlyList<Ingredient> GetAllAvailable()
        {
            return _ingredients.OrderBy(i => i.Id).ToList().AsReadOnly();
        }

        public Ingredient? GetById(int id)
        {
            return _ingredients.FirstOrDefault(i => i.Id == id);
        }
    }

}