using System.Net;
using Server.Controllers.ResponseModels;
using Server.ErrorMessages;

namespace ServerTests.Server.Controllers.ResponseModels.StandardResponseModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotCreateStandardResponseModelWithNullMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new StandardResponseModel(HttpStatusCode.Continue, null!);
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateStandardResponseModelWithEmptyMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new StandardResponseModel(HttpStatusCode.Continue, "   ");
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldNotSetNullMessageForStandardResponseModel()
        {
            var responseModel = new StandardResponseModel(HttpStatusCode.Continue, "message");

            var message = Assert.Throws<ArgumentException>(() =>
            {
                responseModel.Message = null!;
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotSetEmptyMessageForStandardResponseModel()
        {
            var responseModel = new StandardResponseModel(HttpStatusCode.Continue, "message");

            var message = Assert.Throws<ArgumentException>(() =>
            {
                responseModel.Message = "   ";
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldSetValidMessageValueForStandardResponseModel()
        {
            var responseModel = new StandardResponseModel(HttpStatusCode.Continue, "message");
            responseModel.Message = "my message";
            Assert.That(responseModel.Message, Is.EqualTo("my message"));
        }

        [Test]
        public void ShouldCreateStandardResponseModelWithValidData()
        {
            var responseModel = new StandardResponseModel(HttpStatusCode.Continue, "message");

            Assert.That(responseModel.Code, Is.EqualTo(HttpStatusCode.Continue));
            Assert.That(responseModel.Message, Is.EqualTo("message"));
        }
    }
}
