using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    class Ganzenbord
    {
        public Dobbelsteen dobbelsteen { get; private set; }
        public Bord bord { get; private set; }
        public List<Speler> spelers { get; private set; }
        public Speler speler1 { get; private set; }
        public Speler speler2 { get; private set; }
        public Speler speler3 { get; private set; }
        public Speler speler4 { get; private set; }
        public Speler speler5 { get; private set; }
        public int aantalSpelers { get; private set; }
        public int spelerBeurt { get; private set; }
        public bool tweeSpelersOpVak { get; private set; }

        public Ganzenbord(int aantalSpelers)
        {
            dobbelsteen = new Dobbelsteen();
            bord = new Bord(dobbelsteen);
            speler1 = new Speler(bord, dobbelsteen, bord.specialevakken);
            speler2 = new Speler(bord, dobbelsteen, bord.specialevakken);
            speler3 = new Speler(bord, dobbelsteen, bord.specialevakken);
            speler4 = new Speler(bord, dobbelsteen, bord.specialevakken);
            speler5 = new Speler(bord, dobbelsteen, bord.specialevakken);

            spelers = new List<Speler>();
            spelerBeurt = 0;
            this.aantalSpelers = aantalSpelers;

            tweeSpelersOpVak = false;

            VulSpelerList();
            bord.BordGenereren();
            
        }
        
        public void ZetStap()
        {
            spelers[spelerBeurt].ZetStap();
            for (int i = 0; i < spelers.Count; i++)
            {
                if (CheckSpelersOpVak(spelers[spelerBeurt].locatie))
                {
                    spelers[spelerBeurt].RevertLocatie();
                }
                else
                {
                    CheckVak(spelers[spelerBeurt].locatie);
                }
            }
        }

        public void VulSpelerList()
        {
            for (int i = 1; i <= aantalSpelers; i++)
            {
                switch (i)
                {
                    default:
                        break;
                    case 1:
                        spelers.Add(speler1);
                        break;
                    case 2:
                        spelers.Add(speler2);
                        break;
                    case 3:
                        spelers.Add(speler3);
                        break;
                    case 4:
                        spelers.Add(speler4);
                        break;
                    case 5:
                        spelers.Add(speler5);
                        break;
                }
            }
        }

        public bool CheckSpelersOpVak(int locatie)
        {
            for (int i = 0; i < spelers.Count; i++)
            {
                if (spelers[i].locatie == locatie && spelers[i] != spelers[spelerBeurt])
                {
                    return true;
                }
            }
            return false;
        }

        public void CheckVak(int locatie)
        {       
            string vak = bord.vakken[locatie];
            if (vak != null)
            {
                spelers[spelerBeurt].EventStart(vak);
                if (CheckSpelersOpVak(spelers[spelerBeurt].locatie))
                {
                    spelers[spelerBeurt].RevertLocatie();
                }
            }
        }

        public void VolgendeSpeler()
        {
            spelerBeurt++;
            if (spelerBeurt == aantalSpelers + 1)
            {
                dobbelsteen.ResetWorp();
                spelerBeurt = 0;
            }
        }

        public bool CheckBeurtOverslaan()
        {
            if (spelers[spelerBeurt].beurtOverslaan)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool WinCheck()
        {
            if (spelers[spelerBeurt].winst)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckPut_Gevangenis()
        {
            return true;
        }

        public void Restart()
        {
            for (int i = 1; i < spelers.Count; i++)
            {
                spelers[i].Restart();
            }
        }
    }
}
