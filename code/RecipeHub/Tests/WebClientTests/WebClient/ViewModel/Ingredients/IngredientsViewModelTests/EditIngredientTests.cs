using Moq;
using Shared_Resources.Model.Ingredients;
using Web_Client.Service.Ingredients;
using Web_Client.ViewModel.Ingredient;

namespace WebClientTests.WebClient.ViewModel.Ingredients.IngredientsViewModelTests
{
    public class EditIngredientTests
    {
        [Test]
        public void SuccessfullyEditIngredient()
        {
            var ingredient = new Ingredient("apple", 1, MeasurementType.Quantity);
            const bool expected = true;

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.UpdateIngredient(ingredient)).Returns(expected);

            var viewModel = new IngredientsViewModel(service.Object);

            var result = viewModel.EditIngredient(ingredient);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expected));
                service.Verify(mock => mock.UpdateIngredient(ingredient), Times.Once);
            });
        }
    }
}