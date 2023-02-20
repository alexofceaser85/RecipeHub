using Moq;
using Web_Client.Service.Ingredients;
using Web_Client.ViewModel.Ingredient;

namespace WebClientTests.WebClient.ViewModel.Ingredients.IngredientsViewModelTests
{
    public class RemoveAllIngredientsTests
    {
        [Test]
        public void SuccessfullyRemovesAllIngredients()
        {
            const bool expected = true;

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.DeleteAllIngredientsForUser()).Returns(expected);

            var viewModel = new IngredientsViewModel(service.Object);

            var result = viewModel.RemoveAllIngredients();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expected));
                service.Verify(mock => mock.DeleteAllIngredientsForUser(), Times.Once);
            });
        }
    }
}