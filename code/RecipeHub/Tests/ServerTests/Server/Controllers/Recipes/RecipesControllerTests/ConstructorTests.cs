using Server.Controllers.Recipes;
using Server.Controllers.Users;
using Server.ErrorMessages;
using Shared_Resources.ErrorMessages;

namespace ServerTests.Server.Controllers.Recipes.RecipesControllerTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterRecipesController()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new RecipesController();
            });
        }

        [Test]
        public void ShouldNotAllowNullRecipesService()
        {
            var errorMessage = RecipesControllerErrorMessages.RecipesServiceCannotBeNull +
                               " (Parameter 'recipesService')";
            var message = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new RecipesController(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(errorMessage));
        }
    }
}
