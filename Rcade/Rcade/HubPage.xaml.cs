using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rcade
{
    public sealed partial class HubPage : Page
    {
        public HubPage()
        {
            InitializeComponent();
        }

        private void BKE_Click(object sender, RoutedEventArgs e)
        {
            BKEPage bke = new BKEPage();
            Content = bke;
        }

        private void BJ_Click(object sender, RoutedEventArgs e)
        {
            //HubPage hub = new HubPage();
            //Content = hub;
        }
    }
}
