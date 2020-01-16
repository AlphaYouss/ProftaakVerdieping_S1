﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rcade
{
    public sealed partial class GBPlayersPage : Page
    {
        private List<TextBox> emptyBoxes { get; set; } = new List<TextBox>();
        private List<TextBox> playerNames { get; set; } = new List<TextBox>();
        private User user { get; set; }
        public int playerCount { get; private set; }

        public GBPlayersPage()
        {
            InitializeComponent();
            playerCount = 2;
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            playerCount++;

            if (playerCount > 5)
            {
                playerCount = 5;
            }
            txtPlayerCount.Text = Convert.ToString(playerCount);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= playerCount; i++)
            {
                switch (i)
                {
                    default:
                        break;
                    case 1:
                        s1.Visibility = Visibility.Visible;
                        break;
                    case 2:
                        Speler2.Visibility = Visibility.Visible;
                        playerNames.Add(Speler2);
                        break;
                    case 3:
                        Speler3.Visibility = Visibility.Visible;
                        playerNames.Add(Speler3);
                        break;
                    case 4:
                        Speler4.Visibility = Visibility.Visible;
                        playerNames.Add(Speler4);
                        break;
                    case 5:
                        Speler5.Visibility = Visibility.Visible;
                        playerNames.Add(Speler5);
                        break;
                }
            }
            btnPlus.IsEnabled = false;
            btnMin.IsEnabled = false;
            btnPlay.Visibility = Visibility.Visible;
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            playerCount--;

            if (playerCount < 2)
            {
                playerCount = 2;
            }
            txtPlayerCount.Text = Convert.ToString(playerCount);
        }

        internal void SetUser(User user)
        {
            this.user = user;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            txtPlayerCount.Text = Convert.ToString(playerCount);

            for (int i = 0; i < playerNames.Count; i++)
            {
                if (string.IsNullOrEmpty(playerNames[i].Text))
                {
                    emptyBoxes.Add(playerNames[i]);
                }
            }

            if (emptyBoxes.Count != 0)
            {
                txtPlayerCount.Text = "Fill in your names first!";
                emptyBoxes.Clear();
            }
            else
            {
                playerCount = Convert.ToInt32(txtPlayerCount.Text);

                GBPage gb = new GBPage(playerCount, Speler2.Text, Speler3.Text, Speler4.Text, Speler5.Text);
                gb.SetUser(user);

                Content = gb;
            }
        }

        private void Speler_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (((Control)sender).Name)
            {
                default:
                    break;
                case "Speler2":
                    if (!ValidateUsername(Speler2.Text) && Speler2.Text.Length != 0)
                    {
                        Speler2.Text = Speler2.Text.Remove(Speler2.Text.Length - 1);

                        Speler2.SelectionStart = Speler2.Text.Length;
                        Speler2.SelectionLength = 0;
                    }
                    break;
                case "Speler3":
                    if (!ValidateUsername(Speler3.Text) && Speler3.Text.Length != 0)
                    {
                        Speler3.Text = Speler3.Text.Remove(Speler3.Text.Length - 1);

                        Speler3.SelectionStart = Speler3.Text.Length;
                        Speler3.SelectionLength = 0;

                    }
                    break;
                case "Speler4":
                    if (!ValidateUsername(Speler4.Text) && Speler4.Text.Length != 0)
                    {
                        Speler4.Text = Speler4.Text.Remove(Speler4.Text.Length - 1);

                        Speler4.SelectionStart = Speler4.Text.Length;
                        Speler4.SelectionLength = 0;
                    }
                    break;
                case "Speler5":
                    if (!ValidateUsername(Speler5.Text) && Speler5.Text.Length != 0)
                    {
                        Speler5.Text = Speler5.Text.Remove(Speler5.Text.Length - 1);

                        Speler5.SelectionStart = Speler5.Text.Length;
                        Speler5.SelectionLength = 0;
                    }
                    break;
            }
        }

        public bool ValidateUsername(string username)
        {
            var regex = @"[a-zA-Z]$";
            var match = Regex.Match(username, regex, RegexOptions.IgnoreCase);

            return match.Success;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage();
            hub.SetUser(user);

            Content = hub;
        }
    }
}