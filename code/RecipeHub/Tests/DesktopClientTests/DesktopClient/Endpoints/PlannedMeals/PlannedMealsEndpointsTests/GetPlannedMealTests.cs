using Moq.Protected;
using Moq;
using System.Net;
using Desktop_Client.Endpoints.PlannedMeals;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;

namespace DesktopClientTests.DesktopClient.Endpoints.PlannedMeals.PlannedMealsEndpointsTests
{
    public class GetPlannedMealTests
    {
        [Test]
        public void SuccessfullyGetPlannedMeals()
        {
            const string json = "{\"code\": 200, \"message\": \"Returned Okay\", \"plannedMeals\": " +
                                "[{ \"mealDate\": \"2023-03-05T00:00:00.0Z\", \"meals\": [ { \"category\": 0, \"recipes\": [] }, " +
                                "{ \"category\": 1, \"recipes\": [] }, { \"category\": 2, \"recipes\": [] } ] }]}";
            var plannedMeals = new[] {
                new PlannedMeal(new DateTime(2023, 3, 5), new[] {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty<PlannedRecipe>()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty<PlannedRecipe>()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty<PlannedRecipe>()),
                })
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
            var endpoints = new PlannedMealsEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var result = endpoints.GetPlannedMeals();
                
                Assert.That(result, Has.Length.EqualTo(1));
                Assert.That(result[0].MealDate, Is.EqualTo(plannedMeals[0].MealDate));
                Assert.That(result[0].Meals[0].Category, Is.EqualTo(plannedMeals[0].Meals[0].Category));
                Assert.That(result[0].Meals[1].Category, Is.EqualTo(plannedMeals[0].Meals[1].Category));
                Assert.That(result[0].Meals[2].Category, Is.EqualTo(plannedMeals[0].Meals[2].Category));
                Assert.That(result[0].Meals[0].Recipes.Length, Is.EqualTo(plannedMeals[0].Meals[0].Recipes.Length));
                Assert.That(result[0].Meals[1].Recipes.Length, Is.EqualTo(plannedMeals[0].Meals[1].Recipes.Length));
                Assert.That(result[0].Meals[2].Recipes.Length, Is.EqualTo(plannedMeals[0].Meals[2].Recipes.Length));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }

        [Test]
        public void UnsuccessfullyGetPlannedMeals()
        {
            const string errorMessage = "error message";
            const string json = $"{{\"code\": 500, \"message\": \"{errorMessage}\", \"plannedMeals\": []}}";

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
                    () => endpoints.GetPlannedMeals())!.Message;
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
            var endpoints = new PlannedMealsEndpoints(httpClient);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(
                    () => endpoints.GetPlannedMeals())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));

                mockHttpMessageHandler
                    .Protected()
                    .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                        ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            });
        }
    }
}
