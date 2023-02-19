using Desktop_Client.Endpoints.Recipes;
using Desktop_Client.Service.Recipes;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Recipes;

namespace DesktopClientTests.DesktopClient.Service.Recipes.RecipesServiceTests
{
    public class GetRecipesTests
    {
        [Test]
        public void SuccessfullyGetRecipes()
        {
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false),
                new(2, "author3 name3", "name3", "description3", false)
            };
            const string sessionKey = "Key";
            Session.Key = sessionKey;
            const string searchTerm = "";

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.GetRecipes(sessionKey, searchTerm)).Returns(recipes);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new RecipesService(recipesEndpoint.Object, usersService.Object);
            var result = service.GetRecipes(searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EquivalentTo(recipes));
                recipesEndpoint.Verify(mock => mock.GetRecipes(sessionKey, searchTerm), Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            var errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull + " (Parameter 'Key')";
            Session.Key = null;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => new RecipesService().GetRecipes(null!))!
                                    .Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptySessionKey()
        {
            var errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Session.Key = "";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => new RecipesService().GetRecipes(""))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void NullSearchTerm()
        {
            Session.Key = "Key";
            var errorMessage = RecipesServiceErrorMessages.SearchTermCannotBeNull + " (Parameter 'searchTerm')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => new RecipesService().GetRecipes(null!))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}