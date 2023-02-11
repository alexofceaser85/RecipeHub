using System.Net;
using Server.Controllers.ResponseModels;
using Server.ErrorMessages;
using Shared_Resources.Model.Users;

namespace ServerTests.Server.Controllers.ResponseModels
{
    public class UserInfoResponseModelTests
    {
        [Test]
        public void ShouldNotCreateUserInfoResponseModelWithNullMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UserInfoResponseModel(HttpStatusCode.Continue, null!, null);
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateUserInfoResponseModelWithEmptyMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UserInfoResponseModel(HttpStatusCode.Continue, "   ", null);
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldNotSetNullMessageForUserInfoResponseModel()
        {
            var userInfo = new UserInfo("username", "firstname", "lastname", "email@email.com");
            var responseModel = new UserInfoResponseModel(HttpStatusCode.Continue, "message", userInfo);

            var message = Assert.Throws<ArgumentException>(() =>
            {
                responseModel.Message = null!;
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotSetEmptyMessageForUserInfoResponseModel()
        {
            var userInfo = new UserInfo("username", "firstname", "lastname", "email@email.com");
            var responseModel = new UserInfoResponseModel(HttpStatusCode.Continue, "message", userInfo);

            var message = Assert.Throws<ArgumentException>(() =>
            {
                responseModel.Message = "   ";
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldSetValidMessageValueForUserInfoResponseModel()
        {
            var userInfo = new UserInfo("username", "firstname", "lastname", "email@email.com");
            var responseModel = new UserInfoResponseModel(HttpStatusCode.Continue, "message", userInfo);
            responseModel.Message = "my message";
            Assert.That(responseModel.Message, Is.EqualTo("my message"));
        }

        [Test]
        public void ShouldCreateUserInfoResponseModelWithValidData()
        {
            var userInfo = new UserInfo("username", "firstname", "lastname", "email@email.com");
            var responseModel = new UserInfoResponseModel(HttpStatusCode.Continue, "message", userInfo);

            Assert.That(responseModel.Code, Is.EqualTo(HttpStatusCode.Continue));
            Assert.That(responseModel.Message, Is.EqualTo("message"));
            Assert.That(responseModel.UserInfo, Is.EqualTo(userInfo));
        }
    }
}
