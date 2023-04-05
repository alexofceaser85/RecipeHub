using Desktop_Client.Endpoints.Recipes;
using Desktop_Client.Service.Recipes;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.Service.Recipes.RecipesServiceTests
{
    public class AddRecipeTests
    {
        [Test]
        public void SuccessfullyAddRecipe()
        {
            const string sessionKey = "Key";
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            Session.Key = sessionKey;

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.AddRecipe(name, description, isPublic));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new RecipesService(recipesEndpoint.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => service.AddRecipe(name, description, isPublic));
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
                recipesEndpoint.Verify(mock => mock.AddRecipe(name, description, isPublic), Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            Session.Key = null;
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull + " (Parameter 'Key')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => new RecipesService().AddRecipe(name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptySessionKey()
        {
            Session.Key = "";
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => new RecipesService().AddRecipe(name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void NullRecipeName()
        {
            Session.Key = "Key";
            const string name = null!;
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeNameCannotBeNull + " (Parameter 'name')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => new RecipesService().AddRecipe(name!, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptyRecipeName()
        {
            const string sessionKey = "Key";
            Session.Key = sessionKey;
            const string name = "";
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeNameCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => new RecipesService().AddRecipe(name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void NullRecipeDescription()
        {
            const string sessionKey = "Key";
            Session.Key = sessionKey;
            const string name = "name";
            const string description = null!;
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeDescriptionCannotBeNull +
                                        " (Parameter 'description')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => new RecipesService().AddRecipe(name, description!, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptyRecipeDescription()
        {
            const string sessionKey = "Key";
            Session.Key = sessionKey;
            const string name = "name";
            const string description = "";
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeDescriptionCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => new RecipesService().AddRecipe(name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}