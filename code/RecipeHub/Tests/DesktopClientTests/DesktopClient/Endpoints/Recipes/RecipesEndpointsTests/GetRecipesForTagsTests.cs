using Moq.Protected;
using Moq;
using System.Net;
using Desktop_Client.Endpoints.Recipes;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Recipes;

namespace DesktopClientTests.DesktopClient.Endpoints.Recipes.RecipesEndpointsTests
{
    public class GetRecipesForTagsTests
    {
        [Test]
        public void ShouldSuccessfullyGetRecipesForTags()
        {
            var recipes = new Recipe[] {
                new(2, "first last", "Hamburger", "Lots of meat", true),
                new(4, "first2 last2", "new recipe", "this is a description", true),
                new(1003, "first2 last2", "Slices of Orange", "Clean - Quick - Healthy", true),
                new(1005, "first2 last2", "Goldman", "SuperFinger", true)
            };
            const string json =
                "{\"code\": 200, \"message\": \"Returned Okay\", \"recipes\": [ { \"id\": 2, \"authorName\": \"first last\", " +
                "\"name\": \"Hamburger\", \"description\": \"Lots of meat\", \"rating\": 0, \"isPublic\": true, \"ingredients\": [] }, " +
                "{ \"id\": 4, \"authorName\": \"first2 last2\", \"name\": \"new recipe\", \"description\": \"this is a description\", " +
                "\"rating\": 0, \"isPublic\": true, \"ingredients\": [] }, { \"id\": 1003, \"authorName\": \"first2 last2\", \"name\": " +
                "\"Slices of Orange\", \"description\": \"Clean - Quick - Healthy\", \"rating\": 0, \"isPublic\": true, \"ingredients\": [] }, {" +
                " \"id\": 1005, \"authorName\": \"first2 last2\", \"name\": \"Goldman\", \"description\": \"SuperFinger\", \"rating\": 0, " +
                "\"isPublic\": true, \"ingredients\": []}]}";

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
            var endpoints = new RecipesEndpoints(httpClient);
            var result = endpoints.GetRecipesForTags("key", new[]{"tag1"});

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EquivalentTo(recipes));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }

        [Test]
        public void ShouldUnsuccessfullyGetRecipesForTagsForServerError()
        {
            const string errorMessage = "error message";
            const string json = $"{{\"code\": 500, \"message\": \"{errorMessage}\", \"recipes\": []}}";

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
            var endpoints = new RecipesEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => _ = endpoints.GetRecipesForTags("key", new[]{"tag"}))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }

        [Test]
        public void ShouldUnsuccessfullyGetRecipesForTagsForAuthenticationError()
        {
            const string errorMessage = UsersServiceErrorMessages.UnauthorizedAccessErrorMessage;
            const string json = $"{{\"code\": 401, \"message\": \"{errorMessage}\", \"recipes\": []}}";

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
            var endpoints = new RecipesEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => _ = endpoints.GetRecipesForTags("key", new[] { "tag" }))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }
    }
}
