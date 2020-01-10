using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

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
                1000 )
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
