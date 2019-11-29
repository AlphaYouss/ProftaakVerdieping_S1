using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Kaarten
    {
        List<string> kleuren = new List<string>() { "C", "D", "H", "S" };
        List<string> plaatjes = new List<string>() { "J", "Q", "K", "A" };
        List<string> stock = new List<string>();
        Random randomNummer = new Random();

        public void NieuweKaart(List<string> Kaarten, List<int> Punten )
        {
            int IntKaart = randomNummer.Next(2, 15);
            int x = 0;
            bool gevonden = false;
            string StrKaart = "";

            for (int i = 11; i < 15; i++)
            {
                if (gevonden == false)
                {
                    if (IntKaart == i)
                    {
                        StrKaart = plaatjes[x] + kleuren[randomNummer.Next(0, 4)] + ".jpg";
                        gevonden = true;
                        IntKaart = 10;
                    }
                    else if (IntKaart == 14)
                    {
                       // Aas code
                    }
                    else
                    {
                        StrKaart = Convert.ToString(IntKaart) + kleuren[randomNummer.Next(0, 4)] + ".jpg";
                    }
                }
                x++;
            }
            Punten.Add(IntKaart);
            Kaarten.Add(StrKaart);
        }



        public string GetKaart(int i, List<string> Kaarten)
        {
            string Kaart = Kaarten[i];
            return Kaart;
        }


        public string GetKaarten(List<string> Kaarten)
        {
            string Kaart = "";
            for (int i = 0; i < Kaarten.Count; i++)
            {
                Kaart = Kaart + "        " + Kaarten[i];
            }
            return Kaart;
        }

        public int TotaalPunten(List<int> Punten)
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
