using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;


namespace Boter__Kaas_en_Eieren
{

    public sealed partial class MainPage : Page
    {
        BKE bke = new BKE();
        BitmapImage plaatjes = new BitmapImage(new Uri("ms-appx:///"));

        public MainPage()
        {
            InitializeComponent();
            SetUp();
        }

        private void SetUp()
        {
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(1920, 1080));

            txtnaamAI.Text = bke.naamAI;
            txtnaamSpeler.Text = bke.naamSpeler;

            btnBack.FontFamily = new FontFamily("/Assets/Fonts/SFAlienEncounters.ttf#SF Alien Encounters");
            btnRestart.FontFamily = new FontFamily("/Assets/Fonts/SFAlienEncounters.ttf#SF Alien Encounters");

            txtnaamSpeler.FontFamily = new FontFamily("/Assets/Fonts/SFAlienEncounters-Italic.ttf#SF Alien Encounters");
            txtnaamAI.FontFamily = new FontFamily("/Assets/Fonts/SFAlienEncounters-Italic.ttf#SF Alien Encounters");
            txtscoreAI.FontFamily = new FontFamily("/Assets/Fonts/SFAlienEncounters-Italic.ttf#SF Alien Encounters");
            txtscoreSpeler.FontFamily = new FontFamily("/Assets/Fonts/SFAlienEncounters-Italic.ttf#SF Alien Encounters");
        }

        private async void vak_click(object sender, RoutedEventArgs e)
        {
            // Krijg geklikte vaknaam.
            string ctrlName = ((Control)sender).Name;
            string[] words = ctrlName.Split("vak");

            // Converteer de vaknaam naar een getal.
            int vak = Convert.ToInt32(words[1]);

            ZetStapSpeler(vak);

            // Haalt op hoeveel stappen de speler heeft gezet.
            foreach (string box in bke.imageBoxen)
            {
                if (box == "X")
                {
                    bke.countTurnsSpeler++;
                }
            }

            if (bke.WinCheck())
            {
                // Speler wint.
                //btnNext.Content = "Gewonnen!";

                bke.scoreSpeler = bke.scoreSpeler + 3;
                txtnaamSpeler.Foreground = new SolidColorBrush(Colors.Green);
                bke.scoreAI = bke.scoreAI - 1;
                txtnaamAI.Foreground = new SolidColorBrush(Colors.Red);

                NextGameShow();
            }
            else
            {
                // Controle voor gelijk spel.
                if (bke.countTurnsSpeler != 5)
                {
                    await DelayAsync();

                    ZetStapAI();

                    if (bke.WinCheck())
                    {
                        // AI wint.
                        //btnNext.Content = "Verloren!";

                        bke.scoreSpeler = bke.scoreSpeler - 1;
                        txtnaamSpeler.Foreground = new SolidColorBrush(Colors.Red);
                        bke.scoreAI = bke.scoreAI + 3;
                        txtnaamAI.Foreground = new SolidColorBrush(Colors.Green);

                        NextGameShow();
                    }
                }
                else
                {
                    // Gelijkspel.
                    //btnNext.Content = "Gelijkspel!";

                    txtnaamSpeler.Foreground = new SolidColorBrush(Colors.Orange);
                    txtnaamAI.Foreground = new SolidColorBrush(Colors.Orange);

                    NextGameShow();
                }
            }
            bke.countTurnsSpeler = 0;
        }

        private async Task DelayAsync()
        {
            Task.Delay(TimeSpan.FromSeconds(0.5)).Wait();
        }

        private void NextGameShow()
        {
            btnRestart.Visibility = Visibility.Visible;

            if (bke.scoreSpeler < 0)
            {
                bke.scoreSpeler = 0;
            }

            if (bke.scoreAI < 0)
            {
                bke.scoreAI = 0;
            }

            txtscoreSpeler.Text = bke.scoreSpeler.ToString();
            txtscoreAI.Text = bke.scoreAI.ToString();

            vak1.IsEnabled = false;
            vak2.IsEnabled = false;
            vak3.IsEnabled = false;
            vak4.IsEnabled = false;
            vak5.IsEnabled = false;
            vak6.IsEnabled = false;
            vak7.IsEnabled = false;
            vak8.IsEnabled = false;
            vak9.IsEnabled = false;
        }

        private void ZetStapSpeler(int vak)
        {
            bke.ZetStapSpeler(vak);

            switch (vak)
            {
                default:
                    break;
                case 1:
                    image.Source = bke.plaatjeSpeler;
                    vak1.IsEnabled = false;
                    break;
                case 2:
                    image2.Source = bke.plaatjeSpeler;
                    vak2.IsEnabled = false;
                    break;
                case 3:
                    image3.Source = bke.plaatjeSpeler;
                    vak3.IsEnabled = false;
                    break;
                case 4:
                    image4.Source = bke.plaatjeSpeler;
                    vak4.IsEnabled = false;
                    break;
                case 5:
                    image5.Source = bke.plaatjeSpeler;
                    vak5.IsEnabled = false;
                    break;
                case 6:
                    image6.Source = bke.plaatjeSpeler;
                    vak6.IsEnabled = false;
                    break;
                case 7:
                    image7.Source = bke.plaatjeSpeler;
                    vak7.IsEnabled = false;
                    break;
                case 8:
                    image8.Source = bke.plaatjeSpeler;
                    vak8.IsEnabled = false;
                    break;
                case 9:
                    image9.Source = bke.plaatjeSpeler;
                    vak9.IsEnabled = false;
                    break;
            }
        }

        private void ZetStapAI()
        {
            bke.ZetStapAI();

            switch (bke.stapAI)
            {
                default:
                    break;
                case 1:
                    image.Source = bke.plaatjeAI;
                    vak1.IsEnabled = false;
                    break;
                case 2:
                    image2.Source = bke.plaatjeAI;
                    vak2.IsEnabled = false;
                    break;
                case 3:
                    image3.Source = bke.plaatjeAI;
                    vak3.IsEnabled = false;
                    break;
                case 4:
                    image4.Source = bke.plaatjeAI;
                    vak4.IsEnabled = false;
                    break;
                case 5:
                    image5.Source = bke.plaatjeAI;
                    vak5.IsEnabled = false;
                    break;
                case 6:
                    image6.Source = bke.plaatjeAI;
                    vak6.IsEnabled = false;
                    break;
                case 7:
                    image7.Source = bke.plaatjeAI;
                    vak7.IsEnabled = false;
                    break;
                case 8:
                    image8.Source = bke.plaatjeAI;
                    vak8.IsEnabled = false;
                    break;
                case 9:
                    image9.Source = bke.plaatjeAI;
                    vak9.IsEnabled = false;
                    break;
            }
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            PlaatjesResetten();

            txtnaamAI.Foreground = new SolidColorBrush(Colors.White);
            txtnaamSpeler.Foreground = new SolidColorBrush(Colors.White);

            btnRestart.Visibility = Visibility.Collapsed;
        }

        private void PlaatjesResetten()
        {
            bke.ClearVeld();

            for (int i = 1; i < 10; i++)
            {
                switch (i)
                {
                    default:
                        break;
                    case 1:
                        image.Source = plaatjes;
                        vak1.IsEnabled = true;
                        break;
                    case 2:
                        image2.Source = plaatjes;
                        vak2.IsEnabled = true;
                        break;
                    case 3:
                        image3.Source = plaatjes;
                        vak3.IsEnabled = true;
                        break;
                    case 4:
                        image4.Source = plaatjes;
                        vak4.IsEnabled = true;
                        break;
                    case 5:
                        image5.Source = plaatjes;
                        vak5.IsEnabled = true;
                        break;
                    case 6:
                        image6.Source = plaatjes;
                        vak6.IsEnabled = true;
                        break;
                    case 7:
                        image7.Source = plaatjes;
                        vak7.IsEnabled = true;
                        break;
                    case 8:
                        image8.Source = plaatjes;
                        vak8.IsEnabled = true;
                        break;
                    case 9:
                        image9.Source = plaatjes;
                        vak9.IsEnabled = true;
                        break;
                }
            }
        }
    }
}
