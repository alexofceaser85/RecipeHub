using Moq;
using System.Net;
using Server.Controllers.Ingredients;
using Server.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Controllers.Ingredients.ingredientsControllerTests
{
    public class GetIngredientsInPantryTests
    {
        [Test]
        public void IngredientSuccessfullyUpdated()
        {
            const string sessionKey = "Key";
            var ingredients = new List<Ingredient> {
                new()
            };

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.GetIngredientsFor(sessionKey)).Returns(ingredients);
            var controller = new IngredientsController(recipesService.Object);

            var result = controller.GetIngredientsInPantry(sessionKey);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo("Ingredients successfully retrieved."));
                recipesService.Verify(mock => mock.GetIngredientsFor(sessionKey), Times.Once());
            });
        }

        [Test]
        public void ServiceFailedToUpdateIngredient()
        {
            const string sessionKey = "Key";
            const string exceptionMessage = "An exception was thrown";

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.GetIngredientsFor(sessionKey))
                          .Throws(new ArgumentException(exceptionMessage));
            var service = new IngredientsController(recipesService.Object);

            var result = service.GetIngredientsInPantry(sessionKey);

            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.GetIngredientsFor(sessionKey), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(exceptionMessage));
            });
        }
    }
}