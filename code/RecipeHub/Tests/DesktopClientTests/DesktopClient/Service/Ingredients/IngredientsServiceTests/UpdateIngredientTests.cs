﻿using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.Service.Ingredients.IngredientsServiceTests
{
    public class AddIngredientTests
    {
        [Test]
        public void SuccessfullyUpdateIngredient()
        {
            var ingredient = new Ingredient();
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.UpdateIngredient(ingredient)).Returns(true);
            usersService.Setup(mock => mock.RefreshSessionKey());

            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var result = service.UpdateIngredient(ingredient);
                Assert.That(result, Is.EqualTo(true));
                endpoints.Verify(mock => mock.UpdateIngredient(ingredient), Times.Once);
            });
        }
    }
}