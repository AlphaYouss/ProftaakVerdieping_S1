using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{  
    class BlackJack
    {
        public Speler deSpeler { get; private set; } = new Speler();
        public Speler deDealer { get; private set; } = new Speler();
        public Kaarten bank { get; private set; } = new Kaarten();
        public string uitkomst { get; private set; } = "";
        public bool gameOver { get; private set; } = false;
        public bool Insurance { get; private set; } = false;


        //Hit
        public void Hit(double inzet)
        {
            deSpeler.PakKaart(bank);
            SpelerBustControle(inzet);
        }


        public void SpelerBustControle(double Inzet)
        {
          if (deSpeler.TotaalPunten() > 21)
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

            if(Insurance && Dealer == 21)
            {
                uitkomst = "Insurance wordt uitbetaald!"; 

            }

            else if (Speler == 21)
            {
                uitkomst = "De speler heeft blackjack!";
                deSpeler.SaldoBijschrijven(inzet);
            }

            else if (Dealer > 21)
            {
                uitkomst = "Dealer Bust!";
                deSpeler.SaldoBijschrijven(inzet);
            }


            else if (Speler > Dealer && Speler <= 21)
            {
                uitkomst = "De speler heeft gewonnen!";
                //deSpeler.SaldoBijschrijven(inzet);
            }
           
            
            else if ( Dealer > Speler )
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
            deSpeler.HandLegen();
            deDealer.HandLegen();
            uitkomst = "";
            gameOver = false;
        }



        public bool InzetCheck(double inzet)
        {
            if (inzet > deSpeler.saldo || inzet > 250)
            {
                uitkomst = "Je inzet is te hoog";
                return false;
            }
            else if (inzet <= 0)
            {
                uitkomst = "Je inzet is  0 / negatief";
                return false;
            }
            return true;
        }

        public void ChangeInsurance(bool Waarde)
        {
           // if (deDealer.InsuranceControle())
           // {
                Insurance = Waarde;
           // }
        }


    }
}
