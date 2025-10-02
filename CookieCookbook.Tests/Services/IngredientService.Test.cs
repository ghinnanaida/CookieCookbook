using CookieCookbook.Repositories.Interfaces;
using CookieCookbook.Services;
using CookieCookbook.Models;
using Moq;

namespace CookieCookbook.Tests.Services
{
    [TestFixture]
    public class IngredientServiceTests
    {
        private Mock<IIngredientRepository>? _mockIngredient;
        private IngredientService? _service;
        private List<Ingredient> _testDataIngredients;

        [SetUp]
        public void SetUp()
        {
            _mockIngredient = new Mock<IIngredientRepository>();

            _testDataIngredients = new List<Ingredient>
            {
                new WheatFlour(1),
                new CoconutFlour(2),
                new Butter(3)
            };

            _mockIngredient.Setup(r => r.GetAllAvailable()).Returns(_testDataIngredients);

            _service = new IngredientService(_mockIngredient.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockIngredient = null;
            _service = null;
        }

        [Test]
        public void GetAvailableIngredients_ValidIngredients_ShouldReturnAllIngredients()
        {
            var result = _service!.GetAvailableIngredients();

            Assert.That(result, Has.Count.EqualTo(3));
            Assert.That(result[0].Name, Is.EqualTo("Wheat flour"));
            _mockIngredient!.Verify(r => r.GetAllAvailable(), Times.Once);
        }

        [Test]
        public void GetIngredientById_ValidId_ShouldReturnIngredient()
        {
            _mockIngredient!.Setup(r => r.GetById(1)).Returns(_testDataIngredients[0]);

            var result = _service!.GetIngredientById(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Wheat flour"));
            _mockIngredient!.Verify(r => r.GetById(1), Times.Once);
        }

        [Test]
        public void GetIngredientById_InvalidId_ShouldReturnNull()
        {
            _mockIngredient!.Setup(r => r.GetById(999)).Returns((Ingredient?)null);

            var result = _service!.GetIngredientById(999);

            Assert.That(result, Is.Null);
            _mockIngredient!.Verify(r => r.GetById(999), Times.Once);
        }

    }
}  