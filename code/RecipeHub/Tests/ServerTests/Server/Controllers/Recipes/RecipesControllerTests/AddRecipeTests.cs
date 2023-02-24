using Moq;
using System.Net;
using Server.Controllers.Recipes;
using Server.Data.Settings;
using Server.ErrorMessages;
using Server.Service.Recipes;

namespace ServerTests.Server.Controllers.Recipes.RecipesControllerTests
{
    public class AddRecipeTests
    {
        [Test]
        public void RecipeSuccessfullyAdded()
        {
            const string sessionKey = "Key";
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.AddRecipe(sessionKey, name, description, isPublic)).Returns(true);
            var service = new RecipesController(recipesService.Object);

            var result = service.AddRecipe(sessionKey, name, description, isPublic);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo(ServerSettings.DefaultSuccessfulConnectionMessage));
                recipesService.Verify(mock => mock.AddRecipe(sessionKey, name, description, isPublic), Times.Once());
            });
        }

        [Test]
        public void DatabaseFailedToAddRecipe()
        {
            const string sessionKey = "Key";
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.AddRecipe(sessionKey, name, description, isPublic)).Returns(false);
            var service = new RecipesController(recipesService.Object);

            var result = service.AddRecipe(sessionKey, name, description, isPublic);

            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.AddRecipe(sessionKey, name, description, isPublic), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(RecipesControllerErrorMessages.RecipeFailedToAdd));
            });
        }

        [Test]
        public void ServiceFailedToAddRecipe()
        {
            const string sessionKey = "Key";
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;
            const string exceptionMessage = "An exception was thrown";

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.AddRecipe(sessionKey, name, description, isPublic)).Throws(new ArgumentException(exceptionMessage));
            var service = new RecipesController(recipesService.Object);

            var result = service.AddRecipe(sessionKey, name, description, isPublic);
            
            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.AddRecipe(sessionKey, name, description, isPublic), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(exceptionMessage));
            });
        }

        [Test]
        public void ServiceWasUnauthorized()
        {
            const string sessionKey = "Key";
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;
            const string exceptionMessage = "An exception was thrown";

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.AddRecipe(sessionKey, name, description, isPublic)).Throws(new UnauthorizedAccessException(exceptionMessage));
            var service = new RecipesController(recipesService.Object);

            var result = service.AddRecipe(sessionKey, name, description, isPublic);

            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.AddRecipe(sessionKey, name, description, isPublic), Times.Once());
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.Unauthorized));
                Assert.That(result.Message, Is.EqualTo(exceptionMessage));
            });
        }
    }
}
