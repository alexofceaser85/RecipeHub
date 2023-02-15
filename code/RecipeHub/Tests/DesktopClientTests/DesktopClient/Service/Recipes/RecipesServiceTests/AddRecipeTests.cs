using Desktop_Client.Endpoints.Recipes;
using Desktop_Client.Service.Recipes;
using Moq;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Recipes;

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

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            recipesEndpoint.Setup(mock => mock.AddRecipe(sessionKey, name, description, isPublic));

            var service = new RecipesService(recipesEndpoint.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => service.AddRecipe(sessionKey, name, description, isPublic));
                recipesEndpoint.Verify(mock => mock.AddRecipe(sessionKey, name, description, isPublic), Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            const string sessionKey = null!;
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull + " (Parameter 'sessionKey')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => new RecipesService().AddRecipe(sessionKey!, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptySessionKey()
        {
            const string sessionKey = "";
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => new RecipesService().AddRecipe(sessionKey, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void NullRecipeName()
        {
            const string sessionKey = "Key";
            const string name = null!;
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeNameCannotBeNull + " (Parameter 'name')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => new RecipesService().AddRecipe(sessionKey, name!, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptyRecipeName()
        {
            const string sessionKey = "Key";
            const string name = "";
            const string description = "description";
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeNameCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => new RecipesService().AddRecipe(sessionKey, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void NullRecipeDescription()
        {
            const string sessionKey = "Key";
            const string name = "name";
            const string description = null!;
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeDescriptionCannotBeNull + " (Parameter 'description')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => new RecipesService().AddRecipe(sessionKey, name, description!, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptyRecipeDescription()
        {
            const string sessionKey = "Key";
            const string name = "name";
            const string description = "";
            const bool isPublic = true;

            const string errorMessage = RecipesServiceErrorMessages.RecipeDescriptionCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => new RecipesService().AddRecipe(sessionKey, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}
