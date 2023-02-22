using Desktop_Client.Service.Users;
using Desktop_Client.ViewModel.Users;

namespace DesktopClientTests.DesktopClient.ViewModel.Users.RegistrationScreenViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            var viewmodel = new RegistrationScreenViewModel();
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Username, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Password, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.VerifyPassword, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.FirstName, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.LastName, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Email, Is.EqualTo(string.Empty));
            });
        }

        [Test]
        public void ValidOneParameterConstructor()
        {
            var viewmodel = new RegistrationScreenViewModel(new UsersService());
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Username, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Password, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.VerifyPassword, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.FirstName, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.LastName, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Email, Is.EqualTo(string.Empty));
            });
        }

        [Test]
        public void NullUsersService()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => 
                    _ = new RegistrationScreenViewModel(null!))!.Message;
                Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'service')"));
            });
        }
    }
}
