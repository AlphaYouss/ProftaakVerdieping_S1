using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{  
    class BlackJack
    {

        public Speler deSpeler = new Speler();
        public Speler deDealer = new Speler();
        public Kaarten bank = new Kaarten();
        public string uitkomst = "-";
        public bool gameOver = false;

        //Start
        public void Start()
        {
            bank.NieuweKaart(deSpeler.spelerPunten, deSpeler.spelerKaarten);
            bank.NieuweKaart(deSpeler.spelerPunten, deSpeler.spelerKaarten);

            bank.NieuweKaart(deDealer.spelerPunten, deDealer.spelerKaarten);
            bank.NieuweKaart(deDealer.spelerPunten, deDealer.spelerKaarten);
        }



        //Hit
        public void Hit(double inzet)
        {
            bank.NieuweKaart(deSpeler.spelerPunten, deSpeler.spelerKaarten);
            SpelerBustControle(inzet);
        }


        private void SpelerBustControle(double Inzet)
        {
            if (deSpeler.BustControle())
            {
                uitkomst = "Speler bust!";
                deSpeler.SaldoAfschrijven(Inzet);
                gameOver = true;
                
            } 
        }


        //Stand
        public void Stand(double inzet, Kaarten bank)
        {
            deDealer.HitControle(bank);
            WinnaarControle(inzet);
        }
      

        public string WinnaarControle(double inzet)
        {

            int Speler = deSpeler.TotaalPunten();
            int Dealer = deDealer.TotaalPunten();

            if (Speler == 21)
            {
                uitkomst = "De speler heeft blackjack!";
                deSpeler.SaldoBijschrijven(inzet);
            }

            else if (Dealer > 21)
            {
                uitkomst = "Dealer Bust!";
                deSpeler.SaldoBijschrijven(inzet);
            }

            else if (Speler > Dealer)
            {
                uitkomst = "De speler heeft gewonnen!";
                deSpeler.SaldoBijschrijven(inzet);
            }
           
            
            else if ( Dealer > Speler)
            {
                uitkomst = "De dealer heeft gewonnen!";
                deSpeler.SaldoAfschrijven(inzet);
            }

            else if (Speler == Dealer)
            {
                uitkomst = "De dealer heeft gewonnen!(Huis +1)";
                deSpeler.SaldoAfschrijven(inzet);
            }
            gameOver = true;
            return uitkomst;
        }


        //Einde
        public void Clear()
        {
            deSpeler.spelerKaarten.Clear();
            deSpeler.spelerPunten.Clear();

            deDealer.spelerKaarten.Clear();
            deDealer.spelerPunten.Clear();

           // uitkomst = "";
           // gameOver = false;
        }

        
        
    }
}
