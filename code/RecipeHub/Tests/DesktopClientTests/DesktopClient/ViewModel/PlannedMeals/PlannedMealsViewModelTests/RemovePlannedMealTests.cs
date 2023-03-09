using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Service.PlannedMeals;
using Desktop_Client.ViewModel.PlannedMeals;
using Moq;
using Shared_Resources.Model.PlannedMeals;

namespace DesktopClientTests.DesktopClient.ViewModel.PlannedMeals.PlannedMealsViewModelTests
{
    internal class RemovePlannedMealTests
    {
        [Test]
        public void SuccessfullyRemovePlannedMeal()
        {
            var mealDate = new DateTime(2000, 1, 1);
            const MealCategory category = MealCategory.Breakfast;
            const int recipeId = 0;

            var service = new Mock<IPlannedMealsService>();
            service.Setup(mock => mock.RemovePlannedMeal(mealDate, category, recipeId));

            var viewmodel = new PlannedMealsViewModel(service.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.RemovePlannedMeal(mealDate, category, recipeId));
                service.Verify(mock => mock.RemovePlannedMeal(mealDate, category, recipeId), Times.Once);
            });
        }
    }
}
