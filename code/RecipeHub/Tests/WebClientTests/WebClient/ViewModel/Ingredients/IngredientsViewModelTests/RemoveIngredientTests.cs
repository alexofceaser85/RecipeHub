using Moq;
using Shared_Resources.Model.Ingredients;
using Web_Client.Service.Ingredients;
using Web_Client.ViewModel.Ingredient;

namespace WebClientTests.WebClient.ViewModel.Ingredients.IngredientsViewModelTests
{
    public class RemoveIngredientTests
    {
        [Test]
        public void SuccessfullyRemovesIngredient()
        {
            var ingredient = new Ingredient("apple", 1, MeasurementType.Quantity);
            const bool expected = true;

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.DeleteIngredient(ingredient)).Returns(expected);

            var viewModel = new IngredientsViewModel(service.Object);

            var result = viewModel.RemoveIngredient(ingredient);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expected));
                service.Verify(mock => mock.DeleteIngredient(ingredient), Times.Once);
            });
        }
    }
}