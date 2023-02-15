using Desktop_Client.ViewModel.Users;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.ViewModel.Users.UsersViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterUsersViewModel()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new UsersViewModel();
            });
        }

        [Test]
        public void ShouldNotAllowNullServer()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UsersViewModel(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceViewModelErrorMessages.UsersServiceCannotBeNull));
        }
    }
}
