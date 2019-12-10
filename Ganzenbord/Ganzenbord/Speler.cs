using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Ganzenbord
{
    class Speler
    {
        public Ganzenbord ganzenbord { get; private set; }
        public Bord bord { get; private set; }
        public bool beurt { get; private set; }
        public string naamSpeler { get; private set; }
        public BitmapImage spelerPlaatje { get; private set; }
        public int locatie { get; private set; }

        public Speler(Bord bord)
        {
            ganzenbord = new Ganzenbord();
            this.bord = bord;
            locatie = 0;
        }

        private void ZetStap(int locatie)
        {

            locatie = locatie + ganzenbord.Dobbellen();
        }
    }
}
