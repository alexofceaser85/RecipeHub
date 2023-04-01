using Moq;
using Shared_Resources.Model.Ingredients;
using Web_Client.Endpoints.Ingredients;
using Web_Client.Service.Ingredients;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Ingredients.IngredientsServiceTests
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
    }
}
