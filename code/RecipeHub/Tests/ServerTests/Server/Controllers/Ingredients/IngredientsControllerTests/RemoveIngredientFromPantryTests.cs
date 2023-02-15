using Moq;
using System.Net;
using Server.Controllers.Ingredients;
using Server.Controllers.Recipes;
using Server.Data.Settings;
using Server.ErrorMessages;
using Server.Service.Ingredients;
using Server.Service.Recipes;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Controllers.Ingredients.ingredientsControllerTests
{
    public class RemoveIngredientFromPantryTests
    {
        [Test]
        public void IngredientSuccessfullyRemoved()
        {
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 0, MeasurementType.Volume);

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.RemoveIngredientFromPantry(ingredient, sessionKey)).Returns(true);
            var controller = new IngredientsController(recipesService.Object);

            var result = controller.RemoveIngredientFromPantry(ingredient.Name, (int)ingredient.MeasurementType, ingredient.Amount, sessionKey);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo("Ingredient successfully removed from pantry."));
                recipesService.Verify(mock => mock.RemoveIngredientFromPantry(ingredient, sessionKey), Times.Once());
            });
        }
        
        [Test]
        public void ServiceFailedToRemoveIngredient()
        {
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 0, MeasurementType.Volume);
            const string exceptionMessage = "An exception was thrown";

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.RemoveIngredientFromPantry(ingredient, sessionKey)).Throws(new ArgumentException(exceptionMessage));
            var service = new IngredientsController(recipesService.Object);

            var result = service.RemoveIngredientFromPantry(ingredient.Name, (int)ingredient.MeasurementType, ingredient.Amount, sessionKey);
            
            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.RemoveIngredientFromPantry(ingredient, sessionKey), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(exceptionMessage));
            });
        }
    }
}
