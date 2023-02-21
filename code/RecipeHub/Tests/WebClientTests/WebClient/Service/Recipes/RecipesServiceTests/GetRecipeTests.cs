using Moq;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Recipes;
using Web_Client.Endpoints.Recipes;
using Web_Client.Service.Recipes;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Recipes.RecipesServiceTests
{
    public class GetRecipeTests
    {
        [Test]
        public void SuccessfullyGetRecipeSteps()
        {
            var recipe = new Recipe();
            const string sessionKey = "Key";
            const int recipeId = 0;

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            var usersService = new Mock<UsersService>();

            recipesEndpoint.Setup(mock => mock.GetRecipe(sessionKey, recipeId)).Returns(recipe);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new RecipesService(recipesEndpoint.Object, usersService.Object);
            var result = service.GetRecipe(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(recipe));
                recipesEndpoint.Verify(mock => mock.GetRecipe(sessionKey, recipeId), Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull + " (Parameter 'sessionKey')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(
                    () => new RecipesService().GetRecipe(null!, 0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptySessionKey()
        {
            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(
                    () => new RecipesService().GetRecipe("", 0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}