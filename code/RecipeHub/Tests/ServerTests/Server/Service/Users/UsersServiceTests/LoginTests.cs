using Moq;
using Server.DAL.Users;
using Server.ErrorMessages;
using Server.Service.Users;
using Shared_Resources.ErrorMessages;

namespace ServerTests.Server.Service.Users.UsersServiceTests
{
    public class LoginTests
    {
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
    }
}
