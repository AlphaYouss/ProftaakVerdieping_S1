using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    class SpecialeVakken
    {
        public Ganzenbord ganzenbord { get; private set; }
        public Bord bord { get; private set; }
        public Dobbelsteen dobbelsteen { get; private set; }
        public int worp { get; private set; } 
        public SpecialeVakken(Dobbelsteen dobbelsteen)
        {
            this.bord = bord;
            this.dobbelsteen = dobbelsteen;
            worp = dobbelsteen.worpTotaal;
            
        }

        public int DubbelWorp(int locatie)
        {
            locatie = locatie + worp;
            return locatie; 
        }

        public int BurgEvent(int locatie)
        {
            return locatie = 12;
        }

        public bool HerbergEvent()
        {
            return true;
        }

        public bool PutEvent()
        {
            return true;
        }

        public int DoolhofEvent(int locatie)
        {
            return locatie = 37;
        }

        public bool GevangenisEvent()
        {
            return true;   
        }

        public int DoodEvent(int locatie)
        {
            return locatie = 0;
        }

        public bool EindeEvent()
        {
            return true;
        }

    }
}
