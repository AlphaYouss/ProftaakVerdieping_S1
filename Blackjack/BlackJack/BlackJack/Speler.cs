using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Speler
    {
        public List<string> listKaarten = new List<string>();
        public List<int> listPunten = new List<int>();
        public double saldo = 2000;

        public Speler()
        {
        }

        public bool BustControle(int Totaal)
        {
            if (Totaal >21)
            {
               //
            }
        }

        public void Hit(BlackJack blackJack,double inzet)
        {
            NieuweKaart();
            blackJack.BustControle(inzet);           
        }

        public bool DoubleDownControle()
        {
            if (TotaalPunten() == 9 || TotaalPunten() == 10 || TotaalPunten() == 11)
            {
                return true;
            }
            return false;
        }


        public void SaldoBijschrijven(double Inzet)
        {
            saldo += Inzet;
        }

        public void SaldoAfschrijven(double Inzet)
        {
            saldo -= Inzet;
        }

        public void HitControle(Kaarten bank, List<int> Totaal)
        {
            while ( bank.TotaalPunten(Totaal) < 17)
            {
                bank.NieuweKaart(listKaarten, listPunten);
            }
        }

    }
}
