using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Service.Recipes;
using Desktop_Client.ViewModel.Recipes;

namespace DesktopClientTests.DesktopClient.ViewModel.Recipes.RecipesListViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructorDoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _ = new RecipesListViewModel());
        }

        [Test]
        public void OneParameterConstructorDoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _ = new RecipesListViewModel(new RecipesService()));
        }

        [Test]
        public void NullServiceThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new RecipesListViewModel(null!));
        }
    }
}
