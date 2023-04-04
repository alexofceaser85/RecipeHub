using Moq;
using Shared_Resources.Model.Ingredients;
using Web_Client.Endpoints.Ingredients;
using Web_Client.Service.Ingredients;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Ingredients.IngredientsServiceTests
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
    }
}
