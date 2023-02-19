using Desktop_Client.Endpoints.Recipes;
using Desktop_Client.Service.Recipes;
using Moq;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.Service.Recipes.RecipesServiceTests
{
    public class RemoveRecipeTests
    {
        [Test]
        public void SuccessfullyRemoveRecipe()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            recipesEndpoint.Setup(mock => mock.RemoveRecipe(sessionKey, recipeId));

            var service = new RecipesService(recipesEndpoint.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => service.RemoveRecipe(sessionKey, recipeId));
                recipesEndpoint.Verify(mock => mock.RemoveRecipe(sessionKey, recipeId), Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            const string sessionKey = null!;
            const int recipeId = 1;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull + " (Parameter 'sessionKey')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() =>
                    new RecipesService().RemoveRecipe(sessionKey!, recipeId))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptySessionKey()
        {
            const string sessionKey = "";
            const int recipeId = 1;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    new RecipesService().RemoveRecipe(sessionKey, recipeId))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}