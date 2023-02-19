using Moq;
using System.Net;
using Server.Controllers.Recipes;
using Server.Data.Settings;
using Server.Service.Recipes;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Controllers.Recipes.RecipesControllerTests
{
    public class GetRecipeIngredientsTests
    {
        [Test]
        public void RecipeIngredientsSuccessfullyRetrieved()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            var ingredients = new Ingredient[] {
                new("name", 1, MeasurementType.Volume)
            };

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipeIngredients(sessionKey, recipeId)).Returns(ingredients);
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipeIngredients(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo(ServerSettings.DefaultSuccessfulConnectionMessage));
                Assert.That(result.Ingredients, Is.EqualTo(ingredients));
                recipesService.Verify(mock => mock.GetRecipeIngredients(sessionKey, recipeId), Times.Once());
            });
        }

        [Test]
        public void ServiceFailedToFetchIngredients()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            const string errorMessage = "This is an exception";

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipeIngredients(sessionKey, recipeId))
                          .Throws(new ArgumentException(errorMessage));
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipeIngredients(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(errorMessage));
                recipesService.Verify(mock => mock.GetRecipeIngredients(sessionKey, recipeId), Times.Once());
            });
        }
    }
}