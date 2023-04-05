using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.Service.Ingredients.IngredientsServiceTests
{
    public class DeleteIngredientTests
    {
        [Test]
        public void SuccessfullyDeleteIngredient()
        {
            var ingredient = new Ingredient();
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();

            endpoints.Setup(mock => mock.DeleteIngredient(ingredient)).Returns(true);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var result = service.DeleteIngredient(ingredient);
                Assert.That(result, Is.EqualTo(true));
                endpoints.Verify(mock => mock.DeleteIngredient(ingredient), Times.Once);
            });
        }

        [Test]
        public void FailedToDeleteIngredient()
        {
            const string errorMessage = "error message";
            var ingredient = new Ingredient();
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.DeleteIngredient(ingredient)).Throws(new ArgumentException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => service.DeleteIngredient(ingredient))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                endpoints.Verify(mock => mock.DeleteIngredient(ingredient), Times.Once);
            });
        }

        [Test]
        public void SessionKeyIsInvalid()
        {
            const string errorMessage = "error message";
            var ingredient = new Ingredient();
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.DeleteIngredient(ingredient)).Throws(new UnauthorizedAccessException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => service.DeleteIngredient(ingredient))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                endpoints.Verify(mock => mock.DeleteIngredient(ingredient), Times.Once);
            });
        }
    }
}
