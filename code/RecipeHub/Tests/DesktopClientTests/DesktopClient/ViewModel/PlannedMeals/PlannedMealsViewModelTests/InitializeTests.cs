using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Service.PlannedMeals;
using Desktop_Client.ViewModel.PlannedMeals;
using Moq;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;

namespace DesktopClientTests.DesktopClient.ViewModel.PlannedMeals.PlannedMealsViewModelTests
{
    internal class InitializeTests
    {
        [Test]
        public void SuccessfullyInitializePlannedRecipes()
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

            var service = new Mock<IPlannedMealsService>();
            service.Setup(mock => mock.GetPlannedMeals()).Returns(plannedMeals);

            var viewmodel = new PlannedMealsViewModel(service.Object);
            viewmodel.Initialize();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.PlannedMeals, Is.EqualTo(plannedMeals));
                service.Verify(mock => mock.GetPlannedMeals(), Times.Once);
            });
        }
    }
}
