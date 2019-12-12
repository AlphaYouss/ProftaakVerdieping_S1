using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rcade
{
    public sealed partial class LoginPage : Page
    {
        private Databasehandler dbh = new Databasehandler();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
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
