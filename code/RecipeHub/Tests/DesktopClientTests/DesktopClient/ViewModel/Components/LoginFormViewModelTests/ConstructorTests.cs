﻿using System.Drawing;
using Desktop_Client.Service.Users;
using Desktop_Client.ViewModel.Components;

namespace DesktopClientTests.DesktopClient.ViewModel.Components.LoginFormViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ValidDefaultConstructor()
        {
            var viewmodel = new LoginFormViewModel();
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Username, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Password, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.UsernameErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.PasswordErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.UsernameTextBoxColor, Is.EqualTo(Color.White));
                Assert.That(viewmodel.PasswordTextBoxColor, Is.EqualTo(Color.White));
            });
        }

        [Test]
        public void ValidOneParameterConstructor()
        {
            var viewmodel = new LoginFormViewModel(new UsersService());
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Username, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Password, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.UsernameErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.PasswordErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.UsernameTextBoxColor, Is.EqualTo(Color.White));
                Assert.That(viewmodel.PasswordTextBoxColor, Is.EqualTo(Color.White));
            });
        }

        [Test]
        public void NullUsersService()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => 
                    _ = new LoginFormViewModel(null!))!.Message;
                Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'service')"));
            });
        }
    }
}
