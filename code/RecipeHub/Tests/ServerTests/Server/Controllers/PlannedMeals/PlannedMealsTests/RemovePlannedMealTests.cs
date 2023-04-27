using System.Net;
using Moq;
using Server.Controllers.PlannedMeals;
using Server.Controllers.ResponseModels;
using Server.Data.Settings;
using Server.Service.PlannedMeals;
using Shared_Resources.Model.PlannedMeals;

namespace ServerTests.Server.Controllers.PlannedMeals.PlannedMealsTests
{
    public class RemovePlannedMealTests
    {
        [Test]
        public void ShouldRemovePlannedMeal()
        {
            var sessionKey = "key";

            var expected = new BaseResponseModel(HttpStatusCode.OK, ServerSettings.DefaultSuccessfulConnectionMessage);

            var service = new Mock<IPlannedMealsService>();
            var controller = new PlannedMealsController(service.Object);

            service.Setup(mock => mock.RemovePlannedMeal(sessionKey, 0));

            var response = controller.RemovePlannedMeal(sessionKey, 0);

            Assert.That(response.Code, Is.EqualTo(expected.Code));
            Assert.That(response.Message, Is.EqualTo(expected.Message));
            service.Verify(mock => mock.RemovePlannedMeal(sessionKey, 0), Times.Once);
        }

        [Test]
        public void ShouldNotRemovePlannedMealIfNoSession()
        {
            var sessionKey = "key";

            var expected = new BaseResponseModel(HttpStatusCode.Unauthorized, "message");

            var service = new Mock<IPlannedMealsService>();
            var controller = new PlannedMealsController(service.Object);

            service.Setup(mock => mock.RemovePlannedMeal(sessionKey, 0)).Throws(() => new UnauthorizedAccessException("message"));

            var response = controller.RemovePlannedMeal(sessionKey, 0);

            Assert.That(response.Code, Is.EqualTo(expected.Code));
            Assert.That(response.Message, Is.EqualTo(expected.Message));
            service.Verify(mock => mock.RemovePlannedMeal(sessionKey, 0), Times.Once);
        }

        [Test]
        public void ShouldNotRemovePlannedMealIfServerError()
        {
            var sessionKey = "key";

            var expected = new BaseResponseModel(HttpStatusCode.InternalServerError, "message");

            var service = new Mock<IPlannedMealsService>();
            var controller = new PlannedMealsController(service.Object);

            service.Setup(mock => mock.RemovePlannedMeal(sessionKey, 0)).Throws(() => new ArgumentException("message"));

            var response = controller.RemovePlannedMeal(sessionKey, 0);

            Assert.That(response.Code, Is.EqualTo(expected.Code));
            Assert.That(response.Message, Is.EqualTo(expected.Message));
            service.Verify(mock => mock.RemovePlannedMeal(sessionKey, 0), Times.Once);
        }
    }
}
