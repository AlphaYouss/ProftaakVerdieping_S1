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
            
            StartText();
        }


        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            GameHost.DeSpeler.Hit(GameHost);
            GameHost.BustControle();
            Uitkomst.Text = GameHost.Uitkomst;
            StartText();
         //   KaartenSpeler.Text= GameHost.DeSpeler.GetKaarten();
            
        }

        private async void Stand_Click(object sender, RoutedEventArgs e)
        {
            //double inzet = Convert.ToDouble(Inzet.Text);
            //GameHost.DeSpeler.Stand(GameHost.DeDealer, inzet);
            //StartText();
            //await Task.Delay(TimeSpan.FromSeconds(5));

            //GameHost.WinnaarControle(inzet);
            //Uitkomst.Text = GameHost.Uitkomst;
            //KaartenDealer.Text = GameHost.DeDealer.GetKaarten();

            //await Task.Delay(TimeSpan.FromSeconds(5));
            //ClearText();
            //StartText();
            //GameHost.Clear();
            //GameHost.Start();

        }

        private void ClearText()
        {
            Saldo.Text = "";
            Uitkomst.Text = "";
            KaartenSpeler.Text = "";
            KaartenDealer.Text = "";
            Uitkomst.Text = "";
        }

        private void StartText()
        {
            Saldo.Text = Convert.ToString(GameHost.DeSpeler.Saldo);
            KaartenDealer.Text = GameHost.DeDealer.GetKaarten();
            KaartenSpeler.Text = GameHost.DeSpeler.GetKaarten();
            Uitkomst.Text = GameHost.Uitkomst;
        }
        
    }
}
