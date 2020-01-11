using System;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rcade
{
    public sealed partial class MainPage : Page
    {
        private User user { get; set; } = new User();
        private string uriToLaunch { get; set; } = @"http://rcade.azurewebsites.net/register.php";

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
                if (user.dbh.TestConnection() == false)
                {
                    message.Text = user.ShowError("Database", 0);
                }
                else
                {
                    user.CheckUser(username.Text);

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

        private void website_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Uri uri = new Uri(uriToLaunch);
            LaunchWebsite(uri);
        }

        async void LaunchWebsite(Uri uri)
        {
            bool success = await Windows.System.Launcher.LaunchUriAsync(uri);

            if (!success)
            {
                message.Text = user.ShowError("Webbrowser", 0);
            }
        }
    }
}