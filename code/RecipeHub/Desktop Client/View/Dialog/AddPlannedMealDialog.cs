using Microsoft.VisualBasic;
using Shared_Resources.Data.Settings;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Utils.Dates;

namespace Desktop_Client.View.Dialog
{
    /// <summary>
    /// Prompts the user to add a recipe to their list of planned meals.
    /// </summary>
    public partial class AddPlannedMealDialog : MobileDialog
    {
        /// <summary>
        /// The selected date from the drop down list
        /// </summary>
        public DateTime SelectedDate => (DateTime)this.dateComboBox.SelectedItem;

        /// <summary>
        /// The selected category from the drop down list
        /// </summary>
        public MealCategory SelectedCategory => (MealCategory)this.categoryComboBox.SelectedItem;

        /// <summary>
        /// Creates a default instance of <see cref="AddPlannedMealDialog"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public AddPlannedMealDialog()
        {
            this.InitializeComponent();

            var startDate = DateTime.Now.Date;

            this.categoryComboBox.DataSource = Enum.GetValues(typeof(MealCategory));
            this.dateComboBox.DataSource = DateUtils.GenerateDateTimesFromWeekToNextWeek(startDate)
                                                    .Where(date => date.Date >= startDate).ToArray();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void dateComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            var date = (DateTime)e.ListItem!;
            e.Value = $@"{date.DayOfWeek} {date.ToShortDateString()}";
        }
    }
}
