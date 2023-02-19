using Moq;
using System.Net;
using Server.Controllers.Ingredients;
using Server.Service.Ingredients;

namespace ServerTests.Server.Controllers.Ingredients.ingredientsControllerTests
{
    public class RemoveAllIngredientsFromPantryTests
    {
        [Test]
        public void IngredientSuccessfullyUpdated()
        {
            const string sessionKey = "Key";

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.RemoveAllIngredientsFromPantry(sessionKey)).Returns(true);
            var controller = new IngredientsController(recipesService.Object);

            var result = controller.RemoveAllIngredientsFromPantry(sessionKey);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo("Pantry successfully cleared."));
                recipesService.Verify(mock => mock.RemoveAllIngredientsFromPantry(sessionKey), Times.Once());
            });
        }

        [Test]
        public void ServiceFailedToUpdateIngredient()
        {
            const string sessionKey = "Key";
            const string exceptionMessage = "An exception was thrown";

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.RemoveAllIngredientsFromPantry(sessionKey))
                          .Throws(new ArgumentException(exceptionMessage));
            var service = new IngredientsController(recipesService.Object);

            var result = service.RemoveAllIngredientsFromPantry(sessionKey);

            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.RemoveAllIngredientsFromPantry(sessionKey), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(exceptionMessage));
            });
        }
    }
}