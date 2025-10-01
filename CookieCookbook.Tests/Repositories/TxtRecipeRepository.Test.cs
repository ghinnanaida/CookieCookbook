using CookieCookbook.Models;
using CookieCookbook.Repositories;
using CookieCookbook.Repositories.Interfaces;
using Moq;

namespace CookieCookbook.Tests.Repositories
{ 
    [TestFixture]
    public class TxtRecipeRepositoryTests
    {
        private TxtRecipeRepository _repository;
        private Mock<IIngredientRepository>? _ingredientRepo;
        private string _testFilePath;

        [SetUp]
        public void SetUp()
        {
            _ingredientRepo = new Mock<IIngredientRepository>();
            _repository = new TxtRecipeRepository(_ingredientRepo.Object);
            _testFilePath = "D:/Bootcamp-formulatrix/CookieCookbook/CookieCookbook.Tests/Helpers/recipes.txt";
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [Test]
        public void LoadRecipes_WhenFileDoesNotExist_ShouldReturnEmptyList()
        {
            var recipes = _repository.LoadRecipes(_testFilePath);

            Assert.That(recipes, Is.Empty);
        }

        [Test]
        public void SaveRecipes_ValidRecipe_ShouldCreateFile()
        {
            var recipes = new List<Recipe>
            {
                new Recipe(new List<Ingredient>
                {
                    new Ingredient(1, "Sugar", "Add to other ingredients."),
                    new Ingredient(2, "Butter", "Melt on low heat.")
                })
            };

            _repository.SaveRecipes(_testFilePath, recipes);

            Assert.That(File.Exists(_testFilePath), Is.True);
        }

        [Test]
        public void SaveAndLoadRecipes_ShouldPersistData()
        {
            var originalRecipes = new List<Recipe>
            {
                new Recipe(new List<Ingredient>
                {
                    new Ingredient(1, "Sugar", "Add to other ingredients."),
                    new Ingredient(2, "Butter", "Melt on low heat.")
                }),
                new Recipe(new List<Ingredient>
                {
                    new Ingredient(6, "Cardamom", "Take half a teaspoon. Add to other ingredients.") ,
                    new Ingredient(7, "Cinnamon", "Take half a teaspoon. Add to other ingredients.") ,
                    new Ingredient(8, "Cocoa powder", "Add to other ingredients.")
                })
            };

            _ingredientRepo!.Setup(ir => ir.GetById(1)).Returns(new Ingredient(1, "Sugar", "Add to other ingredients."));
            _ingredientRepo!.Setup(ir => ir.GetById(2)).Returns(new Ingredient(2, "Butter", "Melt on low heat."));
            _ingredientRepo!.Setup(ir => ir.GetById(6)).Returns(new Ingredient(6, "Cardamom", "Take half a teaspoon. Add to other ingredients."));
            _ingredientRepo!.Setup(ir => ir.GetById(7)).Returns(new Ingredient(7, "Cinnamon", "Take half a teaspoon. Add to other ingredients."));
            _ingredientRepo!.Setup(ir => ir.GetById(8)).Returns(new Ingredient(8, "Cocoa powder", "Add to other ingredients."));

            _repository.SaveRecipes(_testFilePath, originalRecipes);
            var loadedRecipes = _repository.LoadRecipes(_testFilePath);

            Assert.That(loadedRecipes, Has.Count.EqualTo(2));
            Assert.That(loadedRecipes[0].Ingredients, Has.Count.EqualTo(2));
            Assert.That(loadedRecipes[0].Ingredients[0].Id, Is.EqualTo(1));
            Assert.That(loadedRecipes[1].Ingredients, Has.Count.EqualTo(3));
            Assert.That(loadedRecipes[1].Ingredients[0].Id, Is.EqualTo(6));
            _ingredientRepo.Verify(ir => ir.GetById(1), Times.Once);
            _ingredientRepo.Verify(ir => ir.GetById(2), Times.Once);
            _ingredientRepo.Verify(ir => ir.GetById(6), Times.Once);
            _ingredientRepo.Verify(ir => ir.GetById(7), Times.Once);
            _ingredientRepo.Verify(ir => ir.GetById(8), Times.Once);
        }
    }
}