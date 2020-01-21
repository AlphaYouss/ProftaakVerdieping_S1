using System;
using System.Collections.Generic;

namespace Rcade
{
    class BJ_Cards
    {
        private Random randomNumber { get; set; } = new Random();
        private enum colors { C, D, H, S };
        private enum images { J, Q, K, A };

        List<int> list = new List<int> {8,14, 2, 12};
        int y = 0;

        public BJ_Card NewCard()
        {
            if (y == 4)
            {
                y = 0;
            }


            int intCard = list[y];
           
            //int intCard = randomNumber.Next(2, 15);
            //int intCard = 14;
            int x = 0;

            bool foundCard = false;
            string card = "";

            for (int i = 11; i < 15; i++)
            {
                if (foundCard == false)
                {
                    if (intCard == i)
                    {
                        card = Enum.GetName(typeof(images), x) + Enum.GetName(typeof(colors), randomNumber.Next(0, 4)) + ".jpg";
                        foundCard = true;

                        if (intCard != 14)
                        {
                            intCard = 10;
                        }
                    }
                    else
                    {
                        card = Convert.ToString(intCard) + Enum.GetName(typeof(colors), randomNumber.Next(0, 4)) + ".jpg";
                    }
                }
                x++;
            }
            BJ_Card aCard = new BJ_Card(intCard, card);


            y++;

            return aCard;
        }
    }
}