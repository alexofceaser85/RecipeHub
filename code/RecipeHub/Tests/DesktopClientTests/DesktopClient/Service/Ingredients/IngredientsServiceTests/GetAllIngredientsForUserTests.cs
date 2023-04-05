using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.Service.Ingredients.IngredientsServiceTests
{
    public class GetAllIngredientsForUserTests
    {
        [Test]
        public void SuccessfullyGetIngredients()
        {
            var ingredients = new Ingredient[] {
                new()
            };

            var usersService = new Mock<IUsersService>();
            var endpoints = new Mock<IIngredientEndpoints>();
            endpoints.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var result = service.GetAllIngredientsForUser();
                Assert.That(result, Is.EquivalentTo(ingredients));
                endpoints.Verify(mock => mock.GetAllIngredientsForUser(), Times.Once);
            });
        }


        [Test]
        public void FailedToGetIngredients()
        {
            const string errorMessage = "error message";
            var ingredient = new Ingredient();
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.GetAllIngredientsForUser()).Throws(new ArgumentException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => service.GetAllIngredientsForUser())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                endpoints.Verify(mock => mock.GetAllIngredientsForUser(), Times.Once);
            });
        }

        [Test]
        public void SessionKeyIsInvalid()
        {
            const string errorMessage = "error message";
            var ingredient = new Ingredient();
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.GetAllIngredientsForUser()).Throws(new UnauthorizedAccessException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => service.GetAllIngredientsForUser())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                endpoints.Verify(mock => mock.GetAllIngredientsForUser(), Times.Once);
            });
        }
    }
}
