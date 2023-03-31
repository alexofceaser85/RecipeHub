using Moq.Protected;
using Moq;
using System.Net;
using Desktop_Client.Endpoints.Ingredients;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.Endpoints.Ingredients.IngredientsEndpointsTests
{
    public class AddIngredientsTests
    {
        [Test]
        public void SuccessfullyAddEmptyIngredientArray()
        {
            const string json = "{\"flag\": true, \"code\": 200, \"message\": \"Ingredients successfully added.\"}";

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
                Assert.DoesNotThrow(() => endpoints.AddIngredients(Array.Empty<Ingredient>()));
                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }

        [Test]
        public void SuccessfullyAddSingleIngredient()
        {
            const string json = "{\"flag\": true, \"code\": 200, \"message\": \"Ingredients successfully added.\"}";

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
            var endpoints = new IngredientEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => endpoints.AddIngredients(Array.Empty<Ingredient>()));
                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }

        [Test]
        public void SuccessfullyAddManyIngredients()
        {
            const string json = "{\"flag\": true, \"code\": 200, \"message\": \"Ingredients successfully added.\"}";

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
            var endpoints = new IngredientEndpoints(httpClient);
            var ingredients = new Ingredient[] {
                new(),
                new(),
                new()
            };

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => endpoints.AddIngredients(Array.Empty<Ingredient>()));
                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }

        [Test]
        public void UnsuccessfullyAddNewIngredient()
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
                    () => endpoints.AddIngredients(Array.Empty<Ingredient>()))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }

        [Test]
        public void SessionKeyIsInvalid()
        {
            const string errorMessage = UsersServiceErrorMessages.UnauthorizedAccessErrorMessage;
            const string json = $"{{\"code\": 401, \"message\": \"{errorMessage}\"}}";

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(json)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var endpoints = new IngredientEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(
                    () => endpoints.AddIngredients(Array.Empty<Ingredient>()))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }
    }
}