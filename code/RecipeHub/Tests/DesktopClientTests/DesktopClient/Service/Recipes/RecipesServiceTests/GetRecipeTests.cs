using Desktop_Client.Endpoints.Recipes;
using Desktop_Client.Service.Recipes;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Recipes;

namespace DesktopClientTests.DesktopClient.Service.Recipes.RecipesServiceTests
{
    public class GetRecipeTests
    {
        [Test]
        public void SuccessfullyGetRecipeSteps()
        {
            var recipe = new Recipe();
            const string sessionKey = "Key";
            Session.Key = sessionKey;
            const int recipeId = 0;

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.GetRecipe(sessionKey, recipeId)).Returns(recipe);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new RecipesService(recipesEndpoint.Object, usersService.Object);
            var result = service.GetRecipe(recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(recipe));
                recipesEndpoint.Verify(mock => mock.GetRecipe(sessionKey, recipeId), Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            Session.Key = null;
            var errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull + " (Parameter 'Key')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(
                    () => new RecipesService().GetRecipe(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptySessionKey()
        {
            Session.Key = "";
            var errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(
                    () => new RecipesService().GetRecipe(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}