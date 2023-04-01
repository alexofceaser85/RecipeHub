using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.PlannedMeals;
using Desktop_Client.Service.Recipes;
using Desktop_Client.Service.Users;
using Desktop_Client.ViewModel.Recipes;
using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.ViewModel.Recipes.RecipesViewModelTests
{
    internal class GetMissingIngredientsForRecipeTests
    {

        [Test]
        public void GetEmptyArrayOfMissingIngredients()
        {
            const int recipeId = 0;
            Session.Key = "key";
            var ingredients = Array.Empty<Ingredient>();

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetMissingIngredientsForRecipe(recipeId)).Returns(ingredients);

            var viewmodel = new RecipeViewModel(new RecipesService(), new PlannedMealsService(), service.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.GetMissingIngredientsForRecipe());
                Assert.That(viewmodel.MissingIngredients, Is.EquivalentTo(ingredients));
                service.Verify(mock => mock.GetMissingIngredientsForRecipe(recipeId), Times.Once);
            });
        }

        [Test]
        public void GetSingleMissingIngredient()
        {
            const int recipeId = 0;
            Session.Key = "key";
            var ingredients = new Ingredient[] { new() };

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetMissingIngredientsForRecipe(recipeId)).Returns(ingredients);

            var viewmodel = new RecipeViewModel(new RecipesService(), new PlannedMealsService(), service.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.GetMissingIngredientsForRecipe());
                Assert.That(viewmodel.MissingIngredients, Is.EquivalentTo(ingredients));
                service.Verify(mock => mock.GetMissingIngredientsForRecipe(recipeId), Times.Once);
            });
        }

        [Test]
        public void GetManyMissingIngredients()
        {
            const int recipeId = 0;
            Session.Key = "key";
            var ingredients = new Ingredient[] { new(), new(), new() };

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetMissingIngredientsForRecipe(recipeId)).Returns(ingredients);

            var viewmodel = new RecipeViewModel(new RecipesService(), new PlannedMealsService(), service.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.GetMissingIngredientsForRecipe());
                Assert.That(viewmodel.MissingIngredients, Is.EquivalentTo(ingredients));
                service.Verify(mock => mock.GetMissingIngredientsForRecipe(recipeId), Times.Once);
            });
        }

        [Test]
        public void UnsuccessfullyGetMissingIngredients()
        {
            const string errorMessage = "error message";
            const int recipeId = 0;
            Session.Key = "key";

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetMissingIngredientsForRecipe(recipeId))
                   .Throws(new ArgumentException(errorMessage));

            var viewmodel = new RecipeViewModel(new RecipesService(), new PlannedMealsService(), service.Object);
            
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => viewmodel.GetMissingIngredientsForRecipe())!.Message;
                Assert.That(message, Is.EquivalentTo(errorMessage));
                service.Verify(mock => mock.GetMissingIngredientsForRecipe(recipeId), Times.Once);
            });
        }

        [Test]
        public void SessionKeyIsInvalid()
        {
            const string errorMessage = "error message";
            const int recipeId = 0;
            Session.Key = "key";

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetMissingIngredientsForRecipe(recipeId))
                   .Throws(new UnauthorizedAccessException(errorMessage));

            var viewmodel = new RecipeViewModel(new RecipesService(), new PlannedMealsService(), service.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => viewmodel.GetMissingIngredientsForRecipe())!.Message;
                Assert.That(message, Is.EquivalentTo(errorMessage));
                service.Verify(mock => mock.GetMissingIngredientsForRecipe(recipeId), Times.Once);
            });
        }
    }
}
