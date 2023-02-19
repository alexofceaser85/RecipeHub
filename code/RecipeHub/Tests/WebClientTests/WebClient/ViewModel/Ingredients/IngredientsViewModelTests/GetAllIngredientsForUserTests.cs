using Moq;
using Shared_Resources.Model.Ingredients;
using Web_Client.Service.Ingredients;
using Web_Client.ViewModel.Ingredient;

namespace WebClientTests.WebClient.ViewModel.Ingredients.IngredientsViewModelTests
{
    public class GetAllIngredientsForUserTests
    {
        [Test]
        public void SuccessfullyRetrievesIngredients()
        {
            var ingredients = new Ingredient[] {
                new ("apple", 1, MeasurementType.Quantity),
                new ("banana", 1, MeasurementType.Volume)
            };

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewModel = new IngredientsViewModel(service.Object);

            var result = viewModel.GetAllIngredientsForUser();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(ingredients));
                service.Verify(mock => mock.GetAllIngredientsForUser(), Times.Once);
            });
        }
    }
}