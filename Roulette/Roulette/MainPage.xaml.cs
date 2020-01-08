using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Roulette
{
    public sealed partial class MainPage : Page
    {
        private RL roulette { get; set; } = new RL();
        private int stake { get; set; } = Convert.ToInt32(RL.chips.Fifty);
        private int totalBet { get; set; } = 0;
        private int maxBet { get; set; } = 1000;

        public MainPage()
        {
            InitializeComponent();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(
            new Size(
                1000,
                1000
                ));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnBet_Click(object sender, RoutedEventArgs e)
        {
            if (CanBet() == true)
            {
                if (AllowedToBet() == true)
                {
                    string ctrlName = ((Control)sender).Name;
                    int type = 0;

                    switch (ctrlName)
                    {
                        case "btnFirstTwelve":
                        case "btnSecondTwelve":
                        case "btnThirdTwelve":
                            type = 1;
                            break;
                        case "btnFirstRow":
                        case "btnSecondRow":
                        case "btnThirdRow":
                            type = 2;
                            break;
                        case "btnFirstEighteen":
                        case "btnLastEighteen":
                            type = 3;
                            break;
                        case "btnEven":
                        case "btnOdd":
                            type = 4;
                            break;
                        case "btnRed":
                        case "btnBlack":
                            type = 5;
                            break;
                    }
                    roulette.PlaceBet(ctrlName, type, stake);

                    UpdateResult("Bet placed!");
                    balance.Text = roulette.player.balance.ToString();

                    ListBoxItem listBoxItem = new ListBoxItem();
                    listBoxItem.Content = stake + " bet on " + roulette.player.placedbet;

                    betList.Items.Add(listBoxItem);
                }
                else
                {
                    UpdateResult("Max bet is 1000!");
                }
            }
            else
            {
                UpdateResult("Your balance is too low!");
            }
        }

        private void btnChip_Click(object sender, RoutedEventArgs e)
        {
            string ctrlName = ((Control)sender).Name;
            RL.chips currentChip = RL.chips.Fifty;

            switch (ctrlName)
            {
                case "btnFifty":
                    stake = Convert.ToInt32(RL.chips.Fifty);
                    currentChip = RL.chips.Fifty;
                    break;
                case "btnOnehundred":
                    stake = Convert.ToInt32(RL.chips.OneHundred);
                    currentChip = RL.chips.OneHundred;
                    break;
                case "btnTwohundred":
                    stake = Convert.ToInt32(RL.chips.TwoHundred);
                    currentChip = RL.chips.TwoHundred;
                    break;
                case "btnFivehundred":
                    stake = Convert.ToInt32(RL.chips.FiveHundred);
                    currentChip = RL.chips.FiveHundred;
                    break;
            }

            UpdateCurrentChip(currentChip);
        }

        private void btnResetStake_Click(object sender, RoutedEventArgs e)
        {
            int betMoney = 0;

            foreach (var bet in roulette.player.bet)
            {
                betMoney = betMoney + bet.Value;
            }

            roulette.player.CancelBet(betMoney);

            UpdateResult("Bets resetted!");
            balance.Text = roulette.player.balance.ToString();

            betList.Items.Clear();
            totalBet = 0;
        }

        private void btnSpin_Click(object sender, RoutedEventArgs e)
        {
            roulette.SpinWheel();
        }

        private bool CanBet()
        {
            if (roulette.player.balance - stake > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool AllowedToBet()
        {
            if (totalBet + stake > maxBet)
            {
                return false;
            }
            else
            {
                totalBet = totalBet + stake;
                return true;
            }
        }

        private void UpdateCurrentChip(RL.chips chip)
        {
            string location = "";

            switch (chip)
            {
                case RL.chips.Fifty:
                    location = "ms-appx:///Assets/Fiche50.png";
                    break;
                case RL.chips.OneHundred:
                    location = "ms-appx:///Assets/Fiche100.png";
                    break;
                case RL.chips.TwoHundred:
                    location = "ms-appx:///Assets/Fiche200.png";
                    break;
                case RL.chips.FiveHundred:
                    location = "ms-appx:///Assets/Fiche500.png";
                    break;
            }
            BitmapImage chipSource = new BitmapImage(new Uri(location));
            currentChip.Source = chipSource;
        }

        public async void UpdateResult(string message)
        {
            result.Text = message;
            await Task.Delay(2000);
            result.Text = "";
        }
    }
}