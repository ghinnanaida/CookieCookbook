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
                new WheatFlour(1),
                new CoconutFlour(2),
                new Butter(3),
                new Chocolate(4),
                new Sugar(5),
                new Cinnamon(6),
                new Cardamom(7),
                new CocoaPowder(8)
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