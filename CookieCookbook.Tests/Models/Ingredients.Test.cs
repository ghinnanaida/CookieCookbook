using CookieCookbook.Models;

namespace CookieCookbook.Tests.Models
{
    [TestFixture]
    public class IngredientsTest
    {
        [Test]
        public void Constructor_ValidIngredient_ShouldSetPropertiesCorrectly()
        {
            var ingredient = new Ingredient(1, "Sugar", "Add to other ingredients.");

            Assert.That(ingredient.Id, Is.EqualTo(1));
            Assert.That(ingredient.Name, Is.EqualTo("Sugar"));
            Assert.That(ingredient.PreparationInstruction, Is.EqualTo("Add to other ingredients."));
        }
        
        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new Ingredient(1, "Sugar", "1 cup");

            var result = ingredient.ToString();

            Assert.That(result, Is.EqualTo("Sugar. 1 cup"));
        }
    }
}