using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Rcade
{
    public sealed partial class BKEPage : Page
    {
        public BitmapImage transparentImage { get; private set; } = new BitmapImage(new Uri("ms-appx:///Assets/Afbeeldingen/BKE/Transparent.png"));
        private User user { get; set; }

        BKE bke;
        BKE_Veld field;
        BKE_Speler player;
        BKE_Ai ai;

        public BKEPage()
        {
            InitializeComponent();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(
            new Size(
                1000,
                1000 
                ));

            SetUp();
        }

        internal void SetUser(User user)
        {
            this.user = user;
        }

        private void SetUp()
        {
            field = new BKE_Veld();
            field.VeldGenereren();

            player = new BKE_Speler(field);
            ai = new BKE_Ai(field);
            bke = new BKE(field);

            txtnaamAI.Text = ai.naamAI;
            txtnaamSpeler.Text = player.naamSpeler;

            txtnaamSpeler.Foreground = new SolidColorBrush(Colors.White);
            txtnaamAI.Foreground = new SolidColorBrush(Colors.White);
            txtscoreSpeler.Foreground = new SolidColorBrush(Colors.White);
            txtscoreAI.Foreground = new SolidColorBrush(Colors.White);
        }

        private void vak_click(object sender, RoutedEventArgs e)
        {
            string ctrlName = ((Control)sender).Name;
            string[] words = ctrlName.Split("vak");

            int vak = Convert.ToInt32(words[1]);

            player.ZetStapSpeler(vak);
            VeranderVeld(vak, player.plaatjeSpeler, false, true);

            int beschikbarevakken = bke.CheckVak();

            if (bke.WinCheck())
            {
                // Speler wint.

                player.SetScoreSpeler(3);
                ai.SetScoreAI(-1);

                txtnaamSpeler.Foreground = new SolidColorBrush(Colors.Green);
                txtnaamAI.Foreground = new SolidColorBrush(Colors.Red);

                NextGameShow();
            }
            else if (beschikbarevakken != 0)
            {
                //Delay();

                ai.ZetStapAI();
                VeranderVeld(ai.stapAI, ai.plaatjeAI, false, true);

                if (bke.WinCheck())
                {
                    // AI wint.   

                    player.SetScoreSpeler(-1);
                    ai.SetScoreAI(3);

                    txtnaamSpeler.Foreground = new SolidColorBrush(Colors.Red);
                    txtnaamAI.Foreground = new SolidColorBrush(Colors.Green);

                    NextGameShow();
                }
            }
            else
            {
                // Gelijkspel.

                txtnaamSpeler.Foreground = new SolidColorBrush(Colors.Orange);
                txtnaamAI.Foreground = new SolidColorBrush(Colors.Orange);

                NextGameShow();
            }
        }

        //private void Delay()
        //{
        //    Task.Delay(TimeSpan.FromSeconds(0.5)).Wait();
        //}

        private void NextGameShow()
        {
            btnRestart.Visibility = Visibility.Visible;

            player.SetScoreSpelerZero();
            ai.SetScoreAIZero();

            txtscoreSpeler.Text = player.scoreSpeler.ToString();
            txtscoreAI.Text = ai.scoreAI.ToString();

            for (int i = 1; i < 10; i++)
            {
                VeranderVeld(i, transparentImage, false, false);
            }
        }

        private void VeranderVeld(int vak, BitmapImage imageSource, bool enabled, bool reset)
        {
            switch (vak)
            {
                default:
                    break;
                case 1:
                    if (reset == true)
                    {
                        image.Source = imageSource;
                    }

                    vak1.Click -= vak_click;
                    //vak1.IsEnabled = enabled;
                    break;
                case 2:
                    if (reset == true)
                    {
                        image2.Source = imageSource;
                    }

                    vak2.Click -= vak_click;
                    //vak2.IsEnabled = enabled;
                    break;
                case 3:
                    if (reset == true)
                    {
                        image3.Source = imageSource;
                    }

                    vak3.Click -= vak_click;
                    //vak3.IsEnabled = enabled;
                    break;
                case 4:
                    if (reset == true)
                    {
                        image4.Source = imageSource;
                    }

                    vak4.Click -= vak_click;
                    //vak4.IsEnabled = enabled;
                    break;
                case 5:
                    if (reset == true)
                    {
                        image5.Source = imageSource;
                    }

                    vak5.Click -= vak_click;
                    //vak5.IsEnabled = enabled;
                    break;
                case 6:
                    if (reset == true)
                    {
                        image6.Source = imageSource;
                    }

                    vak6.Click -= vak_click;
                    //vak6.IsEnabled = enabled;
                    break;
                case 7:
                    if (reset == true)
                    {
                        image7.Source = imageSource;
                    }

                    vak7.Click -= vak_click;
                    //vak7.IsEnabled = enabled;
                    break;
                case 8:
                    if (reset == true)
                    {
                        image8.Source = imageSource;
                    }

                    vak8.Click -= vak_click;
                    //vak8.IsEnabled = enabled;
                    break;
                case 9:
                    if (reset == true)
                    {
                        image9.Source = imageSource;
                    }

                    vak9.Click -= vak_click;
                    //vak9.IsEnabled = enabled;
                    break;
            }
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            btnRestart.Visibility = Visibility.Collapsed;

            for (int i = 1; i < 10; i++)
            {
                VeranderVeld(i, transparentImage, true, true);
            }

            field.ClearVeld();

            vak1.Click += vak_click;
            vak2.Click += vak_click;
            vak3.Click += vak_click;
            vak4.Click += vak_click;
            vak5.Click += vak_click;
            vak6.Click += vak_click;
            vak7.Click += vak_click;
            vak8.Click += vak_click;
            vak9.Click += vak_click;

            txtnaamAI.Foreground = new SolidColorBrush(Colors.White);
            txtnaamSpeler.Foreground = new SolidColorBrush(Colors.White);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage();
            Content = hub;
        }
    }
}