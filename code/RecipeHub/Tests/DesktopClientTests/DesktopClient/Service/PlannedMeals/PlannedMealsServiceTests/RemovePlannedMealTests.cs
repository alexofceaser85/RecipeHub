using Desktop_Client.Endpoints.PlannedMeals;
using Desktop_Client.Endpoints.Recipes;
using Desktop_Client.Service.PlannedMeals;
using Desktop_Client.Service.Recipes;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.PlannedMeals;

namespace DesktopClientTests.DesktopClient.Service.PlannedMeals.PlannedMealsServiceTests
{
    public class RemovePlannedMealTests
    {
        [Test]
        public void SuccessfullyRemovePlannedMeal()
        {
            const string sessionKey = "Key";

            Session.Key = sessionKey;

            var recipesEndpoint = new Mock<IPlannedMealsEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.RemovePlannedMeal(0));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new PlannedMealsService(recipesEndpoint.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => service.RemovePlannedMeal(0));
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
                recipesEndpoint.Verify(mock => mock.RemovePlannedMeal(0), Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            Session.Key = null;

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<InvalidOperationException>(() => 
                    new PlannedMealsService().RemovePlannedMeal(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptySessionKey()
        {
            Session.Key = "";

            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<InvalidOperationException>(() => 
                    new PlannedMealsService().RemovePlannedMeal(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void UnsuccessfullyRemovePlannedMeal()
        {
            const string sessionKey = "Key";
            const string errorMessage = "error message";

            Session.Key = sessionKey;
            var recipesEndpoint = new Mock<IPlannedMealsEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.RemovePlannedMeal(0))
                           .Throws(new ArgumentException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new PlannedMealsService(recipesEndpoint.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => service.RemovePlannedMeal(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
                recipesEndpoint.Verify(mock => mock.RemovePlannedMeal(0), Times.Once);
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
            recipesEndpoint.Setup(mock => mock.RemovePlannedMeal(0))
                           .Throws(new UnauthorizedAccessException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new PlannedMealsService(recipesEndpoint.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => service.RemovePlannedMeal(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                usersService.Verify(mock => mock.RefreshSessionKey(), Times.Once);
                recipesEndpoint.Verify(mock => mock.RemovePlannedMeal(0), Times.Once);
            });
        }
    }
}
