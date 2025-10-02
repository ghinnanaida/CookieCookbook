using CookieCookbook.Repositories.Interfaces;
using CookieCookbook.Services;
using CookieCookbook.Models;
using Moq;

namespace CookieCookbook.Tests.Services
{
    [TestFixture]
    public class RecipeServiceTests
    {
        private Mock<IRecipeRepository>? _mockRecipe;
        private RecipeService? _service;
        private string? _testFilePath;
        private IReadOnlyList<Ingredient> _testDataIngredients;

        [SetUp]
        public void SetUp()
        {
            _mockRecipe = new Mock<IRecipeRepository>();
            _testFilePath = "D:/Bootcamp-formulatrix/CookieCookbook/CookieCookbook.Tests/Helpers/recipes.txt";

            _testDataIngredients = new List<Ingredient>
            {
                new WheatFlour(1),
                new CoconutFlour(2),
                new Butter(3)
            };

            _mockRecipe.Setup(r => r.LoadRecipes(It.IsAny<string>())).Returns(new List<Recipe>());

            _service = new RecipeService( _mockRecipe.Object, _testFilePath);
        }

        [TearDown]
        public void TearDown()
        {
            _mockRecipe = null;
            _testFilePath = null;
            _service = null;
        }

        [Test]
        public void GetExistingRecipes_ValidRecipe_ShouldReturnRecipesFromRepository()
        {
            var expectedRecipes = new List<Recipe>
            {
                new Recipe(new List<Ingredient> { _testDataIngredients[0] })
            };
            _mockRecipe!.Setup(r => r.LoadRecipes(_testFilePath!)).Returns(expectedRecipes);

            var result = _service!.GetExistingRecipes();

            Assert.That(result, Has.Count.EqualTo(1));
            _mockRecipe!.Verify(r => r.LoadRecipes(_testFilePath!), Times.Once);
        }

        [Test]
        public void SaveRecipe_ValidRecipe_ShouldReturnTrueAndSave()
        {
            var recipe = new Recipe(new List<Ingredient> { _testDataIngredients[0] });
            var existingRecipes = new List<Recipe>();
            _mockRecipe!.Setup(r => r.LoadRecipes(_testFilePath!)).Returns(existingRecipes);

            var result = _service!.SaveRecipe(recipe);

            Assert.That(result, Is.True);
            _mockRecipe!.Verify(r => r.SaveRecipes(_testFilePath!, 
                It.Is<List<Recipe>>(recipes => recipes.Count == 1)), Times.Once);
        }

        [Test]
        public void SaveRecipe_EmptyRecipe_ShouldReturnFalseAndNotSave()
        {
            var recipe = new Recipe(new List<Ingredient>());

            var result = _service!.SaveRecipe(recipe);

            Assert.That(result, Is.False);
            _mockRecipe!.Verify(r => r.SaveRecipes(It.IsAny<string>(), 
                It.IsAny<List<Recipe>>()), Times.Never);
        }

        [Test]
        public void SaveRecipe_ValidRecipeWithExistRecipe_ShouldAppendToExistingRecipes()
        {
            var existingRecipes = new List<Recipe>
            {
                new Recipe(new List<Ingredient> { _testDataIngredients[0] })
            };
            _mockRecipe!.Setup(r => r.LoadRecipes(_testFilePath!)).Returns(existingRecipes);

            var newRecipe = new Recipe(new List<Ingredient> { _testDataIngredients[1] });

            var result = _service!.SaveRecipe(newRecipe);

            Assert.That(result, Is.True);
            _mockRecipe!.Verify(r => r.SaveRecipes(_testFilePath!, 
                It.Is<List<Recipe>>(recipes => recipes.Count == 2)), Times.Once);
        }

    }
}  