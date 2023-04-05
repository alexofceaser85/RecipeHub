using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.Service.Ingredients.IngredientsServiceTests
{
    public class UpdateIngredientTests
    {
        [Test]
        public void SuccessfullyUpdateIngredient()
        {
            var ingredient = new Ingredient();
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.UpdateIngredient(ingredient)).Returns(true);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var result = service.UpdateIngredient(ingredient);
                Assert.That(result, Is.EqualTo(true));
                endpoints.Verify(mock => mock.UpdateIngredient(ingredient), Times.Once);
            });
        }

        [Test]
        public void UnsuccessfullyUpdateIngredient()
        {
            const string errorMessage = "error message";
            var ingredient = new Ingredient();
            Session.Key = "key";

            var ingredientsEndpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            ingredientsEndpoints.Setup(mock => mock.UpdateIngredient(ingredient))
                                .Throws(new ArgumentException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(ingredientsEndpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => service.UpdateIngredient(ingredient))!.Message;
                Assert.That(message, Is.EquivalentTo(errorMessage));
                ingredientsEndpoints.Verify(mock => mock.UpdateIngredient(ingredient), Times.Once);
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
            });
        }

        [Test]
        public void SessionKeyIsInvalid()
        {
            const string errorMessage = "error message";
            var ingredient = new Ingredient();
            Session.Key = "key";

            var ingredientsEndpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            ingredientsEndpoints.Setup(mock => mock.UpdateIngredient(ingredient))
                                .Throws(new UnauthorizedAccessException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(ingredientsEndpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => service.UpdateIngredient(ingredient))!.Message;
                Assert.That(message, Is.EquivalentTo(errorMessage));
                ingredientsEndpoints.Verify(mock => mock.UpdateIngredient(ingredient), Times.Once);
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
            });
        }
    }
}
