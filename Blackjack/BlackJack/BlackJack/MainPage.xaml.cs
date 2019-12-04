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
        public bool BeurtGedaan { get; private set; } = false;

        public MainPage()
        { 
            InitializeComponent();
            
            ClearText();
            
            InzetText();
        }
        

        //Inzet Bepalen
        private void InzetText()
        {
            Hit.IsEnabled = false;
            Stand.IsEnabled = false;
            ConfirmInzet.IsEnabled = true;
            TbInzet.IsEnabled = true;
        }


        private void ConfirmInzet_Click(object sender, RoutedEventArgs e)
        {
            if (GameHost.InzetCheck(Convert.ToDouble(TbInzet.Text)))
            {
                StartNewGame();
                inzet = Convert.ToDouble(TbInzet.Text);
                ConfirmInzet.IsEnabled = false;
                TbInzet.IsEnabled = false;
                Hit.IsEnabled = true;
                Stand.IsEnabled = true;
                Uitkomst.Text = "";
                Elf.IsEnabled = true;
                Een.IsEnabled = true;
            }
            else
            {
                Uitkomst.Text = GameHost.uitkomst;
            }
        }




        //Start
        private void StartNewGame()
        {
            ClearText();

            Beurt1();

            UpdateText();
            InzetText();
        }


        private void Beurt1()
        {
            bool Zichtbaar = false;

            GameHost.deSpeler.PakKaart(GameHost.bank);
            if (GameHost.deSpeler.Aas() == true)
            {
                AasControle(true);
                Zichtbaar = true;
            }

            GameHost.deDealer.PakKaart(GameHost.bank);
            GameHost.deDealer.DealerAzen();
            if (GameHost.deDealer.InsuranceControle())
            {
                Insurance.Visibility = Visibility.Visible;
                Zichtbaar = true;
            }

            if (!Zichtbaar)
            {
                Beurt2();
            }
        }


        private void Beurt2()
        {
            GameHost.deSpeler.PakKaart(GameHost.bank);
            AasControle(GameHost.deSpeler.Aas());

            GameHost.deDealer.PakKaart(GameHost.bank);
            GameHost.deDealer.DealerAzen();
            if (GameHost.Insurance)
            {
                if (GameHost.deDealer.spelerKaarten[1].Punt == 10)
                {
                    GameHost.deSpeler.SaldoBijschrijven(inzet / 2);

                    GameHost.Stand(inzet, GameHost.bank);

                    GameCheck();

                    UpdateText();
                }
            }

            DoubleDown();
            UpdateText();
            BeurtGedaan = true;
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
            GameHost.SpelerBustControle(inzet);
            //GameHost.Hit(inzet);

            GameCheck();
            UpdateText();
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
            Insurance.Visibility = Visibility.Collapsed;
            BeurtGedaan = false;
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
            
            if (BeurtGedaan == false)
            {
                Beurt2();
            }
        }


        private void Een_Click(object sender, RoutedEventArgs e)
        {
            GameHost.deSpeler.spelerKaarten[GameHost.deSpeler.AasPlek].ChangeToOne();
            AasClick();
           
            if (BeurtGedaan == false)
            {
                Beurt2();
            }
        }




        // Double Down
        private void DoubleDown()
        {
            if (GameHost.deSpeler.DoubleDownControle())
            {
                DoubleDownKnop.Visibility = Visibility.Visible;
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
            Insurance.Visibility = Visibility.Visible;
        }
    }
}
