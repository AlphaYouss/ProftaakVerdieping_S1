using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    class Bord
    {
        public Dictionary<int, string> vakken { get; private set; }
        public List<int> dubbelWorpVakken { get; private set; }
        public Bord()
        {
            vakken = new Dictionary<int, string>();
            dubbelWorpVakken = new List<int>() { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };
        }

       public void BordGenereren()
        {
            for (int i = 0; i < 63; i++)
            { 
                if (dubbelWorpVakken.Contains(i))
                {
                    vakken.Add(i, "dubbeleworp");
                }

                switch (i)
                {
                    default:
                        vakken.Add(i, null);
                        break;
                    case 6:
                        vakken.Add(i, "brug");
                        break;
                    case 19:
                        vakken.Add(i, "herberg");
                        break;
                    case 31:
                        vakken.Add(i, "put");
                        break;
                    case 42:
                        vakken.Add(i, "doolhof");
                        break;
                    case 52:
                        vakken.Add(i, "gevangenis");
                        break;
                    case 58:
                        vakken.Add(i, "dood");
                        break;
                    case 63:
                        vakken.Add(i, "einde");
                        break;
                }
            }
        }
    }
}
