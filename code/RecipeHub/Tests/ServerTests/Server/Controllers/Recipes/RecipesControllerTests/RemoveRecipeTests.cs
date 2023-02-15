using Moq;
using System.Net;
using Server.Controllers.Recipes;
using Server.Data.Settings;
using Server.ErrorMessages;
using Server.Service.Recipes;

namespace ServerTests.Server.Controllers.Recipes.RecipesControllerTests
{
    public class RemoveRecipeTests
    {
        [Test]
        public void RecipeSuccessfullyAdded()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.RemoveRecipe(sessionKey, recipeId)).Returns(true);
            var service = new RecipesController(recipesService.Object);

            var result = service.RemoveRecipe(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo(ServerSettings.DefaultSuccessfulConnectionMessage));
                recipesService.Verify(mock => mock.RemoveRecipe(sessionKey, recipeId), Times.Once());
            });
        }

        [Test]
        public void DatabaseFailedToAddRecipe()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.RemoveRecipe(sessionKey, recipeId)).Returns(false);
            var service = new RecipesController(recipesService.Object);

            var result = service.RemoveRecipe(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.RemoveRecipe(sessionKey, recipeId), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(RecipesControllerErrorMessages.RecipeFailedToRemove));
            });
        }

        [Test]
        public void ServiceFailedToAddRecipe()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;
            const string errorMessage = "This is an error message";

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.RemoveRecipe(sessionKey, recipeId)).Throws(new ArgumentException(errorMessage));
            var service = new RecipesController(recipesService.Object);

            var result = service.RemoveRecipe(sessionKey, recipeId);
            
            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.RemoveRecipe(sessionKey, recipeId), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(errorMessage));
            });
        }
    }
}
