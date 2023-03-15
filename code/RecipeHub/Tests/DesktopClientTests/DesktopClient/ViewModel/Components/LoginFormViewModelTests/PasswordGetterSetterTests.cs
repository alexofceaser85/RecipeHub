using System.Drawing;
using Desktop_Client.ViewModel.Components;
using Shared_Resources.Data.Settings;

namespace DesktopClientTests.DesktopClient.ViewModel.Components.LoginFormViewModelTests
{
    internal class PasswordGetterSetterTests
    {
        [Test]
        public void SetValidPassword()
        {
            const string password = "password";
            var viewmodel = new LoginFormViewModel {
                Password = password
            };

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Password, Is.EqualTo(password));
                Assert.That(viewmodel.PasswordErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.PasswordTextBoxColor, Is.EqualTo(Color.White));
            });
        }

        [Test]
        public void SetEmptyPassword()
        {
            const string password = "";
            var viewmodel = new LoginFormViewModel
            {
                Password = password
            };

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Password, Is.EqualTo(password));
                Assert.That(viewmodel.PasswordErrorMessage, Is.EqualTo(LoginFormViewModel.EmptyPasswordErrorMessage));
                Assert.That(viewmodel.PasswordTextBoxColor, Is.EqualTo(ColorTranslator.FromHtml(UserInterfaceSettings.ErrorColor)));
            });
        }
    }
}
