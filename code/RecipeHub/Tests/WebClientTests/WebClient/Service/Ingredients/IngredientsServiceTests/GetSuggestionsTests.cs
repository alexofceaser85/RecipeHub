using Moq;
using Web_Client.Endpoints.Ingredients;
using Web_Client.Service.Ingredients;

namespace WebClientTests.WebClient.Service.Ingredients.IngredientsServiceTests
{
    public class GetSuggestionsTests
    {
        [Test]
        public void SuccessfullyGetIngredients()
        {
            var suggestions = new[] {
                "asd"
            };
            const string ingredientName = "name";
            var endpoints = new Mock<IIngredientEndpoints>();
            endpoints.Setup(mock => mock.GetSuggestions(ingredientName)).Returns(suggestions);

            var service = new IngredientsService(endpoints.Object);

            Assert.Multiple(() =>
            {
                var result = service.GetSuggestions(ingredientName);
                Assert.That(result, Is.EquivalentTo(suggestions));
                endpoints.Verify(mock => mock.GetSuggestions(ingredientName), Times.Once);
            });
        }
    }
}