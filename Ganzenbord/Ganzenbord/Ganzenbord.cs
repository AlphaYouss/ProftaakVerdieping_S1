using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

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

        public List<Image> vakimages { get; private set; }
        public BitmapImage pionPaars { get; private set; }
        public BitmapImage pionBlauw { get; private set; }
        public BitmapImage pionGroen { get; private set; }
        public BitmapImage pionRood { get; private set; }
        public BitmapImage pionZwart { get; private set; }
        public BitmapImage leegPlaatje { get; private set; } 

        public int aantalSpelers { get; private set; }
        public int spelerBeurt { get; private set; }

        public Ganzenbord(int aantalSpelers, List<Image> vakimages)
        {
            dobbelsteen = new Dobbelsteen();
            bord = new Bord(dobbelsteen);

            this.vakimages = vakimages;

            leegPlaatje = new BitmapImage(new Uri("ms-appx:///"));
            pionPaars = new BitmapImage(new Uri("ms-appx:///Assets/pion paars.png"));
            pionBlauw = new BitmapImage(new Uri("ms-appx:///Assets/pion blauw.png"));
            pionGroen = new BitmapImage(new Uri("ms-appx:///Assets/pion groen.png"));
            pionRood = new BitmapImage(new Uri("ms-appx:///Assets/pion rood.png"));
            pionZwart = new BitmapImage(new Uri("ms-appx:///Assets/pion zwart.png"));

            spelers = new List<Speler>();

            speler1 = new Speler(bord, dobbelsteen, bord.specialevakken, pionPaars);
            speler2 = new Speler(bord, dobbelsteen, bord.specialevakken, pionBlauw);
            speler3 = new Speler(bord, dobbelsteen, bord.specialevakken, pionGroen);
            speler4 = new Speler(bord, dobbelsteen, bord.specialevakken, pionRood);
            speler5 = new Speler(bord, dobbelsteen, bord.specialevakken, pionZwart);

            spelerBeurt = 0;

            this.aantalSpelers = aantalSpelers;

            VulSpelerList();
            bord.BordGenereren();
        }
        
        public void ZetStap()
        {
            vakimages[spelers[spelerBeurt].locatie].Source = leegPlaatje;
            spelers[spelerBeurt].ZetStap();
            if (CheckSpelersOpVak(spelers[spelerBeurt].locatie))
            {
                spelers[spelerBeurt].RevertLocatie();
            }
            else
            {
                CheckVak(spelers[spelerBeurt].locatie);
            }
            vakimages[spelers[spelerBeurt].locatie].Source = spelers[spelerBeurt].spelerPlaatje;
        }

        private void VulSpelerList()
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

        private bool CheckSpelersOpVak(int locatie)
        {
            for (int i = 0; i < spelers.Count; i++)
            {
                if (spelers[i].locatie == locatie && spelers[i] != spelers[spelerBeurt] && locatie != 0 )
                {
                    spelers[spelerBeurt].ChangeBeurtOverslaan();
                    return true;
                }
            }
            return false;
        }

        private void CheckVak(int locatie)
        {       
            string vak = bord.vakken[locatie];
            if (vak != null)
            {
                spelers[spelerBeurt].EventStart(vak);
                if (CheckPut_Gevangenis())
                {

                }
                else if (CheckSpelersOpVak(spelers[spelerBeurt].locatie))
                {
                    spelers[spelerBeurt].RevertLocatie();
                }

                if (WinCheck())
                {
                    Restart();
                }
            }
        }

        public void VolgendeSpeler()
        {
            spelerBeurt++;
            if (spelerBeurt == aantalSpelers)
            {
                
                spelerBeurt = 0;
            }
            dobbelsteen.ResetWorp();
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
        public bool CheckInDePut_Gevangenis()
        {
            if (spelers[spelerBeurt].inDePut_Gevangenis)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool WinCheck()
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

        private bool CheckPut_Gevangenis()
        {
            for (int i = 0; i < spelers.Count; i++)
            {
                if(spelers[spelerBeurt].inDePut_Gevangenis == spelers[i].inDePut_Gevangenis && spelers[i] != spelers[spelerBeurt])
                {
                    spelers[i].ChangeInDePut_Gevangenis();
                    return true;
                }
            }
            return false;
        }

        public void Restart()
        {
            for (int i = 1; i < spelers.Count; i++)
            {
                spelers[i].Restart();
            }
        }

        public void ChangeBeurtOverslaan()
        {
            spelers[spelerBeurt].ChangeBeurtOverslaan();
        }
    }
}
