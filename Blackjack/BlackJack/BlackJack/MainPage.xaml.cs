using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BlackJack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
  
    public sealed partial class MainPage : Page
    {
        BlackJack GameHost = new BlackJack();
       

        public MainPage()
        { 
            this.InitializeComponent();
            GameHost.Start();
            StartText();
        }
        

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            double inzet = Convert.ToDouble(Inzet.Text);
            GameHost.DeSpeler.Hit(GameHost, inzet);
           // GameHost.BustControle(inzet);
            Uitkomst.Text = GameHost.Uitkomst;
            StartText();
            if (GameHost.GameOver)
            {
                KnopZichtbaar();
            }
         //   KaartenSpeler.Text= GameHost.DeSpeler.GetKaarten();
            
            GameHost.deDealer.HitControle(GameHost.bank,GameHost.deDealer.listPunten);
            GameHost.WinnaarControle(inzet, GameHost.bank.TotaalPunten(GameHost.deSpeler.listPunten));
           
            StartText();
            GameOver();
        }

        private  void Stand_Click(object sender, RoutedEventArgs e)
        {
            double inzet = Convert.ToDouble(Inzet.Text);
            //GameHost.DeSpeler.Stand(GameHost.DeDealer, inzet);
            GameHost.DeDealer.HitControle();
            GameHost.WinnaarControle(inzet);
            StartText();
            
            if (GameHost.GameOver)
            {
                KnopZichtbaar();
            }

            //await Task.Delay(TimeSpan.FromSeconds(5));


        private void ClearText()
        {
            Saldo.Text = "";
            Uitkomst.Text = "";
            KaartenSpeler.Text = "";
            KaartenDealer.Text = "";
            Inzet.Text = Convert.ToString(100);
        }

        private void StartText()
        {
            Saldo.Text = Convert.ToString(GameHost.DeSpeler.Saldo);
            KaartenDealer.Text = GameHost.DeDealer.GetKaarten();
            KaartenSpeler.Text = GameHost.DeSpeler.GetKaarten();
            Uitkomst.Text = GameHost.Uitkomst;
            Hit.Visibility = Visibility.Visible;
            Stand.Visibility = Visibility.Visible;
            NewGame.Visibility = Visibility.Collapsed;
        }

        private void KnopZichtbaar()
        {
            Hit.Visibility = Visibility.Collapsed;
            Stand.Visibility = Visibility.Collapsed;
            NewGame.Visibility = Visibility.Visible;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
          //  GameHost.GameOver = false;
            GameHost.Clear();
            GameHost.Start();
            ClearText();
            StartText();
        }
    }
}
