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
  
    public sealed partial class MainPage : Page
    {

        BlackJack GameHost = new BlackJack();
        public double inzet { get; private set; }
       // public double inzet;

     //   public bool Insurance { get; private set; } = false;

        public MainPage()
        { 
            InitializeComponent();
            
            GameHost.Start();
            ClearText();
            StartText();
            InzetText();
            GameHost.deSpeler.DoubleDownControle();
        }

        private void DoubleDown()
        {
            if (GameHost.deSpeler.DoubleDownControle())
            {
                DoubleDownKnop.Visibility = Visibility.Visible;
            }
        }

        //Start
        private void StartNewGame()
        {
            GameHost.Clear();
            ClearText();
            
            GameHost.Start(); 
            StartText();

           
         //   AasControle();
            InzetText(); 
         //   DoubleDown();  
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
           // GameHost.deSpeler.PakKaart(GameHost.bank);

            //  AasControle();
            GameHost.Hit(inzet);
           // GameHost.SpelerBustControle(inzet);
            GameCheck();
            StartText();
        }


        public void GameCheck()
        {
            if (GameHost.gameOver)
            {
                Hit.Visibility = Visibility.Collapsed;
                Stand.Visibility = Visibility.Collapsed;
                NewGame.Visibility = Visibility.Visible;
                Elf.Visibility = Visibility.Collapsed;
                Een.Visibility = Visibility.Collapsed;
            }
        }

        // Stand
        private  void Stand_Click(object sender, RoutedEventArgs e)
        {
            GameHost.Stand(inzet, GameHost.bank);
           
            GameCheck();
            
            StartText();
        }



        // Einde
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
            Een.IsEnabled = false;
            Elf.IsEnabled = false;
        }

        private void ClearText()
        {
            DoubleDownKnop.Visibility = Visibility.Collapsed;
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

/*
        //Aas
        private void AasControle()
        {
            if (GameHost.deSpeler.Aas())
            {
                Elf.Visibility = Visibility.Visible;
                Een.Visibility = Visibility.Visible;
                Elf.IsEnabled = true;
                Een.IsEnabled = true;
                Hit.Visibility = Visibility.Collapsed;
                Stand.Visibility = Visibility.Collapsed;
                StartText();
            }
            else
            {
                GameHost.SpelerBustControle(inzet);
                GameCheck();
                StartText();
            } 
        }
*/
        private void Elf_Click(object sender, RoutedEventArgs e)
        {
            Elf.Visibility = Visibility.Collapsed;
            Een.Visibility = Visibility.Collapsed;
            Hit.Visibility = Visibility.Visible;
            Stand.Visibility = Visibility.Visible;
            TotaalPuntenSpeler.Text = Convert.ToString(GameHost.deSpeler.TotaalPunten());
            
            
            GameHost.SpelerBustControle(inzet);
            GameCheck();
            StartText();
        }

        private void Een_Click(object sender, RoutedEventArgs e)
        {
            
           // GameHost.deSpeler.spelerKaarten[GameHost.deSpeler.AasPlekken[0]].ChangeToOne(); 
            
            Elf.Visibility = Visibility.Collapsed;
            Een.Visibility = Visibility.Collapsed;
            Hit.Visibility = Visibility.Visible;
            Stand.Visibility = Visibility.Visible;
            TotaalPuntenSpeler.Text = Convert.ToString(GameHost.deSpeler.TotaalPunten());
           
            
            GameHost.SpelerBustControle(inzet);
            GameCheck();
            StartText();
        }

        private void ConfirmInzet_Click(object sender, RoutedEventArgs e)
        {           
            if (GameHost.InzetCheck(Convert.ToDouble(TbInzet.Text)))
            {
                inzet = Convert.ToDouble(TbInzet.Text);
                ConfirmInzet.IsEnabled = false;
                TbInzet.IsEnabled = false;
                Hit.IsEnabled = true;
                Stand.IsEnabled = true;
                Uitkomst.Text = "";
                Elf.IsEnabled = true;
                Een.IsEnabled = true;
                DoubleDown();
            }
            else
            {
                Uitkomst.Text = GameHost.uitkomst;
                
            }
           
        }


        private void InzetText()
        {
            Hit.IsEnabled = false;
            Stand.IsEnabled = false;
            ConfirmInzet.IsEnabled = true;
            TbInzet.IsEnabled = true;
        }


        private void DoubleDown_Click(object sender, RoutedEventArgs e)
        {
            inzet *= 2;
            TbInzet.Text = Convert.ToString(inzet);
            DoubleDownKnop.Visibility = Visibility.Collapsed;
        }
    }
}
