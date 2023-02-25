using Moq;
using System.Net;
using Server.Controllers.Recipes;
using Server.Data.Settings;
using Server.Service.Recipes;

namespace ServerTests.Server.Controllers.Recipes.RecipesControllerTests
{
    public class GetTypesForRecipeTests
    {
        [Test]
        public void RecipeTypesSuccessfullyRetrieved()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            var types = new[] {
                "breakfast",
                "lunch"
            };

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetTypesForRecipe(sessionKey, recipeId)).Returns(types);
            var service = new RecipesController(recipesService.Object);

            var result = service.GetTypesForRecipe(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo(ServerSettings.DefaultSuccessfulConnectionMessage));
                Assert.That(result.Types, Is.EqualTo(types));
                recipesService.Verify(mock => mock.GetTypesForRecipe(sessionKey, recipeId), Times.Once());
            });
        }

        [Test]
        public void ServiceFailedToFetchIngredients()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            const string errorMessage = "This is an exception";

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetTypesForRecipe(sessionKey, recipeId))
                          .Throws(new ArgumentException(errorMessage));
            var service = new RecipesController(recipesService.Object);

            var result = service.GetTypesForRecipe(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(errorMessage));
                recipesService.Verify(mock => mock.GetTypesForRecipe(sessionKey, recipeId), Times.Once());
            });
        }

        [Test]
        public void ServiceWasUnauthorized()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            const string errorMessage = "This is an exception";

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetTypesForRecipe(sessionKey, recipeId))
                .Throws(new UnauthorizedAccessException(errorMessage));
            var service = new RecipesController(recipesService.Object);

            var result = service.GetTypesForRecipe(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.Unauthorized));
                Assert.That(result.Message, Is.EqualTo(errorMessage));
                recipesService.Verify(mock => mock.GetTypesForRecipe(sessionKey, recipeId), Times.Once());
            });
        }
    }
}