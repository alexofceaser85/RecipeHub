using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.PlannedMeals;
using Web_Client.Endpoints.PlannedMeals;
using Web_Client.Service.PlannedMeals;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.PlannedMeals.PlannedMealsServiceTests
{
    public class RemovePlannedMealTests
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
            recipesEndpoint.Setup(mock => mock.RemovePlannedMeal(dateTime, mealCategory, recipeId));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new PlannedMealsService(recipesEndpoint.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => service.RemovePlannedMeal(dateTime, mealCategory, recipeId));
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
                recipesEndpoint.Verify(mock => mock.RemovePlannedMeal(dateTime, mealCategory, recipeId), Times.Once);
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
                    new PlannedMealsService().RemovePlannedMeal(dateTime, mealCategory, recipeId))!.Message;
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
                    new PlannedMealsService().RemovePlannedMeal(dateTime, mealCategory, recipeId))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}
