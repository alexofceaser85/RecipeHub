using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;
using Web_Client.Service.Ingredients;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.Recipes;

namespace WebClientTests.WebClient.ViewModel.Recipes.RecipeListViewModelTests
{
    public class GetRecipesTests
    {
        [Test]
        public void SuccessfullyGetUnfilteredRecipes()
        {
            Session.Key = "Key";
            const string searchTerm = "a";
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false),
                new(2, "author3 name3", "name3", "description3", false)
            };
            var service = new Mock<IRecipesService>();
            service.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);

            var viewmodel = new RecipesListViewModel(service.Object, new IngredientsService());
            var result = viewmodel.GetRecipes(searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(recipes));
                service.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }

        [Test]
        public void SuccessfullyGetFilteredRecipes()
        {
            Session.Key = "Key";
            const string searchTerm = "a";
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false)
            };
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            var recipesService = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            recipesService.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(0)).Returns(ingredients);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(Array.Empty<Ingredient>());

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object);
            var result = viewmodel.GetRecipes(searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(recipes));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }
    }
}