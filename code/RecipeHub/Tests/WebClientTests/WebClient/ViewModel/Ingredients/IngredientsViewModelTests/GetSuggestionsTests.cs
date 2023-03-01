using Moq;
using Web_Client.Service.Ingredients;
using Web_Client.ViewModel.Ingredient;

namespace WebClientTests.WebClient.ViewModel.Ingredients.IngredientsViewModelTests
{
    public class GetSuggestionsTests
    {
        [Test]
        public void SuccessfullyRetrievesSuggestions()
        {
            var suggestions = new [] {
                "apple",
                "banana"
            };
            const string ingredientName = "a";

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetSuggestions(ingredientName)).Returns(suggestions);

            var viewModel = new IngredientsViewModel(service.Object);

            var result = viewModel.GetSuggestions(ingredientName);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(suggestions));
                service.Verify(mock => mock.GetSuggestions(ingredientName), Times.Once);
            });
        }
    }
}