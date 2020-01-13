using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Rcade
{
    public sealed partial class LeaderbordGamePage : Page
    {
        private Databasehandler_lb dbh { get; set; } = new Databasehandler_lb(true);
        private User user { get; set; }
        private List<string> Games { get; set; } = new List<string> { "Leaderboard", "Blackjack", "Roulette", "Hangman", "Tic, Tac and Toe", "Gooseboard", "Four in a row" };

        int AmountOfGames = 4;




        public LeaderbordGamePage(int Number)
        {
            InitializeComponent();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(
            new Size(
            1000,
            1000)
            );

            dbh.ChangeChoice(Number);
            dbh.ChoiceMaker();

            UpdateText();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            LeaderboardPage lp = new LeaderboardPage();
            lp.SetUser(user);

            Content = lp;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            int choice = dbh.choice - 1;

            if (choice >= 1)
            {
                dbh.ChangeChoice(choice);
                dbh.ChoiceMaker();
            }
            ButtonOnOff();
            UpdateText();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            int choice = dbh.choice + 1;

            if (choice <= AmountOfGames)
            {
                dbh.ChangeChoice(choice);
                dbh.ChoiceMaker();
                
            }

            ButtonOnOff();
            UpdateText();
        }

        private void UpdateText()
        {
            gameName.Text = Games[dbh.choice];

            ClearText();
            ButtonOnOff();

            column1Text.Text = dbh.table1Name;

            column1.FontFamily = new FontFamily("Consolas");
            column2.FontFamily = new FontFamily("Consolas");
            column3.FontFamily = new FontFamily("Consolas");
            column4.FontFamily = new FontFamily("Consolas");
            column5.FontFamily = new FontFamily("Consolas");

            ListToListBoxItem(column1, dbh.usernames);

            column2Text.Text = dbh.table2Name;
            ListToListBoxItem(column2, dbh.table2);

            column3Text.Text = dbh.table3Name;
            ListToListBoxItem(column3, dbh.table3);

            column4Text.Text = dbh.table4Name;
            ListToListBoxItem(column4, dbh.table4);

            column5Text.Text = dbh.table5Name;
            ListToListBoxItem(column5, dbh.table5);
        }

        private void ClearText()
        {
            column1Text.Text = "";
            column2Text.Text = "";
            column3Text.Text = "";
            column4Text.Text = "";
            column5Text.Text = "";
        }

        private void ButtonOnOff()
        {
            btnForward.IsEnabled = true;
            btnBack.IsEnabled = true;

            if (dbh.choice == AmountOfGames)
            {
                btnForward.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnForward.Visibility = Visibility.Visible;
            }

            if (dbh.choice == 1)
            {
                btnBack.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnBack.Visibility = Visibility.Visible;
            }
        }

        private void ListToListBoxItem(ListBox listbox, List<string> list)
        {
            listbox.Items.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = list[i];
                listBoxItem.FontFamily = new FontFamily("Consolas");

                listbox.Items.Add(listBoxItem);
            }
        }

        internal void SetUser(User user)
        {
            this.user = user;
        }
    }
}