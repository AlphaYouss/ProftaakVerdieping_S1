using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LeaderboardPage : Page
    {
        public LeaderboardPage()
        {
            this.InitializeComponent();
        }


        public int Number { get; private set; } = 0;

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
    }
}
