using System.Net;
using Server.Controllers.ResponseModels;
using Server.ErrorMessages;

namespace ServerTests.Server.Controllers.ResponseModels.LoginResponseModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotCreateLoginResponseModelWithNullMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new BaseResponseModel(HttpStatusCode.Continue, null!);
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateLoginResponseModelWithEmptyMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new BaseResponseModel(HttpStatusCode.Continue, "   ");
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldNotSetNullMessageForLoginResponseModel()
        {
            var responseModel = new BaseResponseModel(HttpStatusCode.Continue, "message");

            var message = Assert.Throws<ArgumentException>(() =>
            {
                responseModel.Message = null!;
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotSetEmptyMessageForLoginResponseModel()
        {
            var responseModel = new BaseResponseModel(HttpStatusCode.Continue, "message");

            var message = Assert.Throws<ArgumentException>(() =>
            {
                responseModel.Message = "   ";
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldSetValidMessageValueForLoginResponseModel()
        {
            var responseModel = new BaseResponseModel(HttpStatusCode.Continue, "message");
            responseModel.Message = "my message";
            Assert.That(responseModel.Message, Is.EqualTo("my message"));
        }

        [Test]
        public void ShouldCreateLoginResponseModelWithValidData()
        {
            var responseModel = new BaseResponseModel(HttpStatusCode.Continue, "message");

            Assert.That(responseModel.Code, Is.EqualTo(HttpStatusCode.Continue));
            Assert.That(responseModel.Message, Is.EqualTo("message"));
        }
    }
}
