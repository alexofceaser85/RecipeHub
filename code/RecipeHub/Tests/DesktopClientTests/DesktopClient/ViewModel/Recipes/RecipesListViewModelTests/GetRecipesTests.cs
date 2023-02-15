using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Recipes;
using Desktop_Client.ViewModel.Recipes;
using Moq;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;

namespace DesktopClientTests.DesktopClient.ViewModel.Recipes.RecipesListViewModelTests
{
    public class GetRecipesTests
    {
        [Test]
        public void SuccessfullyGetUnfilteredRecipes()
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

            var viewmodel = new RecipesListViewModel(service.Object, new IngredientsService());
            var result = viewmodel.GetRecipes(sessionKey, searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(recipes));
                service.Verify(mock => mock.GetRecipes(sessionKey, searchTerm), Times.Once);
            });
        }

        [Test]
        public void SuccessfullyGetFilteredRecipes()
        {
            const string sessionKey = "Key";
            const string searchTerm = "";
            var recipes = new Recipe[] {
                new (0, "author1 name1", "name1", "description1", false),
                new (1, "author2 name2", "name2", "description2", false),
            };
            var expectedRecipes = new Recipe[] {
                recipes[1]
            };
            var ingredients = new Ingredient[] {
                new Ingredient("Apples", 1, MeasurementType.Quantity)
            };
            var recipesService = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            recipesService.Setup(mock => mock.GetRecipes(sessionKey, searchTerm)).Returns(recipes);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(sessionKey, 0)).Returns(ingredients);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(Array.Empty<Ingredient>()            );

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object);
            var result = viewmodel.GetRecipes(sessionKey, searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(recipes));
                recipesService.Verify(mock => mock.GetRecipes(sessionKey, searchTerm), Times.Once);
            });
        }
    }
}
