using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Client.ViewModel.PlannedMeals;

namespace Web_Client.Pages
{
    /// <summary>
    /// Model for the Planned Meals Page.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class PlannedMealsModel : PageModel
    {
        public PlannedMealsViewModel ViewModel { get; set; }

        public PlannedMealsModel()
        {
            this.ViewModel= new PlannedMealsViewModel();
            this.ViewModel.Initialize();
        }

        /// <summary>
        /// Called when [get].
        /// </summary>
        public void OnGet()
        {
        }
    }
}
