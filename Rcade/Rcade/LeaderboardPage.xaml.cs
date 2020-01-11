using System;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rcade
{
    public sealed partial class LeaderboardPage : Page
    {
        public int Number { get; private set; } = 0;

        public LeaderboardPage()
        {
            this.InitializeComponent();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(
                new Size(
                1000,
                1000)
                );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ButtonName = Convert.ToString(((Control)sender).Name);

            switch (ButtonName)
            {
                case "Blackjack":
                    Number = 1;
                    break;
                case "Roulette":
                    Number = 2;
                    break;
                case "Hangman":
                    Number = 3;
                    break;
                case "BKE":
                    Number = 4;
                    break;
                case "Ganzenbord":
                    Number = 5;
                    break;
            }

            LeaderbordGame ll = new LeaderbordGame(Number);
            Content = ll;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage();
            Content = hub;
        }
    }
}