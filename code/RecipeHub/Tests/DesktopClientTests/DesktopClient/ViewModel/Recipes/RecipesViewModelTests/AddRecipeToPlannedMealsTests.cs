using Desktop_Client.Service.PlannedMeals;
using Desktop_Client.Service.Recipes;
using Desktop_Client.ViewModel.Recipes;
using Moq;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;
using System.Text;
using Desktop_Client.Service.Ingredients;

namespace DesktopClientTests.DesktopClient.ViewModel.Recipes.RecipesViewModelTests
{
    internal class AddRecipeToPlannedMealsTests
    {
        [Test]
        public void SuccessfullyAddRecipeToPlannedMeals()
        {
            var plannedMeals = new[] {
                new PlannedMeal(new DateTime(2000, 1, 1), new [] {
                    new MealsForCategory(MealCategory.Breakfast, new [] {
                        new Recipe(0, "author", "name", "description", true)
                    }),
                    new MealsForCategory(MealCategory.Lunch, new [] {
                        new Recipe(1, "author", "name", "description", true)
                    }),
                    new MealsForCategory(MealCategory.Dinner, new [] {
                        new Recipe(2, "author", "name", "description", true)
                    })
                })
            };
            var mealDate = new DateTime(2000, 1, 1);
            const MealCategory category = MealCategory.Breakfast;
            const string recipeName = "name";
            var sb = new StringBuilder();

            sb.AppendLine(
                $"{recipeName} has been added to your meals for {mealDate.ToShortDateString()}");
            sb.AppendLine($"You now have {plannedMeals[0].Meals[(int)category].Recipes.Length} meals planned for {category.ToString().ToLower()}:");
            foreach (var recipe in plannedMeals[0].Meals[(int)category].Recipes)
            {
                sb.Append(" - ");
                sb.AppendLine(recipe.Name);
            }
            sb.Append("Would you like to see all of your planned meals now?");

            var plannedMealsService = new Mock<IPlannedMealsService>();
            plannedMealsService.Setup(mock => mock.AddPlannedMeal(mealDate, category, 0));
            plannedMealsService.Setup(mock => mock.GetPlannedMeals()).Returns(plannedMeals);

            var viewmodel = new RecipeViewModel(new RecipesService(), plannedMealsService.Object, new IngredientsService()) {
                RecipeName = recipeName
            };
            viewmodel.AddRecipeToPlannedMeals(mealDate, category);

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.PlannedMealAddedMessage, Is.EqualTo(sb.ToString()));
            });
        }
    }
}
