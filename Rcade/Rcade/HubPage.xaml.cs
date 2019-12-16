using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rcade
{
    public sealed partial class HubPage : Page
    {
        public HubPage()
        {
            InitializeComponent();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(
            new Size(
            1000, // Width
            1000 // Height
            ));
        }

        private void btnUitloggen_Click(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            Content = main;
        }

        private void btn_Bke_Click(object sender, RoutedEventArgs e)
        {
            BKEPage bke = new BKEPage();
            Content = bke;
        }

        private void btn_Bj_Click(object sender, RoutedEventArgs e)
        {
            BJPage bj = new BJPage();
            Content = bj;
        }
    }
}
