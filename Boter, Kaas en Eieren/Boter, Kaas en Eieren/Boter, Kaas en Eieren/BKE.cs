using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media.Imaging;

namespace Boter__Kaas_en_Eieren
{
    class BKE
    {
        // Het veld.
        public List<string> imageBoxen = new List<string>();

        // Speler data.
        public int scoreSpeler = 0;
        public int countTurnsSpeler = 0;
        public string naamSpeler= "Goebles";
        public BitmapImage plaatjeSpeler = new BitmapImage(new Uri("ms-appx:///Assets/Dikke x.jpg"));

        // AI data.
        public int scoreAI = 0;
        public int stapAI = 0;
        public string naamAI = "Stalin";
        public BitmapImage plaatjeAI = new BitmapImage(new Uri("ms-appx:///Assets/Dikke O.jpg"));

        public BKE()
        {
            VeldGenereren();
        }

        public void VeldGenereren()
        {
            for (int i = 0; i < 10; i++)
            {
                imageBoxen.Add("vak" + i);
            }
        }

        public void ZetStapSpeler(int vak)
        {
            imageBoxen[vak] = "X";
        }

        public void ZetStapAI()
        {
            int vak = GenereerNummer();

            if (CheckVak(vak))
            {
                imageBoxen[vak] = "O";
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
            if (imageBoxen[vak] == "X" || imageBoxen[vak] == "O")
            {
                return false;
            }
            else
            {
                return true;              
            }
        }

        public bool WinCheck()
        {
            if (  
                // Horizontaal.  
                   imageBoxen[1] == imageBoxen[2] && imageBoxen[2] == imageBoxen[3]
                || imageBoxen[4] == imageBoxen[5] && imageBoxen[5] == imageBoxen[6]
                || imageBoxen[7] == imageBoxen[8] && imageBoxen[8] == imageBoxen[9]

                  // Verticaal.
                || imageBoxen[1] == imageBoxen[4] && imageBoxen[4] == imageBoxen[7]
                || imageBoxen[2] == imageBoxen[5] && imageBoxen[5] == imageBoxen[8]
                || imageBoxen[3] == imageBoxen[6] && imageBoxen[6] == imageBoxen[9]

                  // Diagonaal.
                || imageBoxen[1] == imageBoxen[5] && imageBoxen[5] == imageBoxen[9]
                || imageBoxen[3] == imageBoxen[5] && imageBoxen[5] == imageBoxen[7]
                )
            {
                return true;
            }
            return false;
        }

        public void ClearVeld()
        {
            imageBoxen.Clear();
            VeldGenereren();
        }
    }
}