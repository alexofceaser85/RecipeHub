using Shared_Resources.Model.Ingredients;
using Shared_Resources.Utils.Units;

namespace Desktop_Client.View.Components.Ingredients
{
    /// <summary>
    /// An item to display on a list of ingredients
    /// </summary>
    public partial class IngredientListItem : UserControl
    {
        public Ingredient Ingredient { get; set; }

        public IngredientListItem(Ingredient ingredient)
        {
            this.InitializeComponent();

            this.ingrediantNameLabel.Text = ingredient.Name;
            this.quantityLabel.Text = @$"Quantity: {ingredient.Amount} {BaseUnitUtils.GetBaseUnitSign(ingredient.MeasurementType)}";
            this.Ingredient = ingredient;
        }

        /// <summary>
        /// Occurs when the edit button is pressed
        /// </summary>
        public EventHandler<Ingredient>? EditSelected;

        /// <summary>
        /// Occurs when the remove button is pressed
        /// </summary>
        public EventHandler<Ingredient>? RemoveSelected;

        private void editButton_Click(object sender, EventArgs e)
        {
            this.EditSelected?.Invoke(this, this.Ingredient);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            this.RemoveSelected?.Invoke(this, this.Ingredient);
        }

        private void ingrediantNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
