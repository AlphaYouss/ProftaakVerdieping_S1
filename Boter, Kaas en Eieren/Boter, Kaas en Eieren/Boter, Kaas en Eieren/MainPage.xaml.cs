using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Boter__Kaas_en_Eieren
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        BKE Speler = new BKE();
      //  BKE AI = new BKE();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ae(object sender, RoutedEventArgs e)
        {
            string ctrlName = ((Control)sender).Name;
            string[] words = ctrlName.Split("vak");

            Speler.PlayerClick(Convert.ToInt32(words[1]));

            ChangeImage(Convert.ToInt32(words[1]));

            if (Speler.Checken())
            {
                string a = "gewonnen!";
                txtMessage.Text = a;
            }

            Speler.AIclick();
            ChangeImage2(Speler.aiClick);
        }

        private void ChangeImage(int nummer)
        {
            switch (nummer)
            {
                default:
                    break;
                case 1:
                    image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke x.jpg"));
                    vak1.IsEnabled = false;
                    break;
                case 2:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke x.jpg"));
                    vak2.IsEnabled = false;
                    break;
                case 3:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke x.jpg"));
                    vak3.IsEnabled = false;
                    break;
                case 4:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke x.jpg"));
                    vak4.IsEnabled = false;
                    break;
                case 5:
                    image5.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke x.jpg"));
                    vak5.IsEnabled = false;
                    break;
                case 6:
                    image6.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke x.jpg"));
                    vak6.IsEnabled = false;
                    break;
                case 7:
                    image7.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke x.jpg"));
                    vak7.IsEnabled = false;
                    break;
                case 8:
                    image8.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke x.jpg"));
                    vak8.IsEnabled = false;
                    break;
                case 9:
                    image9.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke x.jpg"));
                    vak9.IsEnabled = false;
                    break;

            }
        }
        private void ChangeImage2(int nummer)
        {
            switch (nummer)
            {
                default:
                    break;
                case 1:
                    image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke O.jpg"));
                    vak1.IsEnabled = false;
                    break;
                case 2:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke O.jpg"));
                    vak2.IsEnabled = false;
                    break;
                case 3:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke O.jpg"));
                    vak3.IsEnabled = false;
                    break;
                case 4:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke O.jpg"));
                    vak4.IsEnabled = false;
                    break;
                case 5:
                    image5.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke O.jpg"));
                    vak5.IsEnabled = false;
                    break;
                case 6:
                    image6.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke O.jpg"));
                    vak6.IsEnabled = false;
                    break;
                case 7:
                    image7.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke O.jpg"));
                    vak7.IsEnabled = false;
                    break;
                case 8:
                    image8.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke O.jpg"));
                    vak8.IsEnabled = false;
                    break;
                case 9:
                    image9.Source = new BitmapImage(new Uri("ms-appx:///Assets/Dikke O.jpg"));
                    vak9.IsEnabled = false;
                    break;
            }
        }
    }
}
