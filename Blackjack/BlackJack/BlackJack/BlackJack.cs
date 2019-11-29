using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{  
    class BlackJack
    {
        List<string> Stock = new List<string>();
        public Speler DeSpeler = new Speler();
        public Dealer DeDealer = new Dealer();
        public string Uitkomst = "-";
        public bool GameOver = false;

        public BlackJack()
        {



        public void BustControle(double Inzet)
        {
            if (DeSpeler.BustControle() /*|| DeDealer.BustControle()*/)
            {
                Uitkomst = "Bust!";
                GameOver = true;
                DeSpeler.SaldoAfschrijven(Inzet);
                //  Uitkomst = "";
                //  Clear();
                //  Start(); 
            }
            
        }

      
        public string WinnaarControle(double inzet, int totaal)
        {
       
            int Speler = bank.TotaalPunten(deSpeler.listPunten);
            int Dealer = bank.TotaalPunten(deDealer.listPunten);

            if (Speler == 21)
            {
                uitkomst = "De speler heeft gewonnen!";
                deSpeler.SaldoBijschrijven(inzet);
            }

            else if (Dealer > 21)
            {
                Uitkomst = "Bust!";
                DeSpeler.SaldoBijschrijven(inzet);
            }

            else if (DeSpeler.BustControle())
            {
                Uitkomst = "Bust!";
                GameOver = true;
                DeSpeler.SaldoAfschrijven(inzet);
            }

            else if (Speler > Dealer&& Speler <= 21 )
            {
                uitkomst = "De speler heeft gewonnen!";
                deSpeler.SaldoBijschrijven(inzet);
            }
            else if ( Dealer > Speler && Dealer <= 21)
            {
                uitkomst = "De dealer heeft gewonnen!";
                deSpeler.SaldoAfschrijven(inzet);
            }

            else if (Speler == Dealer && Speler <=20 )
            {
                uitkomst = "De dealer heeft gewonnen!";
                deSpeler.SaldoAfschrijven(inzet);
            }

            else if (Speler == Dealer && Speler <= 21)
            {
                uitkomst = "Het is gelijkspel!";
            }
            GameOver = true;
            return Uitkomst;
        }

        public void Clear()
        {
            DeSpeler.Clear();
            DeDealer.Clear();
            Uitkomst = "";
            GameOver = false;
        }

        public void Start()
        {
            bank.NieuweKaart(deSpeler.listKaarten, deSpeler.listPunten);
            bank.NieuweKaart(deSpeler.listKaarten, deSpeler.listPunten);
            bank.NieuweKaart(deDealer.listKaarten, deDealer.listPunten);
            bank.NieuweKaart(deDealer.listKaarten, deDealer.listPunten);
        }
        
    }
}
