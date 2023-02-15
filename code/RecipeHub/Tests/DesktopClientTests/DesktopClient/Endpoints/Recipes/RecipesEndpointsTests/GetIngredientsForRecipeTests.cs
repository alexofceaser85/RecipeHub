using Moq.Protected;
using Moq;
using System.Net;
using Desktop_Client.Endpoints.Recipes;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;

namespace DesktopClientTests.DesktopClient.Endpoints.Recipes.RecipesEndpointsTests
{
    public class GetIngredientsForRecipeTests
    {
        [Test]
        public void SuccessfullyRetrieveList()
        {
            var recipes = new Ingredient[] {
                new ("Potatoes", 5, (MeasurementType)2),
            };
            const string json = "{ \"ingredients\": [ { \"name\": \"Potatoes\", \"amount\": 5, \"measurementType\": 2 }], " +
                                "\"code\": 200, \"message\": \"Returned Okay\"}";

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
            var result = endpoints.GetIngredientsForRecipe("key", 2);

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
                var message = Assert.Throws<ArgumentException>(() => _ = endpoints.GetIngredientsForRecipe("key", 2))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }
    }
}
