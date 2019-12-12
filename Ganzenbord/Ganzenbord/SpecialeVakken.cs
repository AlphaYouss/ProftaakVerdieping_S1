using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    class SpecialeVakken
    {
        public Dobbelsteen dobbelsteen { get; private set; }
        public int worp { get; private set; } 
        public SpecialeVakken(Dobbelsteen dobbelsteen)
        {
            worp = dobbelsteen.worpTotaal;
            this.dobbelsteen = dobbelsteen;
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
