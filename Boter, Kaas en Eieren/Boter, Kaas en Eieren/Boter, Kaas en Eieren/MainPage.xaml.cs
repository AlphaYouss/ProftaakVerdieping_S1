using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;


namespace Boter__Kaas_en_Eieren
{

    public sealed partial class MainPage : Page
    {

        BKE bke = new BKE();

        BitmapImage heelmooi = new BitmapImage(new Uri("ms-appx:///Assets/heelmooi.jpg"));
        public int score = 0;
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void vak_click(object sender, RoutedEventArgs e)
        {
            string ctrlName = ((Control)sender).Name;
            string[] words = ctrlName.Split("vak");
            int vak = Convert.ToInt32(words[1]);
            
            ZetStapSpeler(vak);

            foreach (string box in bke.ImageBoxen)
            {
                if (box == "X")
                {
                    bke.count++;
                }
            }

            if (bke.WinCheck()) // hier wint de speler
            {
                score = score + 3;
                bke.ClearVeld();
                PlaatjesResetten();
            }
            else
            {
                 if (bke.count != 5)
                {
                    ZetStapAI();

                    if (bke.WinCheck()) // hier wint de AI
                    {
                        score = score - 1;
                        bke.ClearVeld();
                        PlaatjesResetten();
                    }
                }
                else                    // hier is het gelijkspel
                {
                    bke.ClearVeld();
                    PlaatjesResetten(); 
                }
            }

            bke.count = 0;
        }

        private void ZetStapSpeler(int vak)
        {
            bke.ZetStapSpeler(vak);

            switch (vak)
            {
                default:
                    break;
                case 1:
                    image.Source = bke.plaatje_Speler; 
                    vak1.IsEnabled = false;
                    break;
                case 2:
                    image2.Source = bke.plaatje_Speler;
                    vak2.IsEnabled = false;
                    break;
                case 3:
                    image3.Source = bke.plaatje_Speler;
                    vak3.IsEnabled = false;
                    break;
                case 4:
                    image4.Source = bke.plaatje_Speler;
                    vak4.IsEnabled = false;
                    break;
                case 5:
                    image5.Source = bke.plaatje_Speler;
                    vak5.IsEnabled = false;
                    break;
                case 6:
                    image6.Source = bke.plaatje_Speler;
                    vak6.IsEnabled = false;
                    break;
                case 7:
                    image7.Source = bke.plaatje_Speler;
                    vak7.IsEnabled = false;
                    break;
                case 8:
                    image8.Source = bke.plaatje_Speler;
                    vak8.IsEnabled = false;
                    break;
                case 9:
                    image9.Source = bke.plaatje_Speler;
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
                    image.Source = bke.plaatje_AI;
                    vak1.IsEnabled = false;
                    break;
                case 2:
                    image2.Source = bke.plaatje_AI;
                    vak2.IsEnabled = false;
                    break;
                case 3:
                    image3.Source = bke.plaatje_AI;
                    vak3.IsEnabled = false;
                    break;
                case 4:
                    image4.Source = bke.plaatje_AI;
                    vak4.IsEnabled = false;
                    break;
                case 5:
                    image5.Source = bke.plaatje_AI;
                    vak5.IsEnabled = false;
                    break;
                case 6:
                    image6.Source = bke.plaatje_AI;
                    vak6.IsEnabled = false;
                    break;
                case 7:
                    image7.Source = bke.plaatje_AI;
                    vak7.IsEnabled = false;
                    break;
                case 8:
                    image8.Source = bke.plaatje_AI;
                    vak8.IsEnabled = false;
                    break;
                case 9:
                    image9.Source = bke.plaatje_AI;
                    vak9.IsEnabled = false;
                    break;
            }
        }
        private void PlaatjesResetten()
        {
            for (int i = 1; i < 10; i++)
            {
                switch (i)
                {
                    default:
                        break;
                    case 1:
                        image.Source = heelmooi;
                        vak1.IsEnabled = true;
                        break;
                    case 2:
                        image2.Source = heelmooi;
                        vak2.IsEnabled = true;
                        break;
                    case 3:
                        image3.Source = heelmooi;
                        vak3.IsEnabled = true;
                        break;
                    case 4:
                        image4.Source = heelmooi;
                        vak4.IsEnabled = true;
                        break;
                    case 5:
                        image5.Source = heelmooi;
                        vak5.IsEnabled = true;
                        break;
                    case 6:
                        image6.Source = heelmooi;
                        vak6.IsEnabled = true;
                        break;
                    case 7:
                        image7.Source = heelmooi;
                        vak7.IsEnabled = true;
                        break;
                    case 8:
                        image8.Source = heelmooi;
                        vak8.IsEnabled = true;
                        break;
                    case 9:
                        image9.Source = heelmooi;
                        vak9.IsEnabled = true;
                        break;
                }
            }
        }
    }
}
