using Server.Controllers.Recipes;
using Server.ErrorMessages;

namespace ServerTests.Server.Controllers.Recipes.RecipesControllerTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterRecipesController()
        {
            Assert.DoesNotThrow(() => { _ = new RecipesController(); });
        }

        [Test]
        public void ShouldNotAllowNullRecipesService()
        {
            const string errorMessage = RecipesControllerErrorMessages.RecipesServiceCannotBeNull +
                                        " (Parameter 'recipesService')";
            var message = Assert.Throws<ArgumentNullException>(() => { _ = new RecipesController(null!); })?.Message;
            Assert.That(message, Is.EqualTo(errorMessage));
        }
    }
}