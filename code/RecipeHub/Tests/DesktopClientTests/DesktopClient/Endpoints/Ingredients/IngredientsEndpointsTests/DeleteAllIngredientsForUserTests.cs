using Moq.Protected;
using Moq;
using System.Net;
using Desktop_Client.Endpoints.Ingredients;

namespace DesktopClientTests.DesktopClient.Endpoints.Ingredients.IngredientsEndpointsTests
{
    public class DeleteAllIngredientsForUserTests
    {
        [Test]
        public void SuccessfullyDeleteIngredients()
        {
            const string json = "{\"flag\": true, \"code\": 200, \"message\": \"Ingredients successfully deleted.\"}";

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
                var result = endpoints.DeleteAllIngredientsForUser();
                Assert.That(result, Is.EqualTo(true));
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
                    () => endpoints.DeleteAllIngredientsForUser())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }
    }
}