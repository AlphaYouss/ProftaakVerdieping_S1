﻿using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Rcade
{
    public sealed partial class TTTPage : Page
    {
        private User user { get; set; }
        private TTT ttt { get; set; }
        private TTT_Field field { get; set; }
        private TTT_Player player { get; set; }
        private TTT_Ai ai { get; set; }
        private BitmapImage defaultImage { get; set; } = new BitmapImage(new Uri("ms-appx:///Assets/Afbeeldingen/BKE/Transparent.png"));

        public TTTPage()
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
            HubPage hub = new HubPage();
            hub.SetUser(user);

            Content = hub;
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            btnRestart.Visibility = Visibility.Collapsed;

            for (int i = 1; i < 10; i++)
            {
                ChangeField(i, defaultImage, true, true);
            }

            field.ClearField();

            vak1.Click += vak_Click;
            vak2.Click += vak_Click;
            vak3.Click += vak_Click;
            vak4.Click += vak_Click;
            vak5.Click += vak_Click;
            vak6.Click += vak_Click;
            vak7.Click += vak_Click;
            vak8.Click += vak_Click;
            vak9.Click += vak_Click;

            txtNameAI.Foreground = new SolidColorBrush(Colors.White);
            txtNamePlayer.Foreground = new SolidColorBrush(Colors.White);
        }

        private void vak_Click(object sender, RoutedEventArgs e)
        {
            string ctrlName = ((Control)sender).Name;
            string[] button= ctrlName.Split("vak");

            int clickedBox = Convert.ToInt32(button[1]);

            btnBack.Visibility = Visibility.Collapsed;

            player.TakesTurn(clickedBox);
            ChangeField(clickedBox, player.imagePlayer, false, true);

            int remainingBoxes = ttt.CheckField();

            if (ttt.CheckWin())
            {
                // Player wins.

                player.SetScorePlayer(3);
                ai.SetScoreAi(-1);

                txtNamePlayer.Foreground = new SolidColorBrush(Colors.Green);
                txtNameAI.Foreground = new SolidColorBrush(Colors.Red);

                NextGame();
            }
            else if (remainingBoxes != 0)
            {
                ai.TakesTurn();
                ChangeField(ai.moveAi, ai.imageAi, false, true);

                if (ttt.CheckWin())
                {
                    // AI wins.   

                    player.SetScorePlayer(-1);
                    ai.SetScoreAi(3);

                    txtNamePlayer.Foreground = new SolidColorBrush(Colors.Red);
                    txtNameAI.Foreground = new SolidColorBrush(Colors.Green);

                    NextGame();
                }
            }
            else
            {
                // Draw.

                txtNamePlayer.Foreground = new SolidColorBrush(Colors.Orange);
                txtNameAI.Foreground = new SolidColorBrush(Colors.Orange);

                NextGame();
            }
        }

        internal void SetUp()
        {
            field = new TTT_Field();
            field.GenerateField();

            player = new TTT_Player(field);
            ai = new TTT_Ai(field);
            ttt = new TTT(field);

            txtNameAI.Text = ai.nameAi;
            txtNamePlayer.Text = user.userName;
        }

        private void NextGame()
        {
            btnBack.Visibility = Visibility.Visible;
            btnRestart.Visibility = Visibility.Visible;

            player.SetScorePlayer();
            ai.SetScoreAi();

            txtScorePlayer.Text = player.scorePlayer.ToString();
            txtScoreAI.Text = ai.scoreAi.ToString();

            for (int i = 1; i < 10; i++)
            {
                ChangeField(i, defaultImage, false, false);
            }
        }

        private void ChangeField(int box, BitmapImage imageSource, bool enabled, bool reset)
        {
            switch (box)
            {
                default:
                    break;
                case 1:
                    if (reset == true)
                    {
                        image.Source = imageSource;
                    }

                    vak1.Click -= vak_Click;
                    break;
                case 2:
                    if (reset == true)
                    {
                        image2.Source = imageSource;
                    }

                    vak2.Click -= vak_Click;
                    break;
                case 3:
                    if (reset == true)
                    {
                        image3.Source = imageSource;
                    }

                    vak3.Click -= vak_Click;
                    break;
                case 4:
                    if (reset == true)
                    {
                        image4.Source = imageSource;
                    }

                    vak4.Click -= vak_Click;
                    break;
                case 5:
                    if (reset == true)
                    {
                        image5.Source = imageSource;
                    }

                    vak5.Click -= vak_Click;
                    break;
                case 6:
                    if (reset == true)
                    {
                        image6.Source = imageSource;
                    }

                    vak6.Click -= vak_Click;
                    break;
                case 7:
                    if (reset == true)
                    {
                        image7.Source = imageSource;
                    }

                    vak7.Click -= vak_Click;
                    break;
                case 8:
                    if (reset == true)
                    {
                        image8.Source = imageSource;
                    }

                    vak8.Click -= vak_Click;
                    break;
                case 9:
                    if (reset == true)
                    {
                        image9.Source = imageSource;
                    }

                    vak9.Click -= vak_Click;
                    break;
            }
        }

        internal void SetUser(User user)
        {
            this.user = user;
        }
    }
}