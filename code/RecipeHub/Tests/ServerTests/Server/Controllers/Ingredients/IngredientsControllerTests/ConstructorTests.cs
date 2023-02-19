using Server.Controllers.Ingredients;
using Server.Service.Ingredients;

namespace ServerTests.Server.Controllers.Ingredients.IngredientsControllerTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterRecipesController()
        {
            Assert.DoesNotThrow(() => { _ = new IngredientsController(); });
        }

        [Test]
        public void ShouldCreateOneParameterRecipesController()
        {
            Assert.DoesNotThrow(() => { _ = new IngredientsController(new IngredientsService()); });
        }

        [Test]
        public void ShouldNotAllowNullRecipesService()
        {
            const string errorMessage = "Value cannot be null. (Parameter 'service')";
            var message = Assert.Throws<ArgumentNullException>(() => { _ = new IngredientsController(null!); })
                                ?.Message;
            Assert.That(message, Is.EqualTo(errorMessage));
        }
    }
}