using System.Data;
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
            WriteData();
        }

        void submitButtonClick(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            Content = menu;
        }

        public void WriteData()
        {
            dbh.GetUserData();

            foreach (DataRow row in dbh.table.Rows)
            {
                string name = row["Username"].ToString();
             }
        }
    }
}
