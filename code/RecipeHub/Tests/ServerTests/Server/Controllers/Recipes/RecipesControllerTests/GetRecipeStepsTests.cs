using Moq;
using System.Net;
using Server.Controllers.Recipes;
using Server.Data.Settings;
using Server.Service.Recipes;
using Shared_Resources.Model.Recipes;

namespace ServerTests.Server.Controllers.Recipes.RecipesControllerTests
{
    public class GetRecipeStepsTests
    {
        [Test]
        public void RecipeStepsSuccessfullyRetrieved()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            var steps = new RecipeStep[] {
                new(0, "name", "instructions")
            };

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipeSteps(sessionKey, recipeId)).Returns(steps);
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipeSteps(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo(ServerSettings.DefaultSuccessfulConnectionMessage));
                Assert.That(result.Steps, Is.EqualTo(steps));
                recipesService.Verify(mock => mock.GetRecipeSteps(sessionKey, recipeId), Times.Once());
            });
        }

        [Test]
        public void ServiceFailedToFetchIngredients()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            const string errorMessage = "This is an exception";

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipeSteps(sessionKey, recipeId))
                          .Throws(new ArgumentException(errorMessage));
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipeSteps(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(errorMessage));
                recipesService.Verify(mock => mock.GetRecipeSteps(sessionKey, recipeId), Times.Once());
            });
        }

        [Test]
        public void ServiceWasUnauthorized()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            const string errorMessage = "This is an exception";

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipeSteps(sessionKey, recipeId))
                .Throws(new UnauthorizedAccessException(errorMessage));
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipeSteps(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.Unauthorized));
                Assert.That(result.Message, Is.EqualTo(errorMessage));
                recipesService.Verify(mock => mock.GetRecipeSteps(sessionKey, recipeId), Times.Once());
            });
        }
    }
}