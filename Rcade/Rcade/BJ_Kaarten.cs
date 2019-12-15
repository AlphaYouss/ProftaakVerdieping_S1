using System;

namespace Rcade
{
    class BJ_Kaarten
    {
        public Random randomNummer { get; private set; } = new Random();
        enum kleuren { C, D, H, S };
        enum plaatjes { J, Q, K, A };

        public BJ_Kaart NieuweKaart()
        {
            int intKaart = randomNummer.Next(2, 15);
            int x = 0;

            bool gevonden = false;
            string strKaart = "";

            for (int i = 11; i < 15; i++)
            {
                if (gevonden == false)
                {
                    if (intKaart == i)
                    {
                        strKaart = Enum.GetName(typeof(plaatjes), x) + Enum.GetName(typeof(kleuren), randomNummer.Next(0, 4)) + ".jpg";
                        gevonden = true;

                        if (intKaart != 14)
                        {
                            intKaart = 10;
                        }
                    }
                    else
                    {
                        strKaart = Convert.ToString(intKaart) + Enum.GetName(typeof(kleuren), randomNummer.Next(0, 4)) + ".jpg";
                    }
                }
                x++;
            }

            BJ_Kaart DeKaart = new BJ_Kaart(intKaart, strKaart);
            return DeKaart;
        }
    }
}
