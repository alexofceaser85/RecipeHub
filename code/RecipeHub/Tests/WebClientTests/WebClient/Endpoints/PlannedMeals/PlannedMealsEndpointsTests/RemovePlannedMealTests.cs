using System.Net;
using Moq;
using Moq.Protected;
using Shared_Resources.Model.PlannedMeals;
using Web_Client.Endpoints.PlannedMeals;

namespace WebClientTests.WebClient.Endpoints.PlannedMeals.PlannedMealsEndpointsTests
{
    public class RemovePlannedMealTests
    {
        [Test]
        public void SuccessfullyRemovePlannedMeal()
        {
            const string json = "{\"code\": 200, \"message\": \"Returned Okay\"}";

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
            var endpoints = new PlannedMealsEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => endpoints.RemovePlannedMeal(0));
                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }

        [Test]
        public void UnsuccessfullyRemoveNewRecipe()
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
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(json)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var endpoints = new PlannedMealsEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(
                    () => endpoints.RemovePlannedMeal(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }
    }
}
