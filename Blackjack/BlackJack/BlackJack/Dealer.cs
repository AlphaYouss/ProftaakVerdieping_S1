using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Dealer
    {
        List<string> EigenKaarten = new List<string>();
        List<int> Punten = new List<int>();
        List<string> Kleuren = new List<string>() { "C", "D", "H", "S" };
        List<string> Plaatjes = new List<string>() { "J", "Q", "K", "A" };
        Random RandomNummer = new Random();
       
        public Dealer()
        {
            Start();  
        }

        public void Start()
        {
            NieuweKaart();
            NieuweKaart();
        }

        public bool InsuranceCheck()
        {
            if (EigenKaarten[1].Contains("A"))
            {
                return true;
            }
            return false;
        }
       
        public Double Insurance(Double Inzet)
        {
            Inzet = Inzet * 1.5;
            return Inzet;
        }

        private void NieuweKaart()
        {
            int IntKaart = RandomNummer.Next(2, 15);
            int x = 0;
            bool gevonden = false;
            string StrKaart = "";

            for (int i = 11; i < 15; i++)
            {
                if (gevonden == false)
                {
                    if (IntKaart == i)
                    {
                        StrKaart = Plaatjes[x] + Kleuren[RandomNummer.Next(0, 4)] + ".jpg";
                        gevonden = true;
                        
                        if (IntKaart == 14)
                        {
                            IntKaart = 11;
                        }
                        else
                        {
                            IntKaart = 10;
                        }         
                    }
                    else
                    {
                        StrKaart = Convert.ToString(IntKaart) + Kleuren[RandomNummer.Next(0, 4)] + ".jpg";
                    }
                }
                x++;
            }
            Punten.Add(IntKaart);
            EigenKaarten.Add(StrKaart);
        }

        public int TotaalPunten()
        {
            int totaal = 0;

            for (int i = 0; i < Punten.Count; i++)
            {
                totaal += Punten[i];
            }
            return totaal;
        }

        public void Clear()
        {
            EigenKaarten.Clear();
            Punten.Clear();
        }

        public bool BustControle()
        {
            if (TotaalPunten() > 21)
            {
                return true;
            }
            return false;
        }

        public string GetKaart(int i)
        {
            string Kaart = EigenKaarten[i];
            return Kaart;
        }

        public string GetKaarten()
        {
            string Kaart = "";
            for (int i = 0; i < EigenKaarten.Count; i++)
            {
                Kaart = Kaart + "        " + EigenKaarten[i];
            }
            return Kaart;
        }

        public void HitControle()
        {
            while (TotaalPunten() < 17)
            {
                NieuweKaart();
            }
        }

    }
}
