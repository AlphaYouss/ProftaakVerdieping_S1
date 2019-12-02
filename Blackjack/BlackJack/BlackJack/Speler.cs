using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Speler
    {
        public List<string> spelerKaarten = new List<string>();
        public List<int> spelerPunten = new List<int>();
        public double saldo = 2000;


        //Start
        public string GetKaarten()
        {
            string Kaart = "";
            for (int i = 0; i < spelerKaarten.Count; i++)
            {
                Kaart = Kaart + "    " + spelerKaarten[i];
            }
            return Kaart;
        }

        //Hit
        public int TotaalPunten()
        {
            int totaal = 0;

            for (int i = 0; i < spelerPunten.Count; i++)
            {
                totaal += spelerPunten[i];
            }
            return totaal;
        }

        public bool Aas()
        {
            if (spelerPunten.Contains(11))
            {
                return true;
            }
            return false;
        }


        public bool BustControle()
        {
            if (TotaalPunten() >21)
            {
                return true;
            }
            return false;
        }



        //Stand
        public void HitControle(Kaarten bank)
        {
            while (TotaalPunten() < 17)
            {
                bank.NieuweKaart(spelerPunten, spelerKaarten);
            }
        }


        public void SaldoBijschrijven(double Inzet)
        {
            saldo += Inzet;
        }

        public void SaldoAfschrijven(double Inzet)
        {
            saldo -= Inzet;
        }


        /*        public bool DoubleDownControle()
        {
            if (TotaalPunten() == 9 || TotaalPunten() == 10 || TotaalPunten() == 11)
            {
                return true;
            }
            return false;
        }    */
    }
}
