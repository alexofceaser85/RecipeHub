using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Endpoints.Recipes;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.Endpoints.Recipes.RecipesEndpointsTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            Assert.DoesNotThrow(() => _ = new RecipesEndpoints());
        }

        [Test]
        public void OneParameterConstructor()
        {
            Assert.DoesNotThrow(() => _ = new RecipesEndpoints(new HttpClient()));
        }

        [Test]
        public void NullHttpClient()
        {
            const string errorMessage = RecipesEndpointsErrorMessages.ClientCannotBeNull + " (Parameter 'client')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(
                    () => _ = new RecipesEndpoints(null!))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}
