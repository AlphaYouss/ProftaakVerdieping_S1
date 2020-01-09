using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Rcade
{
    public sealed partial class MainPage : Page
    {
        private User user { get; set; } = new User();

        public MainPage()
        {
            InitializeComponent();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(
            new Size(
                1000, 
                1000 
                ));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void password_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Login();
            }
        }

        private void Login()
        {
            bool errorUsername = false;
            bool errorPassword = false;

            if (user.ValidateUsername(username.Text) == false)
            {
                errorUsername = true;
            }
            if (user.ValidatePassword(password.Password) == false)
            {
                errorPassword = true;
            }

            if (errorUsername == true && errorPassword == true)
            {
                message.Text = user.ShowError("Login", 2);
            }
            else if (errorUsername == true)
            {
                message.Text = user.ShowError("Login", 0);
            }
            else if (errorPassword == true)
            {
                message.Text = user.ShowError("Login", 1);
            }
            else
            {
                if (user.CanConnectToDatabase() == false)
                {
                    message.Text = user.ShowError("Database", 0);
                }
                else
                {
                    user.CheckIfUserExists(username.Text);

                    if (user.exists == true)
                    {
                        user.Login(username.Text, password.Password);
                        if (user.loggedIn == true)
                        {
                            HubPage hub = new HubPage();
                            hub.SetUser(user);

                            Content = hub;
                        }
                        else
                        {
                            message.Text = user.ShowError("Account", 1);
                        }
                    }
                    else
                    {
                        message.Text = user.ShowError("Account", 0);
                    }
                }
            }
        }
    }
}