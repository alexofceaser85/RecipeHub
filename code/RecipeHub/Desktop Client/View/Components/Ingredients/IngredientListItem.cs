using Shared_Resources.Model.Ingredients;
using Shared_Resources.Utils.Units;

namespace Desktop_Client.View.Components.Ingredients
{
    /// <summary>
    /// An item to display on a list of ingredients
    /// </summary>
    public partial class IngredientListItem : UserControl
    {
        /// <summary>
        /// The ingredient to display.
        /// </summary>
        public Ingredient Ingredient { get; set; }

        /// <summary>
        /// Creates an instance of <see cref="IngredientListItem"/> with a specified <see cref="Ingredient"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None
        /// <b>Postcondition: </b>this.Ingredient == ingredient<br/>
        /// &amp;&amp; ingredient's information is displayed on the IngredientListItem.
        /// </summary>
        /// <param name="ingredient">The ingredient to display.</param>
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
    }
}
