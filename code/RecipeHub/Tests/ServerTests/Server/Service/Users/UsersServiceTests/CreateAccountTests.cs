using Moq;
using Server.DAL.Users;
using Server.ErrorMessages;
using Server.Service.Users;
using Shared_Resources.Model.Users;

namespace ServerTests.Server.Service.Users.UsersServiceTests
{
    public class CreateAccountTests
    {
        [Test]
        public void ShouldNotCreateAccountIfAccountToCreateIsNull()
        {
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.CreateAccount(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceServerErrorMessages.AccountToCreateCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateAccountIfUserNameIsAlreadyTaken()
        {
            var userDal = new Mock<IUsersDal>();

            userDal.Setup(mock => mock.CheckIfUserNameExists("username")).Returns(true);

            var service = new UsersService(userDal.Object);

            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.CreateAccount(new NewAccount("username", "000000", "000000", "first", "lname", "email@email.com"));
            })?.Message;

            Assert.That(message, Is.EqualTo(UsersServiceServerErrorMessages.UserNameAlreadyExists));
        }

        [Test]
        public void ShouldCreateAccountIfUserNameNotAlreadyTaken()
        {
            var userDal = new Mock<IUsersDal>();

            userDal.Setup(mock => mock.CheckIfUserNameExists(It.IsAny<string>())).Returns(false);
            userDal.Setup(mock => mock.CreateAccount(It.IsAny<NewAccount>()));

            var service = new UsersService(userDal.Object);

            service.CreateAccount(new NewAccount("username", "000000", "000000", "first", "lname", "email@email.com"));

            userDal.Verify(mock => mock.CreateAccount(It.IsAny<NewAccount>()), Times.Once());
        }
    }
}
