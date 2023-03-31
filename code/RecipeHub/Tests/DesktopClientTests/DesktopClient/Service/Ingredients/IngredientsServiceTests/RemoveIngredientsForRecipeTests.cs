using Moq.Protected;
using Moq;
using System.Net;
using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Users;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.Service.Ingredients.IngredientsServiceTests
{
    internal class RemoveIngredientsForRecipeTests
    {
        [Test]
        public void SuccessfullyRemoveIngredientsForRecipe()
        {
            const int recipeId = 0;
            Session.Key = "key";
            var ingredients = Array.Empty<Ingredient>();

            var ingredientsEndpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            ingredientsEndpoints.Setup(mock => mock.RemoveIngredientsForRecipe(recipeId));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(ingredientsEndpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => service.RemoveIngredientsForRecipe(recipeId));
                ingredientsEndpoints.Verify(mock => mock.RemoveIngredientsForRecipe(recipeId), Times.Once);
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
            });
        }

        [Test]
        public void UnsuccessfullyRemoveIngredients()
        {
            const string errorMessage = "error message";
            const int recipeId = 0;
            Session.Key = "key";

            var ingredientsEndpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            ingredientsEndpoints.Setup(mock => mock.RemoveIngredientsForRecipe(recipeId))
                                .Throws(new ArgumentException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(ingredientsEndpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => service.RemoveIngredientsForRecipe(recipeId))!.Message;
                Assert.That(message, Is.EquivalentTo(errorMessage));
                ingredientsEndpoints.Verify(mock => mock.RemoveIngredientsForRecipe(recipeId), Times.Once);
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
            });
        }

        [Test]
        public void SessionKeyIsInvalid()
        {
            const string errorMessage = "error message";
            const int recipeId = 0;
            Session.Key = "key";

            var ingredientsEndpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            ingredientsEndpoints.Setup(mock => mock.RemoveIngredientsForRecipe(recipeId))
                                .Throws(new UnauthorizedAccessException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(ingredientsEndpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => service.RemoveIngredientsForRecipe(recipeId))!.Message;
                Assert.That(message, Is.EquivalentTo(errorMessage));
                ingredientsEndpoints.Verify(mock => mock.RemoveIngredientsForRecipe(recipeId), Times.Once);
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
            });
        }
    }
}
