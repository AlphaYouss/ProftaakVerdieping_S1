using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Boter__Kaas_en_Eieren
{
    class BKE
    {
        public List<string> ImageBoxen = new List<string>();

        public int stapAI = 0;
        public string naamAI = "Stalin";
        public string tekenAI = "o";
        public BitmapImage plaatje_AI = new BitmapImage(new Uri("ms-appx:///Assets/Dikke O.jpg"));

        public int IDspeler = 0;
        public string naamSpeler= "Geobles";
        public string tekenSpeler = "x";
        public BitmapImage plaatje_Speler = new BitmapImage(new Uri("ms-appx:///Assets/Dikke x.jpg"));


        public int count = 0;
        public BKE()
        {
            VeldGenereren();
        }

        public void VeldGenereren()
        {
            for (int i = 0; i < 10; i++)
            {
                ImageBoxen.Add("vak" + i);
            }
        }

        public void ZetStapSpeler(int vak)
        {
            ImageBoxen[vak] = "X";
        }

        public void ZetStapAI()
        {
            int vak = GenereerNummer();

            if (CheckVak(vak))
            {
                ImageBoxen[vak] = "O";
                stapAI = vak;
            }
            else
            {
                ZetStapAI();
            }
        }

        private int GenereerNummer()
        {
            Random rnd = new Random();
            int vak = rnd.Next(1, 10);
            return vak;
        }

        private bool CheckVak(int vak)
        {
            if (ImageBoxen[vak] == "X" || ImageBoxen[vak] == "O")
            {
                return false;
            }
            else
            {
                return true;              
            }
        }

        public bool WinCheck() // Checken of iemand heeft gewonnen
        {
            if (  //horizontaal  
                   ImageBoxen[1] == ImageBoxen[2] && ImageBoxen[2] == ImageBoxen[3]
                || ImageBoxen[4] == ImageBoxen[5] && ImageBoxen[5] == ImageBoxen[6]
                || ImageBoxen[7] == ImageBoxen[8] && ImageBoxen[8] == ImageBoxen[9]

                  //verticaal
                || ImageBoxen[1] == ImageBoxen[4] && ImageBoxen[4] == ImageBoxen[7]
                || ImageBoxen[2] == ImageBoxen[5] && ImageBoxen[5] == ImageBoxen[8]
                || ImageBoxen[3] == ImageBoxen[6] && ImageBoxen[6] == ImageBoxen[9]

                  //diagonaal
                || ImageBoxen[1] == ImageBoxen[5] && ImageBoxen[5] == ImageBoxen[9]
                || ImageBoxen[3] == ImageBoxen[5] && ImageBoxen[5] == ImageBoxen[7]
                )
            {
                return true;
            }
            return false;
        }

        public void ClearVeld()
        {
            ImageBoxen.Clear();
            VeldGenereren();
        }
    }
}