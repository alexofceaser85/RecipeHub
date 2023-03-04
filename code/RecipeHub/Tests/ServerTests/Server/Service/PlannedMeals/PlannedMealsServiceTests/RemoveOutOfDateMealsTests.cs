using Moq;
using Server.DAL.PlannedMeals;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.PlannedMeals;

namespace ServerTests.Server.Service.PlannedMeals.PlannedMealsServiceTests
{
    public class RemoveOutOfDateMealsTests
    {
        [Test]
        public void ShouldRemoveOutOfDateMeals()
        {
            var dal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(dal.Object, usersDal.Object, recipesDal.Object);
            var dateTime = new DateTime(2023, 03, 03);

            dal.Setup(mock => mock.RemoveOutOfDateMeals(dateTime));
            service.RemoveOutOfDateMeals(dateTime);
            dal.Verify(mock => mock.RemoveOutOfDateMeals(dateTime), Times.Once);
        }
    }
}
