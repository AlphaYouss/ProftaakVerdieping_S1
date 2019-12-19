using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rcade
{
    public sealed partial class HubPage : Page
    {
        private User user { get; set; }
        public HubPage()
        {
            InitializeComponent();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(
            new Size(
            1000,
            1000 
            ));
        }

        internal void SetUser(User user)
        {
            this.user = user;
        }

        private void btnUitloggen_Click(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            Content = main;
        }

        private void btnBke_Click(object sender, RoutedEventArgs e)
        {
            BKEPage bke = new BKEPage();
            bke.SetUser(user);

            Content = bke;
        }

        private void btnBj_Click(object sender, RoutedEventArgs e)
        {
            BJPage bj = new BJPage();
            bj.SetUser(user);

            Content = bj;
        }
    }
}
