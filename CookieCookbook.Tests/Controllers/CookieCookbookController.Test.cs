using CookieCookbook.Controllers;
using CookieCookbook.Services;
using CookieCookbook.Views;
using CookieCookbook.Models;
using Moq;

namespace CookieCookbook.Tests.Controllers
{
    [TestFixture]
    public class CookieRecipeControllerTests
    {
        private CookieRecipeController? _controller;
        private Mock<IUserInterface> _mockUi;
        private Mock<IRecipeService> _mockService;
        private string? _testFilePath;
        private List<Ingredient> _testDataIngredients;

        [SetUp]
        public void SetUp()
        {
            _testFilePath = "D:/Bootcamp-formulatrix/CookieCookbook/CookieCookbook.Tests/Helpers/recipes.txt";
            _mockUi = new Mock<IUserInterface>();
            _mockService = new Mock<IRecipeService>();

            _testDataIngredients = new List<Ingredient>
            {
                new Ingredient(1, "Wheat flour", "Sieve. Add to other ingredients."),
                new Ingredient(2, "Coconut flour", "Sieve. Add to other ingredients."),
                new Ingredient(3, "Butter", "Melt on low heat. Add to other ingredients.")
            };

            _mockService.Setup(s => s.GetAvailableIngredients()).Returns(_testDataIngredients);
            _mockService.Setup(s => s.GetExistingRecipes()).Returns(new List<Recipe>());

            _controller = new CookieRecipeController(_mockUi.Object, _mockService.Object);
        }

        [Test]
        public void Run_ValidIngredients_ShouldSaveRecipe()
        {
            var inputs = new Queue<string>(new[] { "1", "2", "done" });
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns(() => inputs.Dequeue());
            _mockService.Setup(s => s.GetIngredientById(1)).Returns(_testDataIngredients[0]);
            _mockService.Setup(s => s.GetIngredientById(2)).Returns(_testDataIngredients[1]);
            _mockService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(true);

            _controller!.Run();

            _mockService.Verify(s => s.SaveRecipe(It.Is<Recipe>(r => r.Ingredients.Count == 2)), Times.Once);
            _mockUi.Verify(u => u.DisplayRecipeSaved(It.IsAny<Recipe>()), Times.Once);
            _mockService.Verify(s => s.GetIngredientById(1), Times.Once);
            _mockService.Verify(s => s.GetIngredientById(2), Times.Once);
        }

        [Test]
        public void Run_NoIngredients_ShouldNotSaveRecipe()
        {
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns("done");
            _mockService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(false);

            _controller!.Run();

            _mockService.Verify(s => s.SaveRecipe(It.Is<Recipe>(r => r.Ingredients.Count == 0)), Times.Once);
            _mockUi.Verify(u => u.DisplayMessage("No ingredients have been selected. Recipe will not be saved."), Times.Once);
            _mockUi.Verify(u => u.DisplayRecipeSaved(It.IsAny<Recipe>()), Times.Never);
        }

        [Test]
        public void Run_InvalidId_ShouldIgnoreInvalidIngredient()
        {
            var inputs = new Queue<string>(new[] { "999", "1", "done" });
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns(() => inputs.Dequeue());

            _mockService.Setup(s => s.GetIngredientById(999)).Returns((Ingredient?)null);
            _mockService.Setup(s => s.GetIngredientById(1)).Returns(_testDataIngredients[0]);
            _mockService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(true);

            _controller!.Run();

            _mockService.Verify(s => s.SaveRecipe(It.Is<Recipe>(r => r.Ingredients.Count == 1)), Times.Once);
            _mockService.Verify(s => s.GetIngredientById(999), Times.Once);
            _mockService.Verify(s => s.GetIngredientById(1), Times.Once);
        }

        [Test]
        public void Run_ExistingRecipes_ShouldDisplayThem()
        {
            var existingRecipes = new List<Recipe>
            {
                new Recipe(new List<Ingredient> { _testDataIngredients[0] })
            };
            _mockService.Setup(s => s.GetExistingRecipes()).Returns(existingRecipes);
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns("done");
            _mockService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(false);

            _controller!.Run();

            _mockUi.Verify(u => u.DisplayExistingRecipes(It.Is<List<Recipe>>(r => r.Count == 1)), Times.Once);
            _mockService.Verify(s => s.GetExistingRecipes(), Times.Once);
        }

        [Test]
        public void Run_ValidIngredient_ShouldDisplayAvailableIngredients()
        {
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns("done");
            _mockService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(false);

            _controller!.Run();

            _mockUi.Verify(u => u.DisplayAvailableIngredients(It.Is<List<Ingredient>>(i => i.Count == 3)), Times.Once);
            _mockService.Verify(s => s.GetAvailableIngredients(), Times.Once);
        }

        [Test]
        public void Run_ShouldAlwaysWaitForExit()
        {
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns("done");
            _mockService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(false);

            _controller!.Run();

            _mockUi.Verify(u => u.WaitForExit(), Times.Once);
        }

        [Test]
        public void Run_DuplicateIngredients_ShouldAllowThem()
        {
            var inputs = new Queue<string>(new[] { "1", "1", "1", "done" });
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns(() => inputs.Dequeue());
            _mockService.Setup(s => s.GetIngredientById(1)).Returns(_testDataIngredients[0]);
            _mockService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(true);

            _controller!.Run();

            _mockService.Verify(s => s.SaveRecipe(It.Is<Recipe>(r => r.Ingredients.Count == 3)), Times.Once);
            _mockService.Verify(s => s.GetIngredientById(1), Times.Exactly(3));
        }
    }
}