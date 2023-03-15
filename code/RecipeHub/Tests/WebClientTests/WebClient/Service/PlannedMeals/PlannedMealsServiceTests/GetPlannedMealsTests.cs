using Moq;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;
using Web_Client.Endpoints.PlannedMeals;
using Web_Client.Service.PlannedMeals;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.PlannedMeals.PlannedMealsServiceTests
{
    internal class GetPlannedMealsTests
    {
        [Test]
        public void SuccessfullyGetPlannedMeals()
        {
            var plannedMeals = new [] {
                new PlannedMeal(new DateTime(2000, 1, 1), new [] {
                    new MealsForCategory(MealCategory.Breakfast, new [] {
                        new Recipe(0, "author", "name", "description", true)
                    }),
                    new MealsForCategory(MealCategory.Lunch, new [] {
                        new Recipe(1, "author", "name", "description", true)
                    }),
                    new MealsForCategory(MealCategory.Dinner, new [] {
                        new Recipe(2, "author", "name", "description", true)
                    })
                })
            };

            var usersService = new Mock<IUsersService>();
            var endpoints = new Mock<IPlannedMealsEndpoints>();

            usersService.Setup(mock => mock.RefreshSessionKey());
            endpoints.Setup(mock => mock.GetPlannedMeals()).Returns(plannedMeals);

            var service = new PlannedMealsService(endpoints.Object, usersService.Object);
            var result = service.GetPlannedMeals();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(plannedMeals));
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
                endpoints.Verify(mock => mock.GetPlannedMeals(), Times.Once);
            });
        }
    }
}
