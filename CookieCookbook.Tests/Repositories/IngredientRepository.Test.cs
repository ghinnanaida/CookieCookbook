using CookieCookbook.Repositories;

namespace CookieCookbook.Tests.Repositories
{
    [TestFixture]
    public class IIngredientRepositoryTests
    {
        private IngredientRepository? _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new IngredientRepository();
        }

        [Test]
        public void GetAllAvailable_WithValidData_ReturnAllIngredients()
        {
            var ingredients = _repository!.GetAllAvailable();

            Assert.That(ingredients, Has.Count.EqualTo(8));
            Assert.That(ingredients[0].Id, Is.EqualTo(1));
            Assert.That(ingredients[0].Name, Is.EqualTo("Wheat flour"));
            for (int i = 0; i < ingredients.Count - 1; i++)
            {
                Assert.That(ingredients[i].Id, Is.LessThan(ingredients[i + 1].Id));
            }
        }

        [Test]
        public void GetById_ExistingId_ReturnIngredient()
        {
            var ingredient = _repository!.GetById(1);

            Assert.That(ingredient, Is.Not.Null);
            Assert.That(ingredient.Name, Is.EqualTo("Wheat flour"));
        }

        [Test]
        public void GetById_NonExistingId_ReturnNull()
        {
            var ingredient = _repository!.GetById(10);

            Assert.That(ingredient, Is.Null);
        }


    }
}