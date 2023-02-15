using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Ingredients;
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
            var endpoints = new Mock<IIngredientEndpoints>();
            endpoints.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var service = new IngredientsService(endpoints.Object);

            Assert.Multiple(() =>
            {
                var result = service.GetAllIngredientsForUser();
                Assert.That(result, Is.EquivalentTo(ingredients));
                endpoints.Verify(mock => mock.GetAllIngredientsForUser(), Times.Once);
            });
        }
    }
}
