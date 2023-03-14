using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Client.Model.States;
using Web_Client.ViewModel.Recipes;

namespace WebClientTests.WebClient.Model.States.RecipePageStatesTests
{
    public class ViewModelSetAndGetTests
    {
        [Test]
        public void InitialValue()
        {
            Assert.Multiple(() =>
            {
                Assert.That(RecipePageState.ViewModel, Is.Null);
            });
        }

        [Test]
        public void SettingViewModel()
        {
            Assert.Multiple(() =>
            {
                RecipeViewModel viewModel = new RecipeViewModel();
                RecipePageState.ViewModel = viewModel;
                Assert.That(RecipePageState.ViewModel, Is.EqualTo(viewModel));
            });
        }
    }
}
