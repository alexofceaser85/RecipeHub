using Moq;
using Shared_Resources.Model.Ingredients;
using Web_Client.Endpoints.Ingredients;
using Web_Client.Service.Ingredients;

namespace WebClientTests.WebClient.Service.Ingredients.IngredientsServiceTests
{
    public class UpdateIngredientTests
    {
        [Test]
        public void SuccessfullyUpdateIngredient()
        {
            var ingredient = new Ingredient();
            var endpoints = new Mock<IIngredientEndpoints>();
            endpoints.Setup(mock => mock.AddIngredient(ingredient)).Returns(true);

            var service = new IngredientsService(endpoints.Object);

            Assert.Multiple(() =>
            {
                var result = service.AddIngredient(ingredient);
                Assert.That(result, Is.EqualTo(true));
                endpoints.Verify(mock => mock.AddIngredient(ingredient), Times.Once);
            });
        }
    }
}
