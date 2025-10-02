using CookieCookbook.Models;

namespace CookieCookbook.Tests.Models
{
    [TestFixture]
    public class SugarTest
    {
        [Test]
        public void Constructor_ValidId_ShouldSetPropertiesCorrectly()
        {
            var ingredient = new Sugar();

            Assert.That(ingredient.Id, Is.EqualTo(5));
            Assert.That(ingredient.Name, Is.EqualTo("Sugar"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Measure the required amount. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new Sugar();

            var result = ingredient.ToString();

            Assert.That(result, Is.EqualTo("Sugar. Measure the required amount. Add to other ingredients."));
        }
    }


    [TestFixture]
    public class WheatFlourTest
    {
        [Test]
        public void Constructor_ValidId_ShouldSetPropertiesCorrectly()
        {
            var ingredient = new WheatFlour();

            Assert.That(ingredient.Id, Is.EqualTo(1));
            Assert.That(ingredient.Name, Is.EqualTo("Wheat flour"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Sieve. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new WheatFlour();

            var result = ingredient.ToString();

            Assert.That(result, Is.EqualTo("Wheat flour. Sieve. Add to other ingredients."));
        }
    }

    [TestFixture]
    public class CoconutFlourTest
    {
        [Test]
        public void Constructor_ValidId_ShouldSetPropertiesCorrectly()
        {
            var ingredient = new CoconutFlour();

            Assert.That(ingredient.Id, Is.EqualTo(2));
            Assert.That(ingredient.Name, Is.EqualTo("Coconut flour"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Sieve. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new CoconutFlour();

            var result = ingredient.ToString();

            Assert.That(result, Is.EqualTo("Coconut flour. Sieve. Add to other ingredients."));
        }
    }

    [TestFixture]
    public class ButterTest
    {
        [Test]
        public void Constructor_ValidId_ShouldSetPropertiesCorrectly()
        {
            var ingredient = new Butter();

            Assert.That(ingredient.Id, Is.EqualTo(3));
            Assert.That(ingredient.Name, Is.EqualTo("Butter"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Melt. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new Butter();

            var result = ingredient.ToString();

            Assert.That(result, Is.EqualTo("Butter. Melt. Add to other ingredients."));
        }
    }

    [TestFixture]
    public class ChocolateTest
    {
        [Test]
        public void Constructor_ValidId_ShouldSetPropertiesCorrectly()
        {
            var ingredient = new Chocolate();

            Assert.That(ingredient.Id, Is.EqualTo(4));
            Assert.That(ingredient.Name, Is.EqualTo("Chocolate"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Melt in a water bath. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new Chocolate();

            var result = ingredient.ToString();

            Assert.That(result, Is.EqualTo("Chocolate. Melt in a water bath. Add to other ingredients."));
        }
    }

    [TestFixture]
    public class CinnamonTest
    {
        [Test]
        public void Constructor_ValidId_ShouldSetPropertiesCorrectly()
        {
            var ingredient = new Cinnamon();

            Assert.That(ingredient.Id, Is.EqualTo(6));
            Assert.That(ingredient.Name, Is.EqualTo("Cinnamon"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Take half a teaspoon. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new Cinnamon();

            var result = ingredient.ToString();

            Assert.That(result, Is.EqualTo("Cinnamon. Take half a teaspoon. Add to other ingredients."));
        }
    }

    [TestFixture]
    public class CardamomTest
    {
        [Test]
        public void Constructor_ValidId_ShouldSetPropertiesCorrectly()
        {
            var ingredient = new Cardamom();

            Assert.That(ingredient.Id, Is.EqualTo(7));
            Assert.That(ingredient.Name, Is.EqualTo("Cardamom"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Take half a teaspoon. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new Cardamom();

            var result = ingredient.ToString();

            Assert.That(result, Is.EqualTo("Cardamom. Take half a teaspoon. Add to other ingredients."));
        }
    }

    [TestFixture]
    public class CocoaPowderTest
    {
        [Test]
        public void Constructor_ValidId_ShouldSetPropertiesCorrectly()
        {
            var ingredient = new CocoaPowder();

            Assert.That(ingredient.Id, Is.EqualTo(8));
            Assert.That(ingredient.Name, Is.EqualTo("Cocoa powder"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Measure the required amount. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new CocoaPowder();

            var result = ingredient.ToString();

            Assert.That(result, Is.EqualTo("Cocoa powder. Measure the required amount. Add to other ingredients."));
        }
    }
}