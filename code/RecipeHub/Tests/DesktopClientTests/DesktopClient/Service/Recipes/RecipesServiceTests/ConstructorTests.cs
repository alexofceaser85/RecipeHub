using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Endpoints.Recipes;
using Desktop_Client.Service.Recipes;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.Service.Recipes.RecipesServiceTests
{
    public class ConstructorTests
    {
        [Test]
        public void ValidDefaultConstructor()
        {
            Assert.DoesNotThrow(() => new RecipesService());
        }

        [Test]
        public void ValidOneParameterConstructor()
        {
            Assert.DoesNotThrow(() => new RecipesService(new RecipesEndpoints()));
        }

        [Test]
        public void NullRecipesEndpoint()
        {
            var errorMessage = RecipesServiceErrorMessages.RecipesEndpointsCannotBeNull + " (Parameter 'endpoints')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() =>
                {
                    _ = new RecipesService(null!);
                })?.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}
