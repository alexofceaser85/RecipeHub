using Moq;
using Shared_Resources.Model.Ingredients;
using Web_Client.Endpoints.Ingredients;
using Web_Client.Service.Ingredients;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Ingredients.IngredientsServiceTests
{
    public class UpdateIngredientsTests
    {
        [Test]
        public void SuccessfullyAddEmptyIngredientArray()
        {
            var ingredients = Array.Empty<Ingredient>();
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.AddIngredients(ingredients));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => service.AddIngredients(ingredients));
                endpoints.Verify(mock => mock.AddIngredients(ingredients), Times.Once);
            });
        }

        [Test]
        public void SuccessfullyAddSingleIngredient()
        {
            var ingredients = new Ingredient[] {new()};
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.AddIngredients(ingredients));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => service.AddIngredients(ingredients));
                endpoints.Verify(mock => mock.AddIngredients(ingredients), Times.Once);
            });
        }
        
        [Test]
        public void SuccessfullyAddManyIngredients()
        {
            var ingredients = new Ingredient[] {
                new(),
                new(),
                new()
            };
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.AddIngredients(ingredients));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => service.AddIngredients(ingredients));
                endpoints.Verify(mock => mock.AddIngredients(ingredients), Times.Once);
            });
        }

        [Test]
        public void FailedToAddIngredients()
        {
            const string errorMessage = "error message";
            var ingredients = new Ingredient[] {
                new(),
                new(),
                new()
            };
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.AddIngredients(ingredients)).Throws(new ArgumentException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => service.AddIngredients(ingredients))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                endpoints.Verify(mock => mock.AddIngredients(ingredients), Times.Once);
            });
        }

        [Test]
        public void SessionKeyIsInvalid()
        {
            const string errorMessage = "error message";
            var ingredients = new Ingredient[] {
                new(),
                new(),
                new()
            };
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.AddIngredients(ingredients))
                     .Throws(new UnauthorizedAccessException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => 
                    service.AddIngredients(ingredients))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                endpoints.Verify(mock => mock.AddIngredients(ingredients), Times.Once);
            });
        }
    }
}
