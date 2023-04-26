using Moq;
using Server.DAL.PlannedMeals;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.ErrorMessages;
using Server.Service.PlannedMeals;
using Shared_Resources.Model.PlannedMeals;

namespace ServerTests.Server.Service.PlannedMeals.PlannedMealsServiceTests
{
    public class AddPlannedMealTests
    {
        [Test]
        public void ShouldNotAddPlannedMealWithNullSessionKey()
        {
            var sessionKey = "key";
            var userId = 1;
            var mealDate = new DateTime(2023, 03, 03);
            var category = MealCategory.Lunch;
            var recipeId = 1;

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            plannedMealsDal.Setup(mock => mock.AddPlannedMeal(userId, mealDate, category, recipeId));

            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.AddPlannedMeal(null!, mealDate, category, recipeId);
            })?.Message;

            Assert.That(message, Is.EqualTo(PlannedMealsServiceErrorMessages.SessionKeyCannotBeNull));
        }

        [Test]
        public void ShouldNotAddPlannedMealWithEmptySessionKey()
        {
            var sessionKey = "key";
            var userId = 1;
            var mealDate = new DateTime(2023, 03, 03);
            var category = MealCategory.Lunch;
            var recipeId = 1;

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            plannedMealsDal.Setup(mock => mock.AddPlannedMeal(userId, mealDate, category, recipeId));

            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.AddPlannedMeal("    ", mealDate, category, recipeId);
            })?.Message;

            Assert.That(message, Is.EqualTo(PlannedMealsServiceErrorMessages.SessionKeyCannotBeEmpty));
        }

        [Test]
        public void ShouldNotAddPlannedMealWithInvalidSession()
        {
            var sessionKey = "key";
            var userId = 1;
            var mealDate = new DateTime(2023, 03, 03);
            var category = MealCategory.Lunch;
            var recipeId = 1;

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns((int?)null!);
            plannedMealsDal.Setup(mock => mock.AddPlannedMeal(userId, mealDate, category, recipeId));

            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.AddPlannedMeal(sessionKey, mealDate, category, recipeId);
            })?.Message;

            Assert.That(message, Is.EqualTo(PlannedMealsServiceErrorMessages.InvalidSession));
        }
        
        [Test]
        public void ShouldAddPlannedMeal()
        {
            var sessionKey = "key";
            var userId = 1;
            var mealDate = new DateTime(2023, 03, 03);
            var category = MealCategory.Lunch;
            var recipeId = 1;

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(1);
            plannedMealsDal.Setup(mock => mock.AddPlannedMeal(userId, mealDate, category, recipeId)).Returns(true);
            plannedMealsDal.Setup(mock => mock.IsPlannedMealInSystem(userId, mealDate, category, recipeId))
                .Returns(false);

            var isMealAdded = service.AddPlannedMeal(sessionKey, mealDate, category, recipeId);

            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once);
            plannedMealsDal.Verify(mock => mock.AddPlannedMeal(userId, mealDate, category, recipeId), Times.Once);
            Assert.That(isMealAdded, Is.EqualTo(true));
        }
    }
}
