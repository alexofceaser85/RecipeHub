using Moq;
using Shared_Resources.Data.UserData;
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
            Session.Key = "Key";
            var recipe = new Recipe();
            const int recipeId = 0;

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            var usersService = new Mock<IUsersService>();

            recipesEndpoint.Setup(mock => mock.GetRecipe(Session.Key, recipeId)).Returns(recipe);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new RecipesService(recipesEndpoint.Object, usersService.Object);
            var result = service.GetRecipe(recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(recipe));
                recipesEndpoint.Verify(mock => mock.GetRecipe(Session.Key, recipeId), Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            Session.Key = null!;
            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull + " (Parameter 'Key')";
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
            Session.Key = "   ";
            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(
                    () => new RecipesService().GetRecipe(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}