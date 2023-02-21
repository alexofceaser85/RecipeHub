using Microsoft.AspNetCore.Mvc;

namespace Web_Client.Model.Filters
{
    public class FiltersBindingModel
    {
        [BindProperty]
        public string FiltersTypes { get; set; }
    }
}
