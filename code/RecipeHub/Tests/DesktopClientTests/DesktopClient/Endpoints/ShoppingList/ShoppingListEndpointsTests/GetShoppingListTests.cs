using Moq.Protected;
using Moq;
using System.Net;
using Desktop_Client.Endpoints.ShoppingList;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.Endpoints.ShoppingList.ShoppingListEndpointsTests
{
    public class GetShoppingListTests
    {
        [Test]
        public void ShouldSuccessfullyGetAllRecipeTypes()
        {
            const string json = "{\"ingredients\": [{\"name\": \"apple\", \"amount\": 1, \"measurementType\": 0}, " +
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
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var endpoints = new ShoppingListEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var result = endpoints.GetShoppingList();
                Assert.That(result, Is.EquivalentTo(ingredients));
                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }

        [Test]
        public void ShouldUnsuccessfullyGetAllRecipeTypesForServerError()
        {
            const string errorMessage = "The session timed out redirecting to login";
            const string json = $"{{\"code\": 500, \"message\": \"{errorMessage}\", \"types\": []}}";

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var endpoints = new ShoppingListEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => _ = endpoints.GetShoppingList())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }

        [Test]
        public void ShouldUnsuccessfullyGetAllRecipeTypesForAuthenticationError()
        {
            const string errorMessage = UsersServiceErrorMessages.UnauthorizedAccessErrorMessage;
            const string json = $"{{\"code\": 401, \"message\": \"{errorMessage}\", \"types\": []}}";

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var endpoints = new ShoppingListEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => _ = endpoints.GetShoppingList())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }
    }
}
