using CookieCookbook.Models;

namespace CookieCookbook.Tests.Models
{ 
    [TestFixture]
    public class RecipeTest
    {
        [Test]
        public void Constructor_ValidIngredients_ShouldSetIngredients()
        {
            var ingredients = new List<Ingredient>
            {
                new Sugar(1),
                new Butter(2)
            };

            var recipe = new Recipe(ingredients);

            Assert.That(recipe.GetRecipe(), Has.Count.EqualTo(2));
            Assert.That(recipe.GetRecipe()[0].Name, Is.EqualTo("Sugar"));
        }

        [Test]
        public void Constructor_NullIngredients_ShouldCreateEmptyList()
        {
            var recipe = new Recipe(null);

            Assert.That(recipe.GetRecipe(), Is.Not.Null);
            Assert.That(recipe.GetRecipe(), Is.Empty);
        }

        [Test]
        public void IsValid_NoIngredients_ReturnsFalse()
        {
            var recipe = new Recipe(new List<Ingredient>());

            var result = recipe.IsValid();

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsValid_WithIngredients_ReturnsTrue()
        {
            var ingredients = new List<Ingredient>
            {
                new Sugar(1),
                new WheatFlour(2)
            };
            var recipe = new Recipe(ingredients);

            var result = recipe.IsValid();

            Assert.That(result, Is.True);
        }
    }
}