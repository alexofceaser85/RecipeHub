using Web_Client.Model.Users;

namespace WebClientTests.WebClient.Model.Users.UsersInfoBindingModelTests
{
    public class UsersInfoBindingModelTests
    {
        [Test]
        public void ShouldCreateUserInfoBindingModel()
        {
            var bindingModel = new UserInfoBindingModel();
            bindingModel.Username = "username";
            bindingModel.Password = "password";

            Assert.That(bindingModel.Username, Is.EqualTo("username"));
            Assert.That(bindingModel.Password, Is.EqualTo("password"));
        }
    }
}