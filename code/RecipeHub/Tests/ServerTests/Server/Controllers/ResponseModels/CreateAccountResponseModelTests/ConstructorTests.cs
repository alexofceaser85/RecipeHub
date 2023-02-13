using Server.Controllers.ResponseModels;
using Server.ErrorMessages;
using System.Net;

namespace ServerTests.Server.Controllers.ResponseModels.CreateAccountResponseModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotCreateCreateAccountResponseModelWithNullMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new CreateAccountResponseModel(HttpStatusCode.Continue, null!);
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateCreateAccountResponseModelWithEmptyMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new CreateAccountResponseModel(HttpStatusCode.Continue, "   ");
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldNotSetNullMessageForCreateAccountResponseModel()
        {
            var responseModel = new CreateAccountResponseModel(HttpStatusCode.Continue, "message");

            var message = Assert.Throws<ArgumentException>(() =>
            {
                responseModel.Message = null!;
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotSetEmptyMessageForCreateAccountResponseModel()
        {
            var responseModel = new CreateAccountResponseModel(HttpStatusCode.Continue, "message");

            var message = Assert.Throws<ArgumentException>(() =>
            {
                responseModel.Message = "   ";
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldSetValidMessageValueForCreateAccountResponseModel()
        {
            var responseModel = new CreateAccountResponseModel(HttpStatusCode.Continue, "message");
            responseModel.Message = "my message";
            Assert.That(responseModel.Message, Is.EqualTo("my message"));
        }

        [Test]
        public void ShouldCreateCreateAccountResponseModelWithValidData()
        {
            var responseModel = new CreateAccountResponseModel(HttpStatusCode.Continue, "message");

            Assert.That(responseModel.Code, Is.EqualTo(HttpStatusCode.Continue));
            Assert.That(responseModel.Message, Is.EqualTo("message"));
        }
    }
}
