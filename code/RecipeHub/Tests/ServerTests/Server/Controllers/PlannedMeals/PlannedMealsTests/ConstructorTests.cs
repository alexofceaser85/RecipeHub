using Server.Controllers.PlannedMeals;
using Server.ErrorMessages;
using Server.Service.PlannedMeals;
using Shared_Resources.Model.PlannedMeals;

namespace ServerTests.Server.Controllers.PlannedMeals.PlannedMealsTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new PlannedMealsController();
            });
        }

        [Test]
        public void ShouldCreateOneParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new PlannedMealsController(new PlannedMealsService());
            });
        }

        [Test]
        public void ShouldNotAllowNullService()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new PlannedMealsController(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(PlannedMealsControllerErrorMessages.PlannedMealsServiceCannotBeNull));
        }
    }
}
