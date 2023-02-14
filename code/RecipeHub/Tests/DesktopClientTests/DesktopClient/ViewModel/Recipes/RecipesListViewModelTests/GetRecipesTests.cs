using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Service.Recipes;
using Desktop_Client.ViewModel.Recipes;
using Moq;
using Shared_Resources.Model.Recipes;

namespace DesktopClientTests.DesktopClient.ViewModel.Recipes.RecipesListViewModelTests
{
    public class GetRecipesTests
    {
        [Test]
        public void SuccessfullyGetRecipes()
        {
            const string sessionKey = "Key";
            const string searchTerm = "";
            var recipes = new Recipe[] {
                new (0, "author1 name1", "name1", "description1", false),
                new (1, "author2 name2", "name2", "description2", false),
                new (2, "author3 name3", "name3", "description3", false),
            };
            var service = new Mock<IRecipesService>();
            service.Setup(mock => mock.GetRecipes(sessionKey, searchTerm)).Returns(recipes);

            var viewmodel = new RecipesListViewModel(service.Object);
            var result = viewmodel.GetRecipes(sessionKey, searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(recipes));
                service.Verify(mock => mock.GetRecipes(sessionKey, searchTerm), Times.Once);
            });
        }
    }
}
