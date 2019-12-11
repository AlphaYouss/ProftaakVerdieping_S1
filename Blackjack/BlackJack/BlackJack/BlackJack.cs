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
       
        public bool HeeftInsurance { get; private set; }
        public double TestInzet { get; private set; } = 50;
        public enum fiches { Fifty = 50, Hundered = 100, Twohundered = 200, Fivehunderd = 500 };
        public bool Beurtgedaan { get; private set; } = false;

        //Start 

        public void Beurt1(double inzet)
        {
            bool Zichtbaar = false;

            deSpeler.PakKaart(bank);
            if (deSpeler.Aas() == true)
            {
                Zichtbaar = true;
            }

            deDealer.PakKaart(bank);
            deDealer.DealerAzen();
            if (deDealer.InsuranceControle())
            {
                HeeftInsurance = true;
                Zichtbaar = true;
            }

            if (!Zichtbaar)
            {
                Beurt2(inzet);
            }
        }

        public void Beurt2(double inzet)
        {
            deSpeler.PakKaart(bank);
            deSpeler.Aas();
            

            deDealer.PakKaart(bank);
            deDealer.DealerAzen();
            if (Insurance)
            {
                if (deDealer.spelerKaarten[1].Punt == 10)
                {
                    deSpeler.SaldoBijschrijven(inzet / 2);

                    Stand(inzet,bank);
                }
            }
            Beurtgedaan = true;
        }



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
                //deSpeler.SaldoAfschrijven(Inzet);
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
                deSpeler.SaldoBijschrijven(inzet *2);
            }

            else if (Dealer > 21)
            {
                uitkomst = "Dealer Bust!";
                deSpeler.SaldoBijschrijven(inzet * 2);
            }


            else if (Speler > Dealer && Speler <= 21)
            {
                uitkomst = "De speler heeft gewonnen!";
                deSpeler.SaldoBijschrijven(inzet * 2);
            }
           
            
            else if ( Dealer > Speler )
            {
                uitkomst = "De dealer heeft gewonnen!";
                //deSpeler.SaldoAfschrijven(inzet);
            }

            else if (Speler == Dealer)
            {
                uitkomst = "De dealer heeft gewonnen!(Huis +1)";
               // deSpeler.SaldoAfschrijven(inzet);
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
            HeeftInsurance = false;
            Beurtgedaan = false;
            TestInzet = 50;
        }



        public bool InzetCheck(double inzet)
        {
            //TestInzet = 50;
            TestInzet += inzet;

            if (TestInzet > deSpeler.saldo || TestInzet >= 1000)
            {
                uitkomst = "Je inzet is te hoog";
                TestInzet -= inzet;
                return false;
            }
            return true;
        }

        public void ChangeUitkomst(string NieuweUitkomst)
        {
            uitkomst = NieuweUitkomst;
        }

        public void ChangeInsurance(bool Waarde)
        {
                Insurance = Waarde;
        }

        public void ChangeBeurtGedaan(bool Waarde)
        {
            Beurtgedaan = Waarde;
        }
    }
}
