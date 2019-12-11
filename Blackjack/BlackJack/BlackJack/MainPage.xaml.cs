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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BlackJack
{
  
    public sealed partial class MainPage : Page
    {

        BlackJack GameHost = new BlackJack();
        public double inzet { get; private set; }
        Image[] images;


        public MainPage()
        { 
            InitializeComponent();

            images = new Image[] { SpelerKaart1, SpelerKaart2, SpelerKaart3, SpelerKaart4, SpelerKaart5, SpelerKaart6, SpelerKaart7, SpelerKaart8 };        

            ClearText();
            
            InzetText();
            
        }
        

        //Inzet Bepalen
        private void InzetText()
        {
            Hit.IsEnabled = false;
            Stand.IsEnabled = false;
            
            ConfirmInzet.IsEnabled = true;
            //TbInzet.IsEnabled = true;
        }


        private void ConfirmInzet_Click(object sender, RoutedEventArgs e)
        {
          //  if (GameHost.InzetCheck(Convert.ToDouble(TbInzet.Text)))
          //  {
                
                inzet = Convert.ToDouble(TbInzet.Text);
                GameHost.deSpeler.SaldoAfschrijven(inzet);
                
                StartNewGame();
                
                ConfirmInzet.IsEnabled = false;
                //TbInzet.IsEnabled = false;
                
                Hit.IsEnabled = true;
                Stand.IsEnabled = true;
                
                Uitkomst.Text = "";
                
                Elf.IsEnabled = true;
                Een.IsEnabled = true;
           // }
           // else
           // {
            //    Uitkomst.Text = GameHost.uitkomst;
           // }
        }




        //Start
        private void StartNewGame()
        {
            ClearText();

            GameHost.Beurt1(inzet);
            AasControle(GameHost.deSpeler.HeeftAas);
            if (GameHost.HeeftInsurance)
            {
                Insurance.Visibility = Visibility.Visible;
            }
                       
            GameCheck();
            DoubleDown();

            UpdateText();
            InzetText();
        }


     


        private void UpdateText()
        {
            Saldo.Text = Convert.ToString(GameHost.deSpeler.saldo);
            KaartenDealer.Text = GameHost.deDealer.GetKaarten();
            KaartenSpeler.Text = GameHost.deSpeler.GetKaarten();
            Uitkomst.Text = GameHost.uitkomst;
        }




        //Hit
        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            GameHost.deSpeler.PakKaart(GameHost.bank);

            AasControle(GameHost.deSpeler.Aas());

            if (GameHost.deSpeler.Aas())
            {
                AasControle(true);
            }
            else
            {
                GameHost.SpelerBustControle(inzet);
            }

            GameCheck();
            UpdateText();
            Insurance.Visibility = Visibility.Collapsed;
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
            
            UpdateText();
        }




        // Einde
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            GameHost.Clear();
            ClearText();
            UpdateText();
            InzetText();
            NewGame.Visibility = Visibility.Collapsed;
            Een.IsEnabled = false;
            Elf.IsEnabled = false;
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
            
            Insurance.Visibility = Visibility.Collapsed;
            DoubleDownKnop.Visibility = Visibility.Collapsed;

            //BeurtGedaan = false;
            GameHost.ChangeInsurance(false);
        }
 

  
 
        //Aas
        private void AasControle(bool Aas)
        {
            if (Aas)
            {
                Elf.Visibility = Visibility.Visible;
                Een.Visibility = Visibility.Visible;
                Elf.IsEnabled = true;
                Een.IsEnabled = true;
               
                Hit.Visibility = Visibility.Collapsed;
                Stand.Visibility = Visibility.Collapsed;
                
                UpdateText();
                GameHost.deSpeler.ChangeHeeftAas(false);
            }
        }


        private void AasClick()
        {
            Elf.Visibility = Visibility.Collapsed;
            Een.Visibility = Visibility.Collapsed;
            Hit.Visibility = Visibility.Visible;
            Stand.Visibility = Visibility.Visible;
            TotaalPuntenSpeler.Text = Convert.ToString(GameHost.deSpeler.TotaalPunten());

            GameHost.SpelerBustControle(inzet);
            GameCheck();
            UpdateText();
        }


        private void Elf_Click(object sender, RoutedEventArgs e)
        {
            GameHost.deSpeler.spelerKaarten[GameHost.deSpeler.AasPlek].ChangeToEleven();
            AasClick();
            
            if (!GameHost.Beurtgedaan)
            {
                GameHost.Beurt2(inzet);
                AasControle(GameHost.deSpeler.Aas());
                GameHost.ChangeBeurtGedaan(true);
            }
            UpdateText();
        }


        private void Een_Click(object sender, RoutedEventArgs e)
        {
            GameHost.deSpeler.spelerKaarten[GameHost.deSpeler.AasPlek].ChangeToOne();
            AasClick();
           
            if (!GameHost.Beurtgedaan)
            {
                GameHost.Beurt2(inzet);
                AasControle(GameHost.deSpeler.Aas());
                GameHost.ChangeBeurtGedaan(true);
            }
            UpdateText();
        }




        // Double Down
        private void DoubleDown()
        {
            if (GameHost.deSpeler.DoubleDownControle() && GameHost.InzetCheck(inzet * 2))
            {
                DoubleDownKnop.Visibility = Visibility.Visible;
                GameHost.ChangeUitkomst("");
            }
        }


        private void DoubleDown_Click(object sender, RoutedEventArgs e)
        {
            inzet *= 2;
            TbInzet.Text = Convert.ToString(inzet);
            DoubleDownKnop.Visibility = Visibility.Collapsed;
        }




        //Insurance 
        private void Insurance_Click(object sender, RoutedEventArgs e)
        {
            GameHost.ChangeInsurance(true);
            GameHost.deSpeler.SaldoAfschrijven(inzet / 2);
            Insurance.Visibility = Visibility.Collapsed;

            if (!GameHost.Beurtgedaan)
            {
                GameHost.Beurt2(inzet);
                AasControle(GameHost.deSpeler.Aas());
                GameHost.ChangeBeurtGedaan(true);
            }
            UpdateText();
        }



        //  Fiches
        private void VijftigKnop_Click(object sender, RoutedEventArgs e)
        {
            if (GameHost.InzetCheck(Convert.ToDouble(BlackJack.fiches.Fifty)))
            {
                inzet = GameHost.TestInzet;
                TbInzet.Text =Convert.ToString(inzet);
            }
            UpdateText();
        }

        private void HonderdKnop_Click(object sender, RoutedEventArgs e)
        {
            if (GameHost.InzetCheck(Convert.ToDouble(BlackJack.fiches.Hundered)))
            {
                inzet = GameHost.TestInzet;
                TbInzet.Text = Convert.ToString(inzet);
            }
            UpdateText();
        }

        private void TweehonderdKnop_Click(object sender, RoutedEventArgs e)
        {
            if (GameHost.InzetCheck(Convert.ToDouble(BlackJack.fiches.Twohundered)))
            {
                inzet = GameHost.TestInzet;
                TbInzet.Text = Convert.ToString(inzet);
            }
            UpdateText();
        }

        private void VijfhonderdKnop_Click(object sender, RoutedEventArgs e)
        {
            if (GameHost.InzetCheck(Convert.ToDouble(BlackJack.fiches.Fivehunderd)))
            {
                inzet = GameHost.TestInzet;
                TbInzet.Text = Convert.ToString(inzet);
            }
            UpdateText();
        }


        private void PictureBox(Speler speler)
        {
            images[0]{ ImageSource =""; };

           // Image[] images = new Image[] {SpelerKaart1, SpelerKaart2, SpelerKaart3, SpelerKaart4, SpelerKaart5, SpelerKaart6, SpelerKaart7, SpelerKaart8 };
        }
}
}
