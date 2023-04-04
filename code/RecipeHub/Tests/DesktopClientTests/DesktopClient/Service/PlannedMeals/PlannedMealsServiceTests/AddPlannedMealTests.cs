using Desktop_Client.Endpoints.PlannedMeals;
using Desktop_Client.Service.PlannedMeals;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.PlannedMeals;

namespace DesktopClientTests.DesktopClient.Service.PlannedMeals.PlannedMealsServiceTests
{
    public class AddPlannedMealTests
    {
        [Test]
        public void SuccessfullyAddPlannedMeal()
        {
            const string sessionKey = "Key";
            var dateTime = new DateTime(2000, 1, 1);
            const MealCategory mealCategory = MealCategory.Dinner;
            const int recipeId = 1;

            Session.Key = sessionKey;

            var recipesEndpoint = new Mock<IPlannedMealsEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.AddPlannedMeal(dateTime, mealCategory, recipeId));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new PlannedMealsService(recipesEndpoint.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => service.AddPlannedMeal(dateTime, mealCategory, recipeId));
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
                recipesEndpoint.Verify(mock => mock.AddPlannedMeal(dateTime, mealCategory, recipeId), Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            Session.Key = null;
            var dateTime = new DateTime(2000, 1, 1);
            const MealCategory mealCategory = MealCategory.Dinner;
            const int recipeId = 1;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<InvalidOperationException>(() => 
                    new PlannedMealsService().AddPlannedMeal(dateTime, mealCategory, recipeId))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptySessionKey()
        {
            Session.Key = "";
            var dateTime = new DateTime(2000, 1, 1);
            const MealCategory mealCategory = MealCategory.Dinner;
            const int recipeId = 1;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<InvalidOperationException>(() => 
                    new PlannedMealsService().AddPlannedMeal(dateTime, mealCategory, recipeId))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void UnsuccessfullyAddPlannedMeal()
        {
            const string sessionKey = "Key";
            const string errorMessage = "error message";
            var dateTime = new DateTime(2000, 1, 1);
            const MealCategory mealCategory = MealCategory.Dinner;
            const int recipeId = 1;

            Session.Key = sessionKey;
            var recipesEndpoint = new Mock<IPlannedMealsEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.AddPlannedMeal(dateTime, mealCategory, recipeId)).Throws(new ArgumentException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new PlannedMealsService(recipesEndpoint.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => service.AddPlannedMeal(dateTime, mealCategory, recipeId))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
                recipesEndpoint.Verify(mock => mock.AddPlannedMeal(dateTime, mealCategory, recipeId), Times.Once);
            });
        }

        [Test]
        public void InvalidSessionKey()
        {
            const string sessionKey = "Key";
            const string errorMessage = "error message";
            var dateTime = new DateTime(2000, 1, 1);
            const MealCategory mealCategory = MealCategory.Dinner;
            const int recipeId = 1;

            Session.Key = sessionKey;
            var recipesEndpoint = new Mock<IPlannedMealsEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.AddPlannedMeal(dateTime, mealCategory, recipeId))
                           .Throws(new UnauthorizedAccessException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new PlannedMealsService(recipesEndpoint.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => service.AddPlannedMeal(dateTime, mealCategory, recipeId))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
                recipesEndpoint.Verify(mock => mock.AddPlannedMeal(dateTime, mealCategory, recipeId), Times.Once);
            });
        }
    }
}
