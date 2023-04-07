using System.Net;
using Moq;
using Server.Controllers.Ingredients;
using Server.Data.Settings;
using Server.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Controllers.Ingredients.IngredientsControllerTests
{
    public class RemoveIngredientsForRecipeTests
    {
        [Test]
        public void ShouldGetMissingIngredients()
        {
            const string sessionKey = "Key";
            var ingredients = new List<Ingredient> {
                new()
            };

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.RemoveIngredientsForRecipe(1, sessionKey));
            var controller = new IngredientsController(recipesService.Object);

            var result = controller.RemoveIngredientsForRecipe(1, sessionKey);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo(ServerSettings.DefaultSuccessfulConnectionMessage));
                recipesService.Verify(mock => mock.RemoveIngredientsForRecipe(1, sessionKey), Times.Once());
            });
        }

        [Test]
        public void ShouldNotGetMissingIngredientsForUnauthorizedException()
        {
            const string sessionKey = "Key";
            const string exceptionMessage = "An exception was thrown";

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.RemoveIngredientsForRecipe(1, sessionKey))
                .Throws(new UnauthorizedAccessException(exceptionMessage));
            var service = new IngredientsController(recipesService.Object);

            var result = service.RemoveIngredientsForRecipe(1, sessionKey);

            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.RemoveIngredientsForRecipe(1, sessionKey), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.Unauthorized));
                Assert.That(result.Message, Is.EqualTo(exceptionMessage));
            });
        }

        [Test]
        public void ShouldNotGetMissingIngredientsForException()
        {
            const string sessionKey = "Key";
            const string exceptionMessage = "An exception was thrown";

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.RemoveIngredientsForRecipe(1, sessionKey))
                .Throws(new ArgumentException(exceptionMessage));
            var service = new IngredientsController(recipesService.Object);

            var result = service.RemoveIngredientsForRecipe(1, sessionKey);

            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.RemoveIngredientsForRecipe(1, sessionKey), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(exceptionMessage));
            });
        }
    }
}
