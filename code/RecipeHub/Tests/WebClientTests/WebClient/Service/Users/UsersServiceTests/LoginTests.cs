using Moq;
using Shared_Resources.Data.IO;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Web_Client.Endpoints.Users;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Users.UsersServiceTests
{
    public class LoginTests
    {
        [SetUp]
        public void Setup()
        {
            Session.Key = null;
        }

        [TearDown]
        public void TearDown()
        {
            Session.Key = null;
        }

        [Test]
        public void ShouldNotLoginWithNullUsername()
        {
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() => { service.Login(null!, "password"); })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.UsernameCannotBeNull));
        }

        [Test]
        public void ShouldNotLoginWithEmptyUsername()
        {
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() => { service.Login("   ", "password"); })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.UsernameCannotBeEmpty));
        }

        [Test]
        public void ShouldNotLoginWithNullPassword()
        {
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() => { service.Login("username", null!); })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.PasswordCannotBeNull));
        }

        [Test]
        public void ShouldNotLoginWithEmptyPassword()
        {
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() => { service.Login("username", "   "); })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.PasswordCannotBeEmpty));
        }

        [Test]
        public void ShouldNotLoginWithNullSessionKeyLoadFilePath()
        {
            var service = new UsersService();
            service.SessionKeyLoadFile = null!;
            var message = Assert.Throws<ArgumentException>(() => { service.Login("username", "password"); })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.SessionKeyLoadFileCannotBeNull));
        }

        [Test]
        public void ShouldNotLoginWithEmptySessionKeyLoadFilePath()
        {
            var service = new UsersService();
            service.SessionKeyLoadFile = "  ";
            var message = Assert.Throws<ArgumentException>(() => { service.Login("username", "password"); })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.SessionKeyLoadFileCannotBeEmpty));
        }

        [Test]
        public void TestSuccessfulLogin()
        {
            var mockedEndpoints = new Mock<IUsersEndpoints>();
            const string previousSessionKey = "prevSession";
            const string hashedPassword =
                "64fcc6f6bc7a815041b4db51f00f4bea8e51c13b27f422da0a8522c94641c7e483c3f17b28d0a59add0c8a44a4e4fc1dd3a9ea48bad8cf5b707ac0f44a5f3536";

            for (var i = 0; i < 10; i++)
            {
                try
                {
                    SessionKeySerializers.SaveSessionKey(previousSessionKey, "logintest.txt");
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }

            mockedEndpoints.Setup(mock => mock.Login("username", hashedPassword, previousSessionKey))
                           .Returns("newSessionKey");

            var service = new UsersService(mockedEndpoints.Object);
            service.SessionKeyLoadFile = "logintest.txt";

            service.Login("username", "000000");
            Assert.That(Session.Key, Is.EqualTo("newSessionKey"));
        }

        [Test]
        public void TestUnsuccessfulLogin()
        {
            var mockedEndpoints = new Mock<IUsersEndpoints>();
            const string previousSessionKey = "prevSession";
            const string hashedPassword =
                "64fcc6f6bc7a815041b4db51f00f4bea8e51c13b27f422da0a8522c94641c7e483c3f17b28d0a59add0c8a44a4e4fc1dd3a9ea48bad8cf5b707ac0f44a5f3536";

            SessionKeySerializers.SaveSessionKey(previousSessionKey, "logintest.txt");
            mockedEndpoints.Setup(mock => mock.Login("username", hashedPassword, previousSessionKey))
                           .Throws(new ArgumentException("testException"));

            var service = new UsersService(mockedEndpoints.Object);
            service.SessionKeyLoadFile = "logintest.txt";

            var message = Assert.Throws<ArgumentException>(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    try
                    {
                        service.Login("username", "000000");
                    }
                    catch (ArgumentException)
                    {
                        throw;
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(100);
                    }
                }
            })?.Message;
            Assert.That(message, Is.EqualTo("testException"));
            Assert.That(Session.Key, Is.Null);
        }
    }
}