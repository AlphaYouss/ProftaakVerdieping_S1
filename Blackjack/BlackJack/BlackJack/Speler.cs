using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Speler
    {
        private List<string> Azen = new List<string>();
        public List<Kaart> spelerKaarten { get; private set; } = new List<Kaart>();
        public double saldo { get; private set; } = 5000;

        //public List<int> AasPlekken = new List<int>();
        //public int AasPlek { get; private set; }

        //Start
        public void PakKaart(Kaarten bank)
        {
            spelerKaarten.Add(bank.NieuweKaart());
        }

        public string GetKaarten()
        {
            string Kaart = "";
            for (int i = 0; i < spelerKaarten.Count; i++)
            {
                Kaart = Kaart + "    " + spelerKaarten[i].Plaatje;
            }
            return Kaart;
        }

        //Hit
        public int TotaalPunten()
        {
            int totaal = 0;

            for (int i = 0; i < spelerKaarten.Count; i++)
            {
                totaal += spelerKaarten[i].Punt;
            }
            return totaal;
        }


/*
        public bool Aas()
        {
            for (int i = 0; i < spelerKaarten.Count; i++)
            {
                if (spelerKaarten[i].Punt == 11 && !Azen.Contains(spelerKaarten[i].Plaatje))
                {
                    AasPlekken.Add(i);
                    Azen.Add(spelerKaarten[i].Plaatje);
                    return true;
                }          
            }
            return false;
        }
*/
     

        //Stand
        public void HitControle(Kaarten bank)
        {
            while (TotaalPunten() < 17)
            {
                PakKaart(bank);
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


        //Einde
        public void HandLegen()
        {
            spelerKaarten.Clear();
            Azen.Clear();
        }


        public bool InsuranceControle()
        {
            if (spelerKaarten[0].Plaatje.Contains("A"))
            {
                return true;
            }
            return false;
        }



        public bool DoubleDownControle()
        {
            if (TotaalPunten() == 9 || TotaalPunten() == 10 || TotaalPunten() == 11)
            {
                return true;
            }
            return false;
        }    
    }
}
