using Moq;
using System.Net;
using Server.Controllers.Ingredients;
using Server.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Controllers.Ingredients.ingredientsControllerTests
{
    public class AddIngredientToPantryTests
    {
        [Test]
        public void IngredientSuccessfullyAdded()
        {
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 0, MeasurementType.Volume);

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.AddIngredientToPantry(ingredient, sessionKey)).Returns(true);
            recipesService.Setup(mock => mock.AddIngredientToPantry(ingredient, sessionKey)).Returns(true);
            var controller = new IngredientsController(recipesService.Object);

            var result = controller.AddIngredientToPantry(ingredient.Name, (int) ingredient.MeasurementType,
                ingredient.Amount, sessionKey);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo("Ingredient successfully added."));
                recipesService.Verify(mock => mock.AddIngredientToPantry(ingredient, sessionKey), Times.Once());
            });
        }

        [Test]
        public void ServiceFailedToAddIngredient()
        {
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 0, MeasurementType.Volume);
            const string exceptionMessage = "An exception was thrown";

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.AddIngredientToPantry(ingredient, sessionKey))
                          .Throws(new ArgumentException(exceptionMessage));
            var service = new IngredientsController(recipesService.Object);

            var result = service.AddIngredientToPantry(ingredient.Name, (int) ingredient.MeasurementType,
                ingredient.Amount, sessionKey);

            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.AddIngredientToPantry(ingredient, sessionKey), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(exceptionMessage));
            });
        }
    }
}