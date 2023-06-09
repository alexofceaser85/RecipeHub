﻿using Moq;
using Web_Client.Endpoints.Ingredients;
using Web_Client.Service.Ingredients;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Ingredients.IngredientsServiceTests
{
    public class DeleteAllIngredientsForUserTests
    {
        [Test]
        public void SuccessfullyDeleteIngredients()
        {
            var endpoints = new Mock<IIngredientEndpoints>();
            var usersService = new Mock<IUsersService>();
            endpoints.Setup(mock => mock.DeleteAllIngredientsForUser()).Returns(true);
            usersService.Setup(mock => mock.RefreshSessionKey());
            var service = new IngredientsService(endpoints.Object, usersService.Object);

            Assert.Multiple(() =>
            {
                var result = service.DeleteAllIngredientsForUser();
                Assert.That(result, Is.EqualTo(true));
                endpoints.Verify(mock => mock.DeleteAllIngredientsForUser(), Times.Once);
            });
        }
    }
}