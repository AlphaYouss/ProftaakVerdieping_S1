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
            ClearText();
            StartText();  
        }

        //Start
        private void StartNewGame()
        {
        //    Hit.Visibility = Visibility.Collapsed;
        //    Stand.Visibility = Visibility.Collapsed;
        //    NewGame.Visibility = Visibility.Visible;
            GameHost.Clear();
            GameHost.Start();
            ClearText();
            StartText();
        }
        private void StartText()
        {
            Saldo.Text = Convert.ToString(GameHost.deSpeler.saldo);
            KaartenDealer.Text = GameHost.deDealer.GetKaarten();
            KaartenSpeler.Text = GameHost.deSpeler.GetKaarten();
            Uitkomst.Text = GameHost.uitkomst;
        }


        //Hit
        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            double inzet = Convert.ToDouble(Inzet.Text);

            GameHost.Hit(inzet);

            AasControle();
           
            GameCheck();

            //Uitkomst.Text = GameHost.uitkomst;
            StartText();
        }


        public void GameCheck()
        {
            if (GameHost.gameOver)
            {
                Hit.Visibility = Visibility.Collapsed;
                Stand.Visibility = Visibility.Collapsed;
                NewGame.Visibility = Visibility.Visible;
                //StartNewGame();
            }
        }

        // Stand
        private  void Stand_Click(object sender, RoutedEventArgs e)
        {
            double inzet = Convert.ToDouble(Inzet.Text);

            GameHost.Stand(inzet, GameHost.bank);
           
            GameCheck();
            
            StartText();
        }



        // Einde
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        private void ClearText()
        {
            Saldo.Text = "";
            Uitkomst.Text = "";
            KaartenSpeler.Text = "";
            KaartenDealer.Text = "";
            Uitkomst.Text = "";
            Hit.Visibility = Visibility.Visible;
            Stand.Visibility = Visibility.Visible;
            NewGame.Visibility = Visibility.Collapsed;
            Elf.Visibility = Visibility.Collapsed;
            Een.Visibility = Visibility.Collapsed;
        }


        //Aas
        private void AasControle()
        {
            if (GameHost.deSpeler.Aas())
            {
                Elf.Visibility = Visibility.Visible;
                Een.Visibility = Visibility.Visible;
                Hit.Visibility = Visibility.Collapsed;
                Stand.Visibility = Visibility.Collapsed;
            }
        }


        private void Elf_Click(object sender, RoutedEventArgs e)
        {
            Elf.Visibility = Visibility.Collapsed;
            Een.Visibility = Visibility.Collapsed;
            Hit.Visibility = Visibility.Visible;
            Stand.Visibility = Visibility.Visible;
        }

        private void Een_Click(object sender, RoutedEventArgs e)
        {
            // Hier komt een code die de 11 in de punten lijst vervangt door een 1

            Elf.Visibility = Visibility.Collapsed;
            Een.Visibility = Visibility.Collapsed;
            Hit.Visibility = Visibility.Visible;
            Stand.Visibility = Visibility.Visible;
        }
    }
}
