using Server.DAL.PlannedMeals;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.ErrorMessages;
using Server.Service.PlannedMeals;

namespace ServerTests.Server.Service.PlannedMeals.PlannedMealsServiceTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new PlannedMealsService();
            });
        }

        [Test]
        public void ShouldCreateTwoParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new PlannedMealsService(new PlannedMealsDal(), new UsersDal(), new RecipeDal());
            });
        }

        [Test]
        public void ShouldNotAllowNullPlannedMealsDal()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new PlannedMealsService(null!, new UsersDal(), new RecipeDal());
            })?.Message;
            Assert.That(message, Is.EqualTo(PlannedMealsServiceErrorMessages.PlannedMealsDalCannotBeNull));
        }

        [Test]
        public void ShouldNotAllowNullUsersDal()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new PlannedMealsService(new PlannedMealsDal(), null!, new RecipeDal());
            })?.Message;
            Assert.That(message, Is.EqualTo(PlannedMealsServiceErrorMessages.UsersDalCannotBeNull));
        }

        [Test]
        public void ShouldNotAllowNullRecipeDal()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new PlannedMealsService(new PlannedMealsDal(), new UsersDal(), null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(PlannedMealsServiceErrorMessages.RecipesDalCannotBeNull));
        }
    }
}
