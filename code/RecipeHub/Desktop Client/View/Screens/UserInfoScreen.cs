using Desktop_Client.ViewModel.Users;
using Shared_Resources.Data.UserData;

namespace Desktop_Client.View.Screens
{
    public partial class UserInfoScreen : Form
    {
        private readonly string sessionMessage = $"Session Key {Session.Key}";

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoScreen"/> class.
        /// </summary>
        public UserInfoScreen()
        {
            this.InitializeComponent();
            this.getAndPopulateUserInfo();
        }

        private void getAndPopulateUserInfo()
        {
            var userInfo = UsersViewModel.GetUserInfo();

            this.usernameTextBox.Text = userInfo.UserName;
            this.firstNameTextBox.Text = userInfo.FirstName;
            this.lastNameTextBox.Text = userInfo.LastName;
            this.emailTextBox.Text = userInfo.Email;
            this.sessionKeyInfoLabel.Text = this.sessionMessage;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            UsersViewModel.Logout();
            Close();
        }
    }
}
