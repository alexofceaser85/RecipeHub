using Web_Client.Endpoints.Recipes;
using Web_Client.Service.Recipes;
using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Recipes.RecipesServiceTests
{
    public class EditRecipeTests
    {
        [Test]
        public void SuccessfullyEditRecipe()
        {
            Session.Key = "Key";
            const int recipeId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.EditRecipe(Session.Key, recipeId, name, description, isPublic));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new RecipesService(recipesEndpoint.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => service.EditRecipe(recipeId, name, description, isPublic));
                recipesEndpoint.Verify(mock => mock.EditRecipe(Session.Key, recipeId, name, description, isPublic),
                    Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            Session.Key = null!;
            const int recipeId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull + " (Parameter 'Key')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() =>
                    new RecipesService().EditRecipe(recipeId, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptySessionKey()
        {
            Session.Key = "";
            const int recipeId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    new RecipesService().EditRecipe(recipeId, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void NullRecipeName()
        {
            Session.Key = "Key";
            const int recipeId = 1;
            const string name = null!;
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeNameCannotBeNull + " (Parameter 'name')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() =>
                    new RecipesService().EditRecipe(recipeId, name!, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptyRecipeName()
        {
            Session.Key = "Key";
            const int recipeId = 1;
            const string name = "";
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeNameCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    new RecipesService().EditRecipe(recipeId, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void NullRecipeDescription()
        {
            Session.Key = "Key";
            const int recipeId = 1;
            const string name = "name";
            const string description = null!;
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeDescriptionCannotBeNull +
                                        " (Parameter 'description')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() =>
                    new RecipesService().EditRecipe(recipeId, name, description!, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptyRecipeDescription()
        {
            Session.Key = "Key";
            const int recipeId = 1;
            const string name = "name";
            const string description = "";
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeDescriptionCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    new RecipesService().EditRecipe(recipeId, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}