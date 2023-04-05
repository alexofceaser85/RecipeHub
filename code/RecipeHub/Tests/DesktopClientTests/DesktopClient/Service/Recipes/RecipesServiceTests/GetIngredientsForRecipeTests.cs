using Desktop_Client.Endpoints.Recipes;
using Desktop_Client.Service.Recipes;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.Service.Recipes.RecipesServiceTests
{
    public class GetIngredientsForRecipeTests
    {
        [Test]
        public void SuccessfullyGetRecipeIngredients()
        {
            var ingredients = new Ingredient[] {
                new("name", 0, MeasurementType.Volume)
            };
            const string sessionKey = "Key";
            Session.Key = sessionKey;
            const int recipeId = 0;

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.GetIngredientsForRecipe(recipeId)).Returns(ingredients);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new RecipesService(recipesEndpoint.Object, usersService.Object);
            var result = service.GetIngredientsForRecipe(recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EquivalentTo(ingredients));
                recipesEndpoint.Verify(mock => mock.GetIngredientsForRecipe(recipeId), Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            var errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull + " (Parameter 'Key')";
            Session.Key = null;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(
                    () => new RecipesService().GetIngredientsForRecipe(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptySessionKey()
        {
            var errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Session.Key = "";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(
                    () => new RecipesService().GetIngredientsForRecipe(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
        
        [Test]
        public void UnsuccessfullyGetRecipeIngredients()
        {
            const string errorMessage = "error message";
            const string sessionKey = "Key";
            Session.Key = sessionKey;
            const int recipeId = 0;

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.GetIngredientsForRecipe(recipeId))
                           .Throws(new ArgumentException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new RecipesService(recipesEndpoint.Object, usersService.Object) ;

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => service.GetIngredientsForRecipe(recipeId))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                recipesEndpoint.Verify(mock => mock.GetIngredientsForRecipe(recipeId), Times.Once);
            });
        }

        [Test]
        public void InvalidSessionKey()
        {
            const string errorMessage = "error message";
            const string sessionKey = "Key";
            Session.Key = sessionKey;
            const int recipeId = 0;

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.GetIngredientsForRecipe(recipeId))
                           .Throws(new UnauthorizedAccessException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new RecipesService(recipesEndpoint.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => service.GetIngredientsForRecipe(recipeId))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                recipesEndpoint.Verify(mock => mock.GetIngredientsForRecipe(recipeId), Times.Once);
            });
        }
    }
}