using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    class Ganzenbord
    {
        public Bord bord;
        public List<Speler> spelers { get; private set; }
        public SpecialeVakken specialeVakken  { get; private set; }
        public AantalSpelers aantalspelers;
        public int spelerBeurt { get; private set; }
        public bool tweeSpelersOpVak { get; private set; }
        public Speler speler1 { get; private set; }
        public Speler speler2 { get; private set; }
        public Speler speler3 { get; private set; }
        public Speler speler4 { get; private set; }
        public Speler speler5 { get; private set; }


        public Ganzenbord(Bord bord)
        {
            spelers = new List<Speler>();
            spelerBeurt = 1;

            tweeSpelersOpVak = false;

            this.bord = bord;

            speler1 = new Speler(bord);
            speler2 = new Speler(bord);
            speler3 = new Speler(bord);
            speler4 = new Speler(bord);
            speler5 = new Speler(bord);
        }

        public void VulSpelerList()
        {
            for (int i = 0; i < aantalspelers.aantalSpelers; i++)
            {
                switch (aantalspelers.aantalSpelers)
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
        public void CheckVak(int locatie)
        {       
            string vak = bord.vakken[locatie];
            if (tweeSpelersOpVak)
            {
                VolgendeSpeler();
            } else if (vak != null)
            {
                spelers[spelerBeurt].EventStart(vak);
            }
        }

        public void VolgendeSpeler()
        {
            spelerBeurt++;
            if (spelerBeurt == 6)
            {
                spelerBeurt = 1;
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
