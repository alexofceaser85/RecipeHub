using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Endpoints.PlannedMeals;
using Desktop_Client.Service.PlannedMeals;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Data.UserData;
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

        [Test]
        public void UnsuccessfullyGetPlannedMeal()
        {
            const string sessionKey = "Key";
            const string errorMessage = "error message";
            Session.Key = sessionKey;

            var recipesEndpoint = new Mock<IPlannedMealsEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.GetPlannedMeals()).Throws(new ArgumentException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new PlannedMealsService(recipesEndpoint.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => service.GetPlannedMeals())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
                recipesEndpoint.Verify(mock => mock.GetPlannedMeals(), Times.Once);
            });
        }

        [Test]
        public void InvalidSessionKey()
        {
            const string sessionKey = "Key";
            const string errorMessage = "error message";
            Session.Key = sessionKey;

            var recipesEndpoint = new Mock<IPlannedMealsEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.GetPlannedMeals())
                           .Throws(new UnauthorizedAccessException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new PlannedMealsService(recipesEndpoint.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => service.GetPlannedMeals())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
                recipesEndpoint.Verify(mock => mock.GetPlannedMeals(), Times.Once);
            });
        }
    }
}
