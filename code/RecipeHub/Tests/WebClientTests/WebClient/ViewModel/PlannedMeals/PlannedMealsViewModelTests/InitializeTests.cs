using Moq;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;
using Web_Client.Service.PlannedMeals;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.PlannedMeals;

namespace WebClientTests.WebClient.ViewModel.PlannedMeals.PlannedMealsViewModelTests
{
    internal class InitializeTests
    {
        [Test]
        public void SuccessfullyInitializePlannedRecipes()
        {
            var plannedMeals = new[] {
                new PlannedMeal(new DateTime(2000, 1, 1), new [] {
                    new MealsForCategory(MealCategory.Breakfast, new [] {
                        new PlannedRecipe { Recipe = new Recipe(0, "author", "name", "description", true) }
                    }),
                    new MealsForCategory(MealCategory.Lunch, new [] {
                        new PlannedRecipe { Recipe = new Recipe(1, "author", "name", "description", true) }
                    }),
                    new MealsForCategory(MealCategory.Dinner, new [] {
                        new PlannedRecipe { Recipe = new Recipe(2, "author", "name", "description", true) }
                    })
                })
            };
            var tags0 = new [] { "breakfast" };
            var tags1 = new [] { "lunch" };
            var tags2 = new [] { "dinner" };

            var plannedMealsService = new Mock<IPlannedMealsService>();
            var recipesService = new Mock<IRecipesService>();

            plannedMealsService.Setup(mock => mock.GetPlannedMeals()).Returns(plannedMeals);
            recipesService.Setup(mock => mock.GetTypesForRecipe(0)).Returns(tags0);
            recipesService.Setup(mock => mock.GetTypesForRecipe(1)).Returns(tags1);
            recipesService.Setup(mock => mock.GetTypesForRecipe(2)).Returns(tags2);

            var viewmodel = new PlannedMealsViewModel(plannedMealsService.Object, recipesService.Object);
            viewmodel.Initialize();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.PlannedMeals, Is.EqualTo(plannedMeals));
                Assert.That(viewmodel.RecipeTags[0], Is.EqualTo(tags0));
                Assert.That(viewmodel.RecipeTags[1], Is.EqualTo(tags1));
                Assert.That(viewmodel.RecipeTags[2], Is.EqualTo(tags2));

                plannedMealsService.Verify(mock => mock.GetPlannedMeals(), Times.Once);
                recipesService.Verify(mock => mock.GetTypesForRecipe(0), Times.Once);
                recipesService.Verify(mock => mock.GetTypesForRecipe(1), Times.Once);
                recipesService.Verify(mock => mock.GetTypesForRecipe(2), Times.Once);
            });
        }
    }
}
