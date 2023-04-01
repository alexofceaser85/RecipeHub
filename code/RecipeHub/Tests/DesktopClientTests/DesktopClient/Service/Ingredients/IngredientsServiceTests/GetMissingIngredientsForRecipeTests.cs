using Moq;
using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Users;
using Shared_Resources.Data.UserData;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.Service.Ingredients.IngredientsServiceTests
{
    internal class GetMissingIngredientsForRecipeTests
    {
        [Test]
        public void GetEmptyArrayOfMissingIngredients()
        {
            const int recipeId = 0;
            Session.Key = "key";
            var ingredients = Array.Empty<Ingredient>();

            var ingredientsEndpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            ingredientsEndpoints.Setup(mock => mock.GetMissingIngredientsForRecipe(recipeId)).Returns(ingredients);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(ingredientsEndpoints.Object, usersService.Object);
            
            Assert.Multiple(() =>
            {
                var result = service.GetMissingIngredientsForRecipe(recipeId);
                Assert.That(result, Is.EquivalentTo(ingredients));
                ingredientsEndpoints.Verify(mock => mock.GetMissingIngredientsForRecipe(recipeId), Times.Once);
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
            });
        }

        [Test]
        public void GetSingleMissingIngredient()
        {
            const int recipeId = 0;
            Session.Key = "key";
            var ingredients = new Ingredient[] {new()};

            var ingredientsEndpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            ingredientsEndpoints.Setup(mock => mock.GetMissingIngredientsForRecipe(recipeId)).Returns(ingredients);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(ingredientsEndpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var result = service.GetMissingIngredientsForRecipe(recipeId);
                Assert.That(result, Is.EquivalentTo(ingredients));
                ingredientsEndpoints.Verify(mock => mock.GetMissingIngredientsForRecipe(recipeId), Times.Once);
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
            });
        }

        [Test]
        public void GetManyMissingIngredients()
        {
            const int recipeId = 0;
            Session.Key = "key";
            var ingredients = new Ingredient[] { new(), new(), new() };

            var ingredientsEndpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            ingredientsEndpoints.Setup(mock => mock.GetMissingIngredientsForRecipe(recipeId)).Returns(ingredients);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(ingredientsEndpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var result = service.GetMissingIngredientsForRecipe(recipeId);
                Assert.That(result, Is.EquivalentTo(ingredients));
                ingredientsEndpoints.Verify(mock => mock.GetMissingIngredientsForRecipe(recipeId), Times.Once);
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
            });
        }

        [Test]
        public void UnsuccessfullyGetMissingIngredients()
        {
            const string errorMessage = "error message";
            const int recipeId = 0;
            Session.Key = "key";

            var ingredientsEndpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            ingredientsEndpoints.Setup(mock => mock.GetMissingIngredientsForRecipe(recipeId))
                                .Throws(new ArgumentException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(ingredientsEndpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => service.GetMissingIngredientsForRecipe(recipeId))!.Message;
                Assert.That(message, Is.EquivalentTo(errorMessage));
                ingredientsEndpoints.Verify(mock => mock.GetMissingIngredientsForRecipe(recipeId), Times.Once);
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
            ingredientsEndpoints.Setup(mock => mock.GetMissingIngredientsForRecipe(recipeId))
                                .Throws(new UnauthorizedAccessException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(ingredientsEndpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => service.GetMissingIngredientsForRecipe(recipeId))!.Message;
                Assert.That(message, Is.EquivalentTo(errorMessage));
                ingredientsEndpoints.Verify(mock => mock.GetMissingIngredientsForRecipe(recipeId), Times.Once);
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
            });
        }
    }
}
