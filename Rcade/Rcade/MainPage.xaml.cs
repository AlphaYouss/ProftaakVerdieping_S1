using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rcade
{
    public sealed partial class MainPage : Page
    {
        private Databasehandler dbh = new Databasehandler();

        public MainPage()
        {
            InitializeComponent();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(
            new Size(
                1000, // Width
                1000 // Height
                ));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage();
            Content = hub;
        }

        //public void WriteData()
        //{
        //    dbh.GetUserData();

        //    foreach (DataRow row in dbh.table.Rows)
        //    {
        //        string name = row["Username"].ToString();
        //     }
        //}
    }
}
