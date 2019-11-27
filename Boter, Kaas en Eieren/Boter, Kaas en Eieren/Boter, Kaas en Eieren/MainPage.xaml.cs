using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;


namespace Boter__Kaas_en_Eieren
{

    public sealed partial class MainPage : Page
    {
        BKE bke = new BKE();
        BitmapImage plaatjes = new BitmapImage(new Uri("ms-appx:///Assets/heelmooi.jpg"));
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void vak_click(object sender, RoutedEventArgs e)
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
                bke.score = bke.score + 3;
                PlaatjesResetten();
            }
            else
            {
                // Controle voor gelijk spel.
                if (bke.countTurnsSpeler != 5)
                {
                    ZetStapAI();

                    if (bke.WinCheck()) 
                    {
                        // AI wint.
                        bke.score = bke.score - 1;
                        PlaatjesResetten();
                    }
                }
                else
                {
                    // Gelijkspel.
                    PlaatjesResetten(); 
                }
            }

            bke.countTurnsSpeler = 0;
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
