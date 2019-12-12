﻿using System;
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
        public Dobbelsteen dobbelsteen { get; private set; }
        public SpecialeVakken specialevakken { get; private set; }
        public string naamSpeler { get; private set; }
        public BitmapImage spelerPlaatje { get; private set; }
        public int locatie { get; private set; }
        public bool beurtOverslaan { get; private set; } 
        public bool winst { get; private set; } 
        public Speler(Bord bord)
        {
            dobbelsteen = new Dobbelsteen();
            ganzenbord = new Ganzenbord(bord);
            specialevakken = new SpecialeVakken(dobbelsteen);
            this.bord = bord;
            locatie = 0;
            beurtOverslaan = false;
            winst = false;
        }

        public void ZetStap()
        {

            locatie = locatie + dobbelsteen.XD6(2);
            ganzenbord.CheckVak(locatie);
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
                   beurtOverslaan = specialevakken.PutEvent();
                    break;
                case "doolhof":
                   locatie = specialevakken.DoolhofEvent(locatie);
                    break;
                case "gevangenis":
                    beurtOverslaan = specialevakken.GevangenisEvent();
                    break;
                case "dood":
                   locatie = specialevakken.DoodEvent(locatie);
                    break;
                case "einde":
                   winst = specialevakken.EindeEvent();
                    break;
                case "dubbelworp":
                   locatie = specialevakken.DubbelWorp(locatie);
                    break;
            }
        }

        public void Restart()
        {
            locatie = 0;
        }
    }
}
