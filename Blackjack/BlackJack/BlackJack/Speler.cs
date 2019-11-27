using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Speler
    {
        List<string> EigenKaarten = new List<string>();
        List<int> Punten = new List<int>();
        List<string> Kleuren = new List<string>() { "C", "D", "H", "S" };
        List<string> Plaatjes = new List<string>() { "J", "Q", "K", "A" };
        Random RandomNummer = new Random();
        int Saldo = 5000;

        public Speler()
        {
            Start();
        }

        private void Start()
        {
            NieuweKaart();
            NieuweKaart();
        }

        public void Hit()
        {
            NieuweKaart();
            BustControle();
           // GetKaarten();
            
        }

        public void DoubleDown(int inzet)
        {
            bool gekozen = false;
            if (TotaalPunten() == 9 || TotaalPunten() == 10 || TotaalPunten() == 11)
            {
            //    if (gekozen)
            //    {
                    inzet *= 2;
            //    }  
            }
        }

        private void BustControle()
        {
            if (TotaalPunten() >21)
            {
                Clear();
                Start();
            }
        }


        private void Clear()
        {
            EigenKaarten.Clear();
            Punten.Clear();
        }
       
        public void Stand()
        {
            // Hier komt link naar de WinnaarCheck code  
        }

        public int GetSaldo()
        {
            return Saldo;
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
                        IntKaart = 10;
                    }
                    else if (IntKaart == 14)
                    {
                        // Aas code
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



        public int TotaalPunten()
        {
            int totaal = 0;
            
            for (int i = 0; i < Punten.Count; i++)
            {
                totaal += Punten[i];
            }
            return totaal;
        }

    }
}
