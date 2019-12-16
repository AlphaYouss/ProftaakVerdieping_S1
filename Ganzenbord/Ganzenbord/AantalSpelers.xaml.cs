using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

namespace Ganzenbord
{

    public sealed partial class AantalSpelers : Page
    {
        
        public int aantalSpelers { get; private set; }


        public AantalSpelers()
        {
            this.InitializeComponent();
            aantalSpelers = 2;
            
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            aantalSpelers++;
            txtAantalspelers.Text = Convert.ToString(aantalSpelers);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            aantalSpelers = Convert.ToInt32(txtAantalspelers.Text);
            MainPage mainPage = new MainPage(aantalSpelers);
            Content = mainPage;
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            aantalSpelers--;
            txtAantalspelers.Text = Convert.ToString(aantalSpelers);
        }
    }
}
