using Web_Client.Model.Users;

namespace WebClientTests.WebClient.Model.Users.NewAccountInfoBindingModelTests
{
    public class ConstructorTests
    {
        public class NewAccountInfoBindingModelTests
        {
            [Test]
            public void ShouldCreateNewAccountInfoBindingModel()
            {
                var bindingModel = new NewAccountInfoBindingModel();
                bindingModel.Username = "username";
                bindingModel.Password = "password";
                bindingModel.VerifyPassword = "password";
                bindingModel.FirstName = "first";
                bindingModel.LastName = "lname";
                bindingModel.Email = "email@email.com";

                Assert.That(bindingModel.Username, Is.EqualTo("username"));
                Assert.That(bindingModel.Password, Is.EqualTo("password"));
                Assert.That(bindingModel.VerifyPassword, Is.EqualTo("password"));
                Assert.That(bindingModel.FirstName, Is.EqualTo("first"));
                Assert.That(bindingModel.LastName, Is.EqualTo("lname"));
                Assert.That(bindingModel.Email, Is.EqualTo("email@email.com"));
            }
        }
    }
}