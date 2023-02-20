using Moq.Protected;
using Moq;
using System.Net;
using Shared_Resources.Model.Recipes;
using Web_Client.Endpoints.Recipes;

namespace WebClientTests.WebClient.Endpoints.Recipes.RecipesEndpointsTests
{
    public class GetRecipeTests
    {
        [Test]
        public void SuccessfullyRetrieveRecipe()
        {
            var recipe = new Recipe(2, "first last", "Hamburger", "Lots of meat", true) {
                    Rating = 0
            };
            const string json = "{ \"code\": 200, \"message\": \"Returned Okay\", \"recipe\": " +
                                "{ \"id\": 2, \"authorName\": \"first last\", \"name\": \"Hamburger\", " +
                                "\"description\": \"Lots of meat\", \"rating\": 0, \"isPublic\": true }}"; 
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
            var result = endpoints.GetRecipe("key", 2);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(recipe));

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
                var message = Assert.Throws<ArgumentException>(() => _ = endpoints.GetRecipe("key", 2))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }
    }
}
