namespace CookieCookbook.Models
{
     public class Recipe
    {
        public List<Ingredient> Ingredients { get; }

        public Recipe(List<Ingredient> ingredients)
        {
            Ingredients = ingredients ?? new List<Ingredient>();
        }

        public bool IsValid()
        {
            return Ingredients.Count > 0;
        }
    }
}