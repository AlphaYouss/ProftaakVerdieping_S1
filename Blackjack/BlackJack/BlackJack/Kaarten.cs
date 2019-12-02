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
        Random randomNummer = new Random();

        public void NieuweKaart(List<int> listPunten, List<string> listKaarten)
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
                        StrKaart = Convert.ToString(IntKaart) + kleuren[randomNummer.Next(0, 4)] + ".jpg";
                    }
                }
                x++;
            }

            listPunten.Add(IntKaart);
            listKaarten.Add(StrKaart);
        }
    }
}
