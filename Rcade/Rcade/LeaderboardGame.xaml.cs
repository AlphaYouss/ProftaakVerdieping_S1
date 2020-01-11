﻿using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rcade
{
    public sealed partial class LeaderbordGame : Page
    {
        List<string> Games = new List<string> { "Leaderboard", "Blackjack", "Roulette", "Galgje", "Boter kaas en eieren", "Ganzenbord", "Vier op een rij" };
        Databasehandler_lb dbh = new Databasehandler_lb(true);

        public LeaderbordGame(int Number)
        {
            InitializeComponent();

            dbh.ChangeChoice(Number);
            dbh.ChoiceMaker();

            UpdateText();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(
                new Size(
                1000,
                1000)
            );
        }

        private void ClearText()
        {
            Column1Text.Text = "";
            Column2Text.Text = "";
            Column3Text.Text = "";
            Column4Text.Text = "";
            Column5Text.Text = "";
        }

        private void UpdateText()
        {
            GameName.Text = Games[dbh.Choice];

            ClearText();
            ButtonOnOff();

            Column1Text.Text = dbh.Table1Name;
            ListToListview(Column1, dbh.Usernames);

            Column2Text.Text = dbh.Table2Name;
            ListToListview(Column2, dbh.Table2);

            Column3Text.Text = dbh.Table3Name;
            ListToListview(Column3, dbh.Table3);

            Column4Text.Text = dbh.Table4Name;
            ListToListview(Colomn4, dbh.Table4);

            Column5Text.Text = dbh.Table5Name;
            ListToListview(Colomn5, dbh.Table5);
        }

        private void ListToListview(ListView listView, List<string> list)
        {
            listView.Items.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                listView.Items.Add(list[i]);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            int TestChoice = dbh.Choice - 1;

            if (TestChoice >= 1)
            {
                dbh.ChangeChoice(TestChoice);
                dbh.ChoiceMaker();
            }

            if (dbh.Choice == 1)
            {
                BackButton.IsEnabled = false;
            }
            else
            {
                BackButton.IsEnabled = true;
            }

            UpdateText();
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            int TestChoice = dbh.Choice + 1;

            if (TestChoice <= 5)
            {
                dbh.ChangeChoice(TestChoice);
                dbh.ChoiceMaker();
            }

            if (dbh.Choice == 5)
            {
                ForwardButton.IsEnabled = false;
            }
            else
            {
                ForwardButton.IsEnabled = true;
            }

            UpdateText();
        }
        private void ButtonOnOff()
        {
            if (dbh.Choice == 5)
            {
                ForwardButton.IsEnabled = false;
            }
            else
            {
                ForwardButton.IsEnabled = true;
            }

            if (dbh.Choice == 1)
            {
                BackButton.IsEnabled = false;
            }
            else
            {
                BackButton.IsEnabled = true;
            }
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            LeaderboardPage lp = new LeaderboardPage();
            Content = lp;
        }
    }
}