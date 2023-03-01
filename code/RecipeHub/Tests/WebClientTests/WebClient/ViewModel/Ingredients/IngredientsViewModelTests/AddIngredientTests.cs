using Moq;
using Shared_Resources.Model.Ingredients;
using Web_Client.Service.Ingredients;
using Web_Client.ViewModel.Ingredient;

namespace WebClientTests.WebClient.ViewModel.Ingredients.IngredientsViewModelTests
{
    public class AddIngredientTests
    {
        [Test]
        public void SuccessfullyAddIngredient()
        {
            var ingredient = new Ingredient("apple", 1, MeasurementType.Quantity);
            const bool expected = true;

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.AddIngredient(ingredient)).Returns(expected);

            var viewModel = new IngredientsViewModel(service.Object);

            var result = viewModel.AddIngredient(ingredient);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expected));
                service.Verify(mock => mock.AddIngredient(ingredient), Times.Once);
            });
        }
    }
}