using CookieCookbook.Models;

namespace CookieCookbook.Tests.Models
{
    [TestFixture]
    public class SugarTest
    {
        [Test]
        public void Constructor_ValidId_ShouldSetPropertiesCorrectly()
        {
            var ingredient = new Sugar(1);

            Assert.That(ingredient.Id, Is.EqualTo(1));
            Assert.That(ingredient.Name, Is.EqualTo("Sugar"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new Sugar(1);

            var result = ingredient.ToString();

            Assert.That(result, Is.EqualTo("Sugar. Add to other ingredients."));
        }
    }


    [TestFixture]
    public class WheatFlourTest
    {
        [Test]
        public void Constructor_ValidId_ShouldSetPropertiesCorrectly()
        {
            var ingredient = new WheatFlour(1);

            Assert.That(ingredient.Id, Is.EqualTo(1));
            Assert.That(ingredient.Name, Is.EqualTo("Wheat flour"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Sieve. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new WheatFlour(1);

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
            var ingredient = new CoconutFlour(1);

            Assert.That(ingredient.Id, Is.EqualTo(1));
            Assert.That(ingredient.Name, Is.EqualTo("Coconut flour"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Sieve. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new CoconutFlour(1);

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
            var ingredient = new Butter(1);

            Assert.That(ingredient.Id, Is.EqualTo(1));
            Assert.That(ingredient.Name, Is.EqualTo("Butter"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Melt. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new Butter(1);

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
            var ingredient = new Chocolate(1);

            Assert.That(ingredient.Id, Is.EqualTo(1));
            Assert.That(ingredient.Name, Is.EqualTo("Chocolate"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Melt in a water bath. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new Chocolate(1);

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
            var ingredient = new Cinnamon(1);

            Assert.That(ingredient.Id, Is.EqualTo(1));
            Assert.That(ingredient.Name, Is.EqualTo("Cinnamon"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Take half a teaspoon. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new Cinnamon(1);

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
            var ingredient = new Cardamom(1);

            Assert.That(ingredient.Id, Is.EqualTo(1));
            Assert.That(ingredient.Name, Is.EqualTo("Cardamom"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Take half a teaspoon. Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new Cardamom(1);

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
            var ingredient = new CocoaPowder(1);

            Assert.That(ingredient.Id, Is.EqualTo(1));
            Assert.That(ingredient.Name, Is.EqualTo("Cocoa powder"));
            Assert.That(ingredient.GetPreparationInstruction(), Is.EqualTo("Add to other ingredients."));
        }

        [Test]
        public void ToString_ValidIngredient_ReturnsCorrectFormat()
        {
            var ingredient = new CocoaPowder(1);

            var result = ingredient.ToString();

            Assert.That(result, Is.EqualTo("Cocoa powder. Add to other ingredients."));
        }
    }
}