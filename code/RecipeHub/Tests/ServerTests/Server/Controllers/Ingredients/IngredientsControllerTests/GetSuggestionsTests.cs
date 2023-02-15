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
    public class GetSuggestionsTests
    {
        [Test]
        public void IngredientSuccessfullyUpdated()
        {
            const string ingredientName = "Key";
            var suggestions = new List<string>() {
                "item"
            };

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.GetAllIngredientsThatMatch(ingredientName)).Returns(suggestions);
            var controller = new IngredientsController(recipesService.Object);

            var result = controller.GetSuggestions(ingredientName);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo("Suggestions successfully retrieved."));
                recipesService.Verify(mock => mock.GetAllIngredientsThatMatch(ingredientName), Times.Once());
            });
        }
        
        [Test]
        public void ServiceFailedToUpdateIngredient()
        {
            const string ingredientName = "Key";
            const string exceptionMessage = "An exception was thrown";

            var recipesService = new Mock<IIngredientsService>();

            recipesService.Setup(mock => mock.GetAllIngredientsThatMatch(ingredientName)).Throws(new ArgumentException(exceptionMessage));
            var service = new IngredientsController(recipesService.Object);

            var result = service.GetSuggestions(ingredientName);
            
            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.GetAllIngredientsThatMatch(ingredientName), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(exceptionMessage));
            });
        }
    }
}
