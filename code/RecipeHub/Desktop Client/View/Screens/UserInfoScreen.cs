using Desktop_Client.ViewModel.Users;
using Shared_Resources.Data.UserData;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// Displays the active user's information.
    /// </summary>
    public partial class UserInfoScreen : Screen
    {
        private readonly string sessionMessage = $"Session Key {Session.Key}";
        private readonly UsersViewModel viewModel;

        /// <summary>
        /// Creates a default instance of <see cref="UserInfoScreen"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public UserInfoScreen()
        {
            this.InitializeComponent();
            this.viewModel = new UsersViewModel();
            this.GetAndPopulateUserInfo();
        }

        private void GetAndPopulateUserInfo()
        {
            var userInfo = this.viewModel.GetUserInfo();

            this.usernameTextBox.Text = userInfo.UserName;
            this.firstNameTextBox.Text = userInfo.FirstName;
            this.lastNameTextBox.Text = userInfo.LastName;
            this.emailTextBox.Text = userInfo.Email;
            this.sessionKeyInfoLabel.Text = this.sessionMessage;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.viewModel.Logout();
            ChangeScreens(new LoginScreen());
        }
    }
}