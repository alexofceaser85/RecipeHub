using System.Net;
using Server.Controllers.ResponseModels;
using Server.ErrorMessages;
using Shared_Resources.Model.PlannedMeals;

namespace ServerTests.Server.Controllers.ResponseModels.PlannedMealsResponseModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotAllowNullMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new PlannedMealsResponseModel(HttpStatusCode.OK, null!, new PlannedMeal[0]);
            })?.Message;
            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotAllowEmptyMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new PlannedMealsResponseModel(HttpStatusCode.OK, "   ", new PlannedMeal[0]);
            })?.Message;
            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldNotAllowSettingToNullMessage()
        {
            var response = new PlannedMealsResponseModel(HttpStatusCode.OK, "message", new PlannedMeal[0]);
            
            var message = Assert.Throws<ArgumentException>(() =>
            {
                response.Message = null!;
            })?.Message;
            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotAllowSettingToEmptyMessage()
        {
            var response  = new PlannedMealsResponseModel(HttpStatusCode.OK, "message", new PlannedMeal[0]);

            var message = Assert.Throws<ArgumentException>(() =>
            {
                response.Message = "   ";
            })?.Message;
            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldCreateValidMessage()
        {
            var response = new PlannedMealsResponseModel(HttpStatusCode.OK, "message", new PlannedMeal[0]);
            Assert.That(response.Code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Message, Is.EqualTo("message"));
            Assert.That(response.PlannedMeals, Is.EqualTo(new PlannedMeal[0]));
        }

        [Test]
        public void ShouldSetCreateValidMessage()
        {
            var response = new PlannedMealsResponseModel(HttpStatusCode.OK, "message", new PlannedMeal[0]);
            response.Message = "new message";
            Assert.That(response.Code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Message, Is.EqualTo("new message"));
            Assert.That(response.PlannedMeals, Is.EqualTo(new PlannedMeal[0]));
        }
    }
}
