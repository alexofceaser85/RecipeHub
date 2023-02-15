using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Client.Model
{
    public struct RecipeFilters
    {
        public bool OnlyAvailableIngredients { get; set; }

        public RecipeFilters()
        {
            this.OnlyAvailableIngredients = false;
        }
    }
}
