using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Ingredients;
using Moq;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.Service.Ingredients.IngredientsServiceTests
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
