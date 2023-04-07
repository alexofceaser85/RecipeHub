using System.Net;
using Moq;
using Moq.Protected;
using Shared_Resources.Model.Ingredients;
using Web_Client.Endpoints.Ingredients;

namespace WebClientTests.WebClient.Endpoints.Ingredients.IngredientsEndpointsTests
{
    public class GetAllIngredientsForUserTests
    {
        [Test]
        public void SuccessfullyDeleteIngredients()
        {
            const string json = "{\"pantry\": [{\"name\": \"apple\", \"amount\": 1, \"measurementType\": 0}, " +
                                "{\"name\": \"banana\", \"amount\": 1, \"measurementType\": 0}], \"code\": 200, " +
                                "\"message\": \"Ingredients successfully retrieved.\"}";

            var ingredients = new[] {
                new Ingredient("apple", 1, 0),
                new Ingredient("banana", 1, 0)
            };

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var endpoints = new IngredientEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var result = endpoints.GetAllIngredientsForUser();
                Assert.That(result, Is.EquivalentTo(ingredients));
                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }

        [Test]
        public void UnsuccessfullyDeleteIngredients()
        {
            const string errorMessage = "error message";
            const string json = $"{{\"code\": 500, \"message\": \"{errorMessage}\"}}";

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(json)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var endpoints = new IngredientEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(
                    () => endpoints.GetAllIngredientsForUser())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }
    }
}