using Moq;
using System.Net;
using Server.Controllers.Ingredients;
using Server.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Controllers.Ingredients.ingredientsControllerTests
{
    public class UpdateIngredientInPantryTests
    {
        [Test]
        public void IngredientSuccessfullyUpdated()
        {
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 0, MeasurementType.Volume);

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.UpdateIngredientInPantry(ingredient, sessionKey)).Returns(true);
            var controller = new IngredientsController(recipesService.Object);

            var result = controller.UpdateIngredientInPantry(ingredient.Name, (int) ingredient.MeasurementType,
                ingredient.Amount, sessionKey);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo("Ingredient successfully updated."));
                recipesService.Verify(mock => mock.UpdateIngredientInPantry(ingredient, sessionKey), Times.Once());
            });
        }

        [Test]
        public void ServiceFailedToUpdateIngredient()
        {
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 0, MeasurementType.Volume);
            const string exceptionMessage = "An exception was thrown";

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.UpdateIngredientInPantry(ingredient, sessionKey))
                          .Throws(new ArgumentException(exceptionMessage));
            var service = new IngredientsController(recipesService.Object);

            var result = service.UpdateIngredientInPantry(ingredient.Name, (int) ingredient.MeasurementType,
                ingredient.Amount, sessionKey);

            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.UpdateIngredientInPantry(ingredient, sessionKey), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(exceptionMessage));
            });
        }
    }
}