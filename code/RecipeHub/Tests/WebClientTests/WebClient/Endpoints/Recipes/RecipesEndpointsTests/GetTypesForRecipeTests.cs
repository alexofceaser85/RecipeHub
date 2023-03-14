using System.Net;
using Moq;
using Moq.Protected;
using Web_Client.Endpoints.Recipes;

namespace WebClientTests.WebClient.Endpoints.Recipes.RecipesEndpointsTests
{
    public class GetTypesForRecipeTests
    {
        [Test]
        public void SuccessfullyRetrieveList()
        {
            var types = new[] {
                "breakfast",
                "lunch"
            };
            const string json =
                "{ \"types\": [\"breakfast\", \"lunch\"], " +
                "\"code\": 200, \"message\": \"Returned Okay\"}";

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
            var endpoints = new RecipesEndpoints(httpClient);
            var result = endpoints.GetTypesForRecipe("key", 2);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EquivalentTo(types));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }

        [Test]
        public void UnsuccessfullyRetrieveList()
        {
            const string errorMessage = "error message";
            const string json = $"{{\"code\": 500, \"message\": \"{errorMessage}\", \"types\": []}}";

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
            var endpoints = new RecipesEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => 
                                        _ = endpoints.GetTypesForRecipe("key", 2))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }
    }
}