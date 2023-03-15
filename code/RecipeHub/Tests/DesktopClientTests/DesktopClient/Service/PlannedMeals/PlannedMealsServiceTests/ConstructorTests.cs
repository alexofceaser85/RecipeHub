using Desktop_Client.Endpoints.PlannedMeals;
using Desktop_Client.Service.PlannedMeals;
using Desktop_Client.Service.Users;

namespace DesktopClientTests.DesktopClient.Service.PlannedMeals.PlannedMealsServiceTests
{
    public class ConstructorTests
    {
        [Test]
        public void ValidDefaultConstructor()
        {
            Assert.DoesNotThrow(() => _ = new PlannedMealsService());
        }

        [Test]
        public void ValidTweParameterConstructor()
        {
            Assert.DoesNotThrow(() => _ = new PlannedMealsService(new PlannedMealsEndpoints(), new UsersService()));
        }

        [Test]
        public void NullPlannedMealsEndpoints()
        {
            var errorMessage = "Value cannot be null. (Parameter 'plannedMealsEndpoints')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() =>
                {
                    _ = new PlannedMealsService(null!, new UsersService());
                })?.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void NullUsersService()
        {
            var errorMessage = "Value cannot be null. (Parameter 'usersService')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() =>
                {
                    _ = new PlannedMealsService(new PlannedMealsEndpoints(), null!);
                })?.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}