﻿using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Recipes;
using Web_Client.Endpoints.Recipes;
using Web_Client.Service.Recipes;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Recipes.RecipesServiceTests
{
    public class GetStepsForRecipeTests
    {
        [Test]
        public void SuccessfullyGetRecipeSteps()
        {
            var steps = new RecipeStep[] {
                new (0, "name", "instructions")
            };
            const string sessionKey = "Key";
            Session.Key = sessionKey;
            const int recipeId = 0;

            var recipesEndpoint = new Mock<IRecipesEndpoints>();
            var usersService = new Mock<IUsersService>();
            recipesEndpoint.Setup(mock => mock.GetStepsForRecipe(sessionKey, recipeId)).Returns(steps);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new RecipesService(recipesEndpoint.Object, usersService.Object);
            var result = service.GetStepsForRecipe(recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EquivalentTo(steps));
                recipesEndpoint.Verify(mock => mock.GetStepsForRecipe(sessionKey, recipeId), Times.Once);
            });
        }

        [Test]
        public void NullSessionKey()
        {
            var errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeNull + " (Parameter 'Key')";
            Session.Key = null;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(
                    () => new RecipesService().GetStepsForRecipe(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void EmptySessionKey()
        {
            Session.Key = "";
            var errorMessage = SessionKeyErrorMessages.SessionKeyCannotBeEmpty;
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(
                    () => new RecipesService().GetStepsForRecipe(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}
