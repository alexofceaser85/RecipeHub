﻿using Moq.Protected;
using Moq;
using System.Net;
using Shared_Resources.ErrorMessages;
using Web_Client.Endpoints.RecipeTypes;

namespace WebClientTests.WebClient.Endpoints.RecipeTypes.RecipeTypesEndpointsTests
{
    public class GetAllRecipeTypesTests
    {
        [Test]
        public void ShouldSuccessfullyGetAllRecipeTypes()
        {
            var types = new[] { "type1", "type2", "type3" };
            const string json = "{\"types\":[\"type1\",\"type2\",\"type3\"],\"code\":200,\"message\":\"Returned Okay\"}";

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
            var endpoints = new RecipeTypesEndpoints(httpClient);
            var result = endpoints.GetAllRecipeTypes();

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
        public void ShouldUnsuccessfullyGetAllRecipeTypesForServerError()
        {
            const string errorMessage = "Session either timed out or was invalid. Redirecting to login.";
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
            var endpoints = new RecipeTypesEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => _ = endpoints.GetAllRecipeTypes())!.Message;
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
            var endpoints = new RecipeTypesEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => _ = endpoints.GetAllRecipeTypes())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }
    }
}
