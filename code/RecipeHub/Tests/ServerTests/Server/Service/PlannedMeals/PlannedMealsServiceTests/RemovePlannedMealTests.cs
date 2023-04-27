using Moq;
using Server.DAL.PlannedMeals;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.ErrorMessages;
using Server.Service.PlannedMeals;
using Shared_Resources.Model.PlannedMeals;

namespace ServerTests.Server.Service.PlannedMeals.PlannedMealsServiceTests
{
    public class RemovePlannedMealTests
    {
        [Test]
        public void ShouldNotRemovePlannedMealWithNullSessionKey()
        {
            var sessionKey = "key";
            var userId = 1;

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            plannedMealsDal.Setup(mock => mock.RemovePlannedMeal(userId, 0));

            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.RemovePlannedMeal(null!, 0);
            })?.Message;

            Assert.That(message, Is.EqualTo(PlannedMealsServiceErrorMessages.SessionKeyCannotBeNull));
        }

        [Test]
        public void ShouldNotRemovePlannedMealWithEmptySessionKey()
        {
            var sessionKey = "key";
            var userId = 1;

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            plannedMealsDal.Setup(mock => mock.RemovePlannedMeal(userId, 0));

            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.RemovePlannedMeal("    ", 0);
            })?.Message;

            Assert.That(message, Is.EqualTo(PlannedMealsServiceErrorMessages.SessionKeyCannotBeEmpty));
        }

        [Test]
        public void ShouldNotRemovePlannedMealWithInvalidSession()
        {
            var sessionKey = "key";
            var userId = 1;

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns((int?)null!);
            plannedMealsDal.Setup(mock => mock.RemovePlannedMeal(userId, 0));

            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.RemovePlannedMeal(sessionKey, 0);
            })?.Message;

            Assert.That(message, Is.EqualTo(PlannedMealsServiceErrorMessages.InvalidSession));
        }

        [Test]
        public void ShouldRemovePlannedMeal()
        {
            var sessionKey = "key";
            var userId = 1;

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(1);
            plannedMealsDal.Setup(mock => mock.RemovePlannedMeal(userId, 0)).Returns(true);

            var isMealRemoved = service.RemovePlannedMeal(sessionKey, 0);

            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once);
            plannedMealsDal.Verify(mock => mock.RemovePlannedMeal(userId, 0), Times.Once);
            Assert.That(isMealRemoved, Is.EqualTo(true));
        }
    }
}
