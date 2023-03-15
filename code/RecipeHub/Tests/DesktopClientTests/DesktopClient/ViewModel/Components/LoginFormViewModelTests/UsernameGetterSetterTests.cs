using System.Drawing;
using Desktop_Client.ViewModel.Components;
using Shared_Resources.Data.Settings;

namespace DesktopClientTests.DesktopClient.ViewModel.Components.LoginFormViewModelTests
{
    internal class UsernameGetterSetterTests
    {
        [Test]
        public void SetValidUsername()
        {
            const string username = "username";
            var viewmodel = new LoginFormViewModel {
                Username = username
            };

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Username, Is.EqualTo(username));
                Assert.That(viewmodel.UsernameErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.UsernameTextBoxColor, Is.EqualTo(Color.White));
            });
        }

        [Test]
        public void SetEmptyUsername()
        {
            const string username = "";
            var viewmodel = new LoginFormViewModel
            {
                Username = username
            };

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Username, Is.EqualTo(username));
                Assert.That(viewmodel.UsernameErrorMessage, Is.EqualTo(LoginFormViewModel.EmptyUsernameErrorMessage));
                Assert.That(viewmodel.UsernameTextBoxColor, Is.EqualTo(ColorTranslator.FromHtml(UserInterfaceSettings.ErrorColor)));
            });
        }
    }
}
