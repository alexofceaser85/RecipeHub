using Web_Client.Endpoints.Recipes;
using Web_Client.Service.Recipes;
using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Recipes;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Recipes.RecipesServiceTests
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
            Session.Key = "Key";
            const string searchTerm = "a";

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            var usersService = new Mock<IUsersService>();

            recipesEndpoint.Setup(mock => mock.GetRecipes(Session.Key, searchTerm)).Returns(recipes);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new RecipesService(recipesEndpoint.Object, usersService.Object);
            var result = service.GetRecipes(searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EquivalentTo(recipes));
                recipesEndpoint.Verify(mock => mock.GetRecipes(Session.Key, searchTerm), Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            Session.Key = null;
            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull + " (Parameter 'Key')";
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
            Session.Key = "  ";
            const string errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
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
                var message = Assert.Throws<ArgumentNullException>(() => new RecipesService().GetRecipes(null!))!
                                    .Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}