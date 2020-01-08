using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

namespace Ganzenbord
{

    public sealed partial class AantalSpelers : Page
    {
        
        public int playerCount { get; private set; }


        public AantalSpelers()
        {
            this.InitializeComponent();
            playerCount = 2;
            
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            playerCount++;
            txtPlayerCount.Text = Convert.ToString(playerCount);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            playerCount = Convert.ToInt32(txtPlayerCount.Text);
            MainPage mainPage = new MainPage(playerCount);
            Content = mainPage;
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            playerCount--;
            txtPlayerCount.Text = Convert.ToString(playerCount);
        }
    }
}
