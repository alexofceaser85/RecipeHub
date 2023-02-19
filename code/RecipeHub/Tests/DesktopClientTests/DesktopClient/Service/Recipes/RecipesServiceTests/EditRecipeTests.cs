using Desktop_Client.Endpoints.Recipes;
using Desktop_Client.Service.Recipes;
using Moq;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.Service.Recipes.RecipesServiceTests
{
    public class EditRecipeTests
    {
        [Test]
        public void SuccessfullyEditRecipe()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            recipesEndpoint.Setup(mock => mock.EditRecipe(sessionKey, recipeId, name, description, isPublic));

            var service = new RecipesService(recipesEndpoint.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => service.EditRecipe(sessionKey, recipeId, name, description, isPublic));
                recipesEndpoint.Verify(mock => mock.EditRecipe(sessionKey, recipeId, name, description, isPublic),
                    Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            const string sessionKey = null!;
            const int recipeId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull + " (Parameter 'sessionKey')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() =>
                    new RecipesService().EditRecipe(sessionKey!, recipeId, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptySessionKey()
        {
            const string sessionKey = "";
            const int recipeId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    new RecipesService().EditRecipe(sessionKey, recipeId, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void NullRecipeName()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;
            const string name = null!;
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeNameCannotBeNull + " (Parameter 'name')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() =>
                    new RecipesService().EditRecipe(sessionKey, recipeId, name!, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptyRecipeName()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;
            const string name = "";
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeNameCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    new RecipesService().EditRecipe(sessionKey, recipeId, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void NullRecipeDescription()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;
            const string name = "name";
            const string description = null!;
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeDescriptionCannotBeNull +
                                        " (Parameter 'description')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() =>
                    new RecipesService().EditRecipe(sessionKey, recipeId, name, description!, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptyRecipeDescription()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;
            const string name = "name";
            const string description = "";
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeDescriptionCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    new RecipesService().EditRecipe(sessionKey, recipeId, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}