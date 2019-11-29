using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{  
    class BlackJack
    {
        List<string> stock = new List<string>();
        public Speler deSpeler = new Speler();
        public Speler deDealer = new Speler();
        public Kaarten bank = new Kaarten();
        public string uitkomst = "";
        public bool gameOver = false;


        public void BustControle(double inzet)
        {
            if (deSpeler.BustControle(bank.TotaalPunten(deSpeler.listPunten)))
            {
                uitkomst = "Bust!";
                deSpeler.SaldoAfschrijven(inzet);
                gameOver = true;
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
                uitkomst = "Dealer bust!";
                deSpeler.SaldoBijschrijven(inzet);
                BustControle(inzet);
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
            gameOver = true;
            return uitkomst;
        }

        public void Clear()
        {
            deSpeler.listPunten.Clear();
            deSpeler.listKaarten.Clear();
            
            deDealer.listPunten.Clear();
            deDealer.listKaarten.Clear();
            
            uitkomst = "";
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
