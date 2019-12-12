using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rcade
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            DefaultLaunch();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            Content = loginPage;
        }

        async void DefaultLaunch()
        {
            string uriToLaunch = @"http://rcade.azurewebsites.net/register.php";
            Uri uri = new Uri(uriToLaunch);

            bool success = await Windows.System.Launcher.LaunchUriAsync(uri);
            if (!success)
            {
                Status.Text = "Maak hier een account aan: rcade.azurewebsites.net";
            }
        }
    }
}
