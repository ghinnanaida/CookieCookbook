namespace CookieCookbook.Models
{
     public class Recipe
    {
        private List<Ingredient> _ingredients { get; }

        public Recipe(List<Ingredient> ingredients)
        {
            _ingredients = ingredients ?? new List<Ingredient>();
        }

        public IReadOnlyList<Ingredient> GetRecipe()
        {
            return _ingredients.AsReadOnly();
        }
        
        public bool IsValid()
        {
            return _ingredients.Count > 0;
        }
    }
}