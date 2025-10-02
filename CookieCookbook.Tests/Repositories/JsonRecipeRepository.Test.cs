using CookieCookbook.Models;
using CookieCookbook.Repositories;
using CookieCookbook.Repositories.Interfaces;
using Moq;

namespace CookieCookbook.Tests.Repositories
{ 
    [TestFixture]
    public class JsonRecipeRepositoryTests
    {
        private JsonRecipeRepository _repository;
        private Mock<IIngredientRepository>? _ingredientRepo;
        private string _testFilePath;

        [SetUp]
        public void SetUp()
        {
            _ingredientRepo = new Mock<IIngredientRepository>();
            _repository = new JsonRecipeRepository(_ingredientRepo.Object);
            _testFilePath = "./recipes.json";
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
                    new Sugar(1),
                    new Butter(2)
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
                    new Sugar(1),
                    new Butter(2)
                }),
                new Recipe(new List<Ingredient>
                {
                    new Cardamom(6),
                    new Cinnamon(7),
                    new CocoaPowder(8)
                })
            };

            _ingredientRepo!.Setup(ir => ir.GetById(1)).Returns(new Sugar(1));
            _ingredientRepo!.Setup(ir => ir.GetById(2)).Returns(new Butter(2));
            _ingredientRepo!.Setup(ir => ir.GetById(6)).Returns(new Cardamom(6));
            _ingredientRepo!.Setup(ir => ir.GetById(7)).Returns(new Cinnamon(7));
            _ingredientRepo!.Setup(ir => ir.GetById(8)).Returns(new CocoaPowder(8));

            _repository.SaveRecipes(_testFilePath, originalRecipes);
            var loadedRecipes = _repository.LoadRecipes(_testFilePath);

            Assert.That(loadedRecipes, Has.Count.EqualTo(2));
            Assert.That(loadedRecipes[0].GetRecipe(), Has.Count.EqualTo(2));
            Assert.That(loadedRecipes[0].GetRecipe()[0].Id, Is.EqualTo(1));
            Assert.That(loadedRecipes[1].GetRecipe(), Has.Count.EqualTo(3));
            Assert.That(loadedRecipes[1].GetRecipe()[0].Id, Is.EqualTo(6));
            _ingredientRepo.Verify(ir => ir.GetById(1), Times.Once);
            _ingredientRepo.Verify(ir => ir.GetById(2), Times.Once);
            _ingredientRepo.Verify(ir => ir.GetById(6), Times.Once);
            _ingredientRepo.Verify(ir => ir.GetById(7), Times.Once);
            _ingredientRepo.Verify(ir => ir.GetById(8), Times.Once);
        }
    }
}