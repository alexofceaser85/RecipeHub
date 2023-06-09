﻿using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.Service.Ingredients.IngredientsServiceTests
{
    public class GetSuggestionsTests
    {
        [Test]
        public void SuccessfullyGetIngredients()
        {
            var suggestions = new[] {
                "asd"
            };
            const string ingredientName = "name";
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();

            endpoints.Setup(mock => mock.GetSuggestions(ingredientName)).Returns(suggestions);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var result = service.GetSuggestions(ingredientName);
                Assert.That(result, Is.EquivalentTo(suggestions));
                endpoints.Verify(mock => mock.GetSuggestions(ingredientName), Times.Once);
            });
        }

        [Test]
        public void FailedToGetSuggestions()
        {
            const string errorMessage = "error message";
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.GetSuggestions("")).Throws(new ArgumentException(errorMessage));
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => service.GetSuggestions(""))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                endpoints.Verify(mock => mock.GetSuggestions(""), Times.Once);
            });
        }
    }
}