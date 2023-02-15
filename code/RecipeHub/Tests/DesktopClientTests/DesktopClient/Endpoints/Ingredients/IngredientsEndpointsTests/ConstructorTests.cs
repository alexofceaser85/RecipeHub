﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Endpoints.Recipes;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.Endpoints.Ingredients.IngredientsEndpointsTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            Assert.DoesNotThrow(() => _ = new IngredientEndpoints());
        }

        [Test]
        public void OneParameterConstructor()
        {
            Assert.DoesNotThrow(() => _ = new IngredientEndpoints(new HttpClient()));
        }

        [Test]
        public void NullHttpClient()
        {
            const string errorMessage = "Value cannot be null. (Parameter 'http')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(
                    () => _ = new IngredientEndpoints(null!))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}
