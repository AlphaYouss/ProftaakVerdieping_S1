using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Kaart
    {
        public int Punt { get; private set;}
        public string Plaatje { get; private set;}

        public Kaart(int GegevenPunt, string GegevenKaart)
        {
            Punt = GegevenPunt;
            Plaatje = GegevenKaart;
        }
        public void ChangeToOne()
        {
           Punt = 1;
        }
    }
}
