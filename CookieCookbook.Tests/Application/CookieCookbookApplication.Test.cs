using CookieCookbook.Services;
using CookieCookbook.Views;
using CookieCookbook.Models;
using Moq;

namespace CookieCookbook.Tests
{
    [TestFixture]
    public class CookieRecipeApplicationTests
    {
        private CookieRecipeApplication? _application;
        private Mock<IUserInterface> _mockUi;
        private Mock<IRecipeService> _mockRecipeService;
        private Mock<IIngredientService> _mockIngredientService;
        private List<Ingredient> _testDataIngredients;

        [SetUp]
        public void SetUp()
        {
            _mockUi = new Mock<IUserInterface>();
            _mockRecipeService = new Mock<IRecipeService>();
            _mockIngredientService = new Mock<IIngredientService>();

            _testDataIngredients = new List<Ingredient>
            {
                new WheatFlour(),
                new CoconutFlour(),
                new Butter()
            };

            _mockIngredientService.Setup(s => s.GetAvailableIngredients()).Returns(_testDataIngredients);
            _mockRecipeService.Setup(s => s.GetExistingRecipes()).Returns(new List<Recipe>());

            _application = new CookieRecipeApplication(_mockUi.Object, _mockRecipeService.Object, _mockIngredientService.Object);
        }

        [Test]
        public void Run_ValidIngredients_ShouldSaveRecipe()
        {
            var inputs = new Queue<string>(new[] { "1", "2", "done" });
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns(() => inputs.Dequeue());
            _mockIngredientService.Setup(s => s.GetIngredientById(1)).Returns(_testDataIngredients[0]);
            _mockIngredientService.Setup(s => s.GetIngredientById(2)).Returns(_testDataIngredients[1]);
            _mockRecipeService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(true);

            _application!.Run();

            _mockRecipeService.Verify(s => s.SaveRecipe(It.Is<Recipe>(r => r.GetRecipe().Count == 2)), Times.Once);
            _mockUi.Verify(u => u.DisplayRecipeSaved(It.IsAny<Recipe>()), Times.Once);
            _mockIngredientService.Verify(s => s.GetIngredientById(1), Times.Once);
            _mockIngredientService.Verify(s => s.GetIngredientById(2), Times.Once);
        }

        [Test]
        public void Run_NoIngredients_ShouldNotSaveRecipe()
        {
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns("done");
            _mockRecipeService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(false);

            _application!.Run();

            _mockRecipeService.Verify(s => s.SaveRecipe(It.Is<Recipe>(r => r.GetRecipe().Count == 0)), Times.Once);
            _mockUi.Verify(u => u.DisplayMessage("No ingredients have been selected. Recipe will not be saved."), Times.Once);
            _mockUi.Verify(u => u.DisplayRecipeSaved(It.IsAny<Recipe>()), Times.Never);
        }

        [Test]
        public void Run_InvalidId_ShouldIgnoreInvalidIngredient()
        {
            var inputs = new Queue<string>(new[] { "999", "1", "done" });
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns(() => inputs.Dequeue());

            _mockIngredientService.Setup(s => s.GetIngredientById(999)).Returns((Ingredient?)null);
            _mockIngredientService.Setup(s => s.GetIngredientById(1)).Returns(_testDataIngredients[0]);
            _mockRecipeService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(true);

            _application!.Run();

            _mockRecipeService.Verify(s => s.SaveRecipe(It.Is<Recipe>(r => r.GetRecipe().Count == 1)), Times.Once);
            _mockIngredientService.Verify(s => s.GetIngredientById(999), Times.Once);
            _mockIngredientService.Verify(s => s.GetIngredientById(1), Times.Once);
        }

        [Test]
        public void Run_ExistingRecipes_ShouldDisplayThem()
        {
            var existingRecipes = new List<Recipe>
            {
                new Recipe(new List<Ingredient> { _testDataIngredients[0] })
            };
            _mockRecipeService.Setup(s => s.GetExistingRecipes()).Returns(existingRecipes);
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns("done");
            _mockRecipeService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(false);

            _application!.Run();

            _mockUi.Verify(u => u.DisplayExistingRecipes(It.Is<List<Recipe>>(r => r.Count == 1)), Times.Once);
            _mockRecipeService.Verify(s => s.GetExistingRecipes(), Times.Once);
        }

        [Test]
        public void Run_ValidIngredient_ShouldDisplayAvailableIngredients()
        {
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns("done");
            _mockRecipeService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(false);

            _application!.Run();

            _mockUi.Verify(u => u.DisplayAvailableIngredients(It.Is<List<Ingredient>>(i => i.Count == 3)), Times.Once);
            _mockIngredientService.Verify(s => s.GetAvailableIngredients(), Times.Once);
        }

        [Test]
        public void Run_ShouldAlwaysWaitForExit()
        {
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns("done");
            _mockRecipeService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(false);

            _application!.Run();

            _mockUi.Verify(u => u.WaitForExit(), Times.Once);
        }

        [Test]
        public void Run_DuplicateIngredients_ShouldAllowThem()
        {
            var inputs = new Queue<string>(new[] { "1", "1", "1", "done" });
            _mockUi.Setup(u => u.PromptForIngredientId()).Returns(() => inputs.Dequeue());
            _mockIngredientService.Setup(s => s.GetIngredientById(1)).Returns(_testDataIngredients[0]);
            _mockRecipeService.Setup(s => s.SaveRecipe(It.IsAny<Recipe>())).Returns(true);

            _application!.Run();

            _mockRecipeService.Verify(s => s.SaveRecipe(It.Is<Recipe>(r => r.GetRecipe().Count == 3)), Times.Once);
            _mockIngredientService.Verify(s => s.GetIngredientById(1), Times.Exactly(3));
        }
    }
}