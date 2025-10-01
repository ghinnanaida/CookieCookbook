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
                new Ingredient(1, "Sugar", "Add to other ingredients."),
                new Ingredient(2, "Butter", "Melt on low heat.")
            };

            var recipe = new Recipe(ingredients);

            Assert.That(recipe.Ingredients, Has.Count.EqualTo(2));
            Assert.That(recipe.Ingredients[0].Name, Is.EqualTo("Sugar"));
        }

        [Test]
        public void Constructor_NullIngredients_ShouldCreateEmptyList()
        {
            var recipe = new Recipe(null);

            Assert.That(recipe.Ingredients, Is.Not.Null);
            Assert.That(recipe.Ingredients, Is.Empty);
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
                new Ingredient(1, "Sugar", "1 cup"),
                new Ingredient(2, "Flour", "2 cups")
            };
            var recipe = new Recipe(ingredients);

            var result = recipe.IsValid();

            Assert.That(result, Is.True);
        }
    }
}