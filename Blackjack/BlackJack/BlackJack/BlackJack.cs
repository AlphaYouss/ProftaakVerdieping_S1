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

        }


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

      
        public string WinnaarControle(double inzet)
        {
            DeDealer.HitControle();
            DeDealer.BustControle();
            DeSpeler.BustControle();
           // String Uitkomst = "";

            int Speler = DeSpeler.TotaalPunten();
            int Dealer = DeDealer.TotaalPunten();

            if (Speler == 21)
            {
                Uitkomst = "De speler heeft gewonnen!";
                DeSpeler.SaldoBijschrijven(inzet);
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
                Uitkomst = "De speler heeft gewonnen!";
                DeSpeler.SaldoBijschrijven(inzet);
            }
            else if ( Dealer > Speler && Dealer <= 21)
            {
                Uitkomst = "De dealer heeft gewonnen!";
                DeSpeler.SaldoAfschrijven(inzet);
            }

            else if (Speler == Dealer && Speler <=20 )
            {
                Uitkomst = "De dealer heeft gewonnen!";
                DeSpeler.SaldoAfschrijven(inzet);
            }

            else if (Speler == Dealer && Speler <= 21)
            {
                Uitkomst = "Het is gelijkspel!";
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
            DeSpeler.Start();
            DeDealer.Start();
        }
        
    }
}
