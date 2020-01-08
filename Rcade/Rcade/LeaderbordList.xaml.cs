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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Rcade
{
    public sealed partial class LeaderbordGame : Page
    {
        
        
        Databasehandler_lb dbh = new Databasehandler_lb(true);
        


        public LeaderbordGame(int Number)
        {
            this.InitializeComponent();
            
            dbh.ChangeChoice(Number);

            dbh.ChoiceMaker();
            
            UpdateText();
        }



        private void ClearText()
        {
            Column1Text.Text = "";
            Column2Text.Text = "";
            Column3Text.Text = "";
            Column4Text.Text = "";
            Column5Text.Text = "";
        }


        private void UpdateText()
        {
         //   ClearText();

            ButtonOnOff();

            Column1.Items.Clear();

            Column1Text.Text = dbh.Table1Name;
            ListToListview(Column1, dbh.Table1);
            
            Column2Text.Text = dbh.Table2Name;
            ListToListview(Column2, dbh.Table2);
            
            Column3Text.Text = dbh.Table3Name;
            ListToListview(Column3, dbh.Table3);
            
            Column4Text.Text = dbh.Table4Name;
            ListToListview(Colomn4, dbh.Table4);

            Column5Text.Text = dbh.Table5Name;
            ListToListview(Colomn5, dbh.Table5);
        }




        private void ListToListview(ListView listView, List<string> list)
        {
            listView.Items.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                listView.Items.Add(list[i]);
            }
        }





        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
            int TestChoice = dbh.Choice - 1;
            if (TestChoice >= 1)
            {
                dbh.ChangeChoice(TestChoice);
                dbh.ChoiceMaker();
            }

            if (dbh.Choice == 1)
            {
                BackButton.IsEnabled = false;
            }
            else
            {
                BackButton.IsEnabled = true;
            }

            UpdateText();

        }


        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            int TestChoice = dbh.Choice + 1;
            if (TestChoice <= 5)
            {
                dbh.ChangeChoice(TestChoice);
                dbh.ChoiceMaker();
            }

            if (dbh.Choice == 5)
            {
                ForwardButton.IsEnabled = false;
            }
            else
            {
                ForwardButton.IsEnabled = true;
            }

            UpdateText();
        }


        private void ButtonOnOff()
        {
            if (dbh.Choice == 5)
            {
                ForwardButton.IsEnabled = false;
            }
            else
            {
                ForwardButton.IsEnabled = true;
            }

            if (dbh.Choice == 1)
            {
                BackButton.IsEnabled = false;
            }
            else
            {
                BackButton.IsEnabled = true;
            }
        }


    }
}
