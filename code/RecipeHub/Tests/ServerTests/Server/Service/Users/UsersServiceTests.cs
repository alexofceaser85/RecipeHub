using Moq;
using Server.DAL.Users;
using Server.ErrorMessages;
using Server.Service.Users;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Users;

namespace ServerTests.Server.Service.Users
{
    public class UsersServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldNotLoginWithNullUsername()
        {
            var usersService = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = usersService.Login(null!, "password", "key");
            })?.Message;

            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.UsernameCannotBeNull));
        }

        [Test]
        public void ShouldNotLoginWithBlankUsername()
        {
            var usersService = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = usersService.Login("   ", "password", "key");
            })?.Message;

            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.UsernameCannotBeEmpty));
        }

        [Test]
        public void ShouldNotLoginWithNullPassword()
        {
            var usersService = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = usersService.Login("username", null!, "key");
            })?.Message;

            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.PasswordCannotBeNull));
        }

        [Test]
        public void ShouldNotLoginWithBlankPassword()
        {
            var usersService = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = usersService.Login("username", "   ", "key");
            })?.Message;

            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.PasswordCannotBeEmpty));
        }

        [Test]
        public void ShouldNotLoginWithBlankSessionKey()
        {
            var usersService = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = usersService.Login("username", "password", "   ");
            })?.Message;

            Assert.That(message, Is.EqualTo(ServerUsersServiceErrorMessages.PreviousSessionKeyCannotBeEmpty));
        }

        [Test]
        public void ShouldNotAllowNullDataAccessLayer()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UsersService(null!);
            })?.Message;

            Assert.That(message, Is.EqualTo(ServerUsersServiceErrorMessages.DataAccessLayerCannotBeNull));
        }

        [Test]
        public void ShouldNotAllowWrongUserNameAndPasswordCombination()
        {
            var userDal = new Mock<IUsersDal>();

            userDal.Setup(mock => mock.VerifyUserNameAndPasswordCombination("username", "password")).Returns((int?)null);

            var service = new UsersService(userDal.Object);

            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.Login("username", "password", "key");
            })?.Message;

            Assert.That(message, Is.EqualTo(ServerUsersServiceErrorMessages.UsernameAndPasswordCombinationIsWrong));
        }

        [Test]
        public void ShouldLoginWithNonExistingSessionKey()
        {
            var userDal = new Mock<IUsersDal>();

            userDal.Setup(mock => mock.VerifyUserNameAndPasswordCombination("username", "password")).Returns(1);
            userDal.Setup(mock => mock.VerifySessionKeyDoesNotExist(It.IsAny<string>())).Returns(true);

            var service = new UsersService(userDal.Object);

            var returnedValue = service.Login("username", "password", null);

            userDal.Verify(mock => mock.VerifyUserNameAndPasswordCombination("username", "password"), Times.Once());
            userDal.Verify(mock => mock.VerifySessionKeyDoesNotExist(It.IsAny<string>()), Times.Once());
            userDal.Verify(mock => mock.RemoveSessionKey("key"), Times.Never());
            userDal.Verify(mock => mock.AddUserSession(1, It.IsAny<string>()), Times.Once());
            Assert.That(returnedValue, Is.Not.Empty);
        }

        [Test]
        public void ShouldLoginWithExistingSessionKey()
        {
            var userDal = new Mock<IUsersDal>();

            userDal.Setup(mock => mock.VerifyUserNameAndPasswordCombination("username", "password")).Returns(1);
            userDal.Setup(mock => mock.VerifySessionKeyDoesNotExist(It.IsAny<string>())).Returns(true);

            var service = new UsersService(userDal.Object);

            var returnedValue = service.Login("username", "password", "key");

            userDal.Verify(mock => mock.VerifyUserNameAndPasswordCombination("username", "password"), Times.Once());
            userDal.Verify(mock => mock.VerifySessionKeyDoesNotExist(It.IsAny<string>()), Times.Once());
            userDal.Verify(mock => mock.RemoveSessionKey("key"), Times.Once());
            userDal.Verify(mock => mock.AddUserSession(1, It.IsAny<string>()), Times.Once());
            Assert.That(returnedValue, Is.Not.Empty);
        }

        [Test]
        public void ShouldLoginIfNewSessionKeyIsTaken()
        {
            var userDal = new Mock<IUsersDal>();

            userDal.Setup(mock => mock.VerifyUserNameAndPasswordCombination("username", "password")).Returns(1);
            userDal.SetupSequence(mock => mock.VerifySessionKeyDoesNotExist(It.IsAny<string>())).Returns(false).Returns(false).Returns(true);

            var service = new UsersService(userDal.Object);

            var returnedValue = service.Login("username", "password", "key");

            userDal.Verify(mock => mock.VerifyUserNameAndPasswordCombination("username", "password"), Times.Once());
            userDal.Verify(mock => mock.VerifySessionKeyDoesNotExist(It.IsAny<string>()), Times.Exactly(3));
            userDal.Verify(mock => mock.RemoveSessionKey("key"), Times.Once());
            userDal.Verify(mock => mock.AddUserSession(1, It.IsAny<string>()), Times.Once());
            Assert.That(returnedValue, Is.Not.Empty);
        }

        [Test]
        public void ShouldNotLogoutIfSessionKeyIsNull()
        {
            var server = new UsersService();
            Assert.Throws<ArgumentException>(() =>
            {
                server.Logout(null!);
            });
        }

        [Test]
        public void ShouldNotLogoutIfSessionKeyIsBlank()
        {
            var server = new UsersService();
            Assert.Throws<ArgumentException>(() =>
            {
                server.Logout("   ");
            });
        }

        [Test]
        public void ShouldLogoutWithValidSessionKey()
        {
            var userDal = new Mock<IUsersDal>();
            var service = new UsersService(userDal.Object);
            service.Logout("Key");
            userDal.Verify(mock => mock.RemoveSessionKey("Key"), Times.Once());
        }

        [Test]
        public void ShouldNotGetUserInfoIfSessionKeyIsNull()
        {
            var server = new UsersService();
            Assert.Throws<ArgumentException>(() =>
            {
                server.GetUserInfo(null!);
            });
        }

        [Test]
        public void ShouldNotGetUserInfoIfSessionKeyIsBlank()
        {
            var server = new UsersService();
            Assert.Throws<ArgumentException>(() =>
            {
                server.GetUserInfo("   ");
            });
        }

        [Test]
        public void ShouldReturnUserInfoIfServerRetrievedServerInfo()
        {
            var userInfo = new UserInfo("username", "firstname", "lastname", "username@gmail.com");

            var userDal = new Mock<IUsersDal>();

            userDal.Setup(mock => mock.GetUserInfo("Key")).Returns(userInfo);

            var service = new UsersService(userDal.Object);

            var returnedValue = service.GetUserInfo("Key");

            userDal.Verify(mock => mock.GetUserInfo("Key"), Times.Once());
            Assert.That(returnedValue, Is.EqualTo(userInfo));
        }

        [Test]
        public void ShouldNotReturnUserInfoIfServerCouldNotRetrieveServerInfo()
        {
            var userDal = new Mock<IUsersDal>();

            userDal.Setup(mock => mock.GetUserInfo("Key")).Returns((UserInfo)null!);

            var service = new UsersService(userDal.Object);

            var returnedValue = service.GetUserInfo("Key");

            userDal.Verify(mock => mock.GetUserInfo("Key"), Times.Once());
            Assert.That(returnedValue, Is.EqualTo(null!));
        }
    }
}
