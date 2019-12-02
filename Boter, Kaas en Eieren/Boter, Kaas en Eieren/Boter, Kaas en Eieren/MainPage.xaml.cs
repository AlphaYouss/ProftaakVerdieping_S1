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
        BKE bke;
        Veld veld;
        Speler speler1;
        AI ai1;
        BitmapImage plaatjes = new BitmapImage(new Uri("ms-appx:///"));

        public MainPage()
        {
            InitializeComponent();
            SetUp();
        }
       
        private void SetUp()
        {
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(1920, 1080));

            veld = new Veld();
            veld.VeldGenereren();

            speler1 = new Speler(veld);
            ai1 = new AI(veld);

            bke = new BKE(veld);

            txtnaamAI.Text = ai1.naamAI;
            txtnaamSpeler.Text = speler1.naamSpeler;

            txtnaamSpeler.Foreground = new SolidColorBrush(Colors.White);
            txtnaamAI.Foreground = new SolidColorBrush(Colors.White);
            txtscoreSpeler.Foreground = new SolidColorBrush(Colors.White);
            txtscoreAI.Foreground = new SolidColorBrush(Colors.White);

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
            speler1.CountTurnsSpeler();
            
            if (bke.WinCheck())
            {
                // Speler wint.

                speler1.SetScoreSpeler(3);
                txtnaamSpeler.Foreground = new SolidColorBrush(Colors.Green);
                ai1.SetScoreAI(-1);
                txtnaamAI.Foreground = new SolidColorBrush(Colors.Red);

                NextGameShow();
            }
            else
            {
                // Controle voor gelijk spel.
                if (speler1.countTurnsSpeler != 5)
                {
                    await DelayAsync();

                    ZetStapAI();

                    if (bke.WinCheck())
                    {
                        // AI wint.   

                        speler1.SetScoreSpeler(-1);
                        txtnaamSpeler.Foreground = new SolidColorBrush(Colors.Red);
                        ai1.SetScoreAI(3);
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
            speler1.SetCountTurnsSpelerZero();
        }

        private async Task DelayAsync()
        {
            Task.Delay(TimeSpan.FromSeconds(0.5)).Wait();
        }

        private void NextGameShow()
        {
            speler1.SetScoreSpelerZero();
            ai1.SetScoreAIZero();

            btnRestart.Visibility = Visibility.Visible;

            txtscoreSpeler.Text = speler1.scoreSpeler.ToString();
            txtscoreAI.Text = ai1.scoreAI.ToString();

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
            speler1.ZetStapSpeler(vak);

            switch (vak)
            {
                default:
                    break;
                case 1:
                    image.Source = speler1.plaatjeSpeler;
                    vak1.IsEnabled = false;
                    break;
                case 2:
                    image2.Source = speler1.plaatjeSpeler;
                    vak2.IsEnabled = false;
                    break;
                case 3:
                    image3.Source = speler1.plaatjeSpeler;
                    vak3.IsEnabled = false;
                    break;
                case 4:
                    image4.Source = speler1.plaatjeSpeler;
                    vak4.IsEnabled = false;
                    break;
                case 5:
                    image5.Source = speler1.plaatjeSpeler;
                    vak5.IsEnabled = false;
                    break;
                case 6:
                    image6.Source = speler1.plaatjeSpeler;
                    vak6.IsEnabled = false;
                    break;
                case 7:
                    image7.Source = speler1.plaatjeSpeler;
                    vak7.IsEnabled = false;
                    break;
                case 8:
                    image8.Source = speler1.plaatjeSpeler;
                    vak8.IsEnabled = false;
                    break;
                case 9:
                    image9.Source = speler1.plaatjeSpeler;
                    vak9.IsEnabled = false;
                    break;
            }
        }

        private void ZetStapAI()
        {
            ai1.ZetStapAI();

            switch (ai1.stapAI)
            {
                default:
                    break;
                case 1:
                    image.Source = ai1.plaatjeAI;
                    vak1.IsEnabled = false;
                    break;
                case 2:
                    image2.Source = ai1.plaatjeAI;
                    vak2.IsEnabled = false;
                    break;
                case 3:
                    image3.Source = ai1.plaatjeAI;
                    vak3.IsEnabled = false;
                    break;
                case 4:
                    image4.Source = ai1.plaatjeAI;
                    vak4.IsEnabled = false;
                    break;
                case 5:
                    image5.Source = ai1.plaatjeAI;
                    vak5.IsEnabled = false;
                    break;
                case 6:
                    image6.Source = ai1.plaatjeAI;
                    vak6.IsEnabled = false;
                    break;
                case 7:
                    image7.Source = ai1.plaatjeAI;
                    vak7.IsEnabled = false;
                    break;
                case 8:
                    image8.Source = ai1.plaatjeAI;
                    vak8.IsEnabled = false;
                    break;
                case 9:
                    image9.Source = ai1.plaatjeAI;
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
            veld.ClearVeld();

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
