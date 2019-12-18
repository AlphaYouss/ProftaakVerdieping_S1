using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Ganzenbord
{
    class Speler
    {
        public Bord bord { get; private set; }
        public Dobbelsteen dobbelsteen { get; private set; }
        public SpecialeVakken specialevakken { get; private set; }
        public string naamSpeler { get; private set; }
        public BitmapImage spelerPlaatje { get; private set; }
        public int locatie { get; private set; }
        public bool beurtOverslaan { get; private set; }
        public bool inDePut_Gevangenis { get; private set; }
        public bool winst { get; private set; } 
        public Speler(Bord bord, Dobbelsteen dobbelsteen, SpecialeVakken specialevakken, BitmapImage spelerPlaatje)
        {
            this.spelerPlaatje = spelerPlaatje;
            this.specialevakken = specialevakken;
            this.dobbelsteen = dobbelsteen;
            this.bord = bord;
            locatie = 0;
            beurtOverslaan = false;
            inDePut_Gevangenis = false;
            winst = false;
        }

        public void ZetStap()
        {
            dobbelsteen.XD6(2);
            if (locatie == 0 && dobbelsteen.worpTotaal == 9)
            {
                locatie = 26;
            }
            else
            {
                locatie = locatie + dobbelsteen.worpTotaal;
                if (locatie > 63)
                {
                    int getal = 0;
                    getal = locatie - 63;
                    locatie = locatie - getal;      
                }
            }
        }

        public void RevertLocatie()
        {
            locatie = locatie - dobbelsteen.worpTotaal;
        }

        public void EventStart(string Event)
        {
            switch (Event)
            {
                default:
                    break;
                case "brug":
                  locatie = specialevakken.BurgEvent(locatie);
                    break;
                case "herberg":
                   beurtOverslaan = specialevakken.HerbergEvent();
                    break;
                case "put":
                   inDePut_Gevangenis = specialevakken.PutEvent();
                    break;
                case "doolhof":
                   locatie = specialevakken.DoolhofEvent(locatie);
                    break;
                case "gevangenis":
                    inDePut_Gevangenis = specialevakken.GevangenisEvent();
                    break;
                case "dood":
                   locatie = specialevakken.DoodEvent(locatie);
                    break;
                case "einde":
                   winst = specialevakken.EindeEvent();
                    break;
                case "dubbeleworp":
                   locatie = specialevakken.DubbelWorp(locatie);
                    break;
            }
        }

        public void Restart()
        {
            locatie = 0;
        }

        public void ChangeInDePut_Gevangenis()
        {
            inDePut_Gevangenis = false;
        }

        public void ChangeBeurtOverslaan()
        {
            beurtOverslaan = false;
        }
    }
}
