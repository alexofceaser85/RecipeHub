using Moq;
using Web_Client.Endpoints.Ingredients;
using Web_Client.Service.Ingredients;

namespace WebClientTests.WebClient.Service.Ingredients.IngredientsServiceTests
{
    public class DeleteAllIngredientsForUserTests
    {
        [Test]
        public void SuccessfullyDeleteIngredients()
        {
            var endpoints = new Mock<IIngredientEndpoints>();
            endpoints.Setup(mock => mock.DeleteAllIngredientsForUser()).Returns(true);

            var service = new IngredientsService(endpoints.Object);

            Assert.Multiple(() =>
            {
                var result = service.DeleteAllIngredientsForUser();
                Assert.That(result, Is.EqualTo(true));
                endpoints.Verify(mock => mock.DeleteAllIngredientsForUser(), Times.Once);
            });
        }
    }
}