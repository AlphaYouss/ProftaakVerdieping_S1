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
        public string Uitkomst = "Uitkomst"; 
        public BlackJack()
        {

        }

        public void StockCheck(string Kaart)
        {
            if (Stock.Contains(Kaart))
            {

            }

        }

        public void BustControle()
        {
            if (DeSpeler.BustControle() || DeDealer.BustControle())
            {
                Uitkomst = "Bust!";
               
                Uitkomst = "";
                  Clear();
                  Start(); 
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

            else if (Speler > 21 || Dealer > 21)
            {
                Uitkomst = "Bust!";
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
            return Uitkomst;
        }

        public void Clear()
        {
            DeSpeler.Clear();
            DeDealer.Clear();
        }

        public void Start()
        {
            DeSpeler.Start();
            DeDealer.Start();
        }
        
    }
}
