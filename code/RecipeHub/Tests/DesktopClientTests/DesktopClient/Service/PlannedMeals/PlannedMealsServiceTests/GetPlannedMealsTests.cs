using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Endpoints.PlannedMeals;
using Desktop_Client.Service.PlannedMeals;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;

namespace DesktopClientTests.DesktopClient.Service.PlannedMeals.PlannedMealsServiceTests
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
