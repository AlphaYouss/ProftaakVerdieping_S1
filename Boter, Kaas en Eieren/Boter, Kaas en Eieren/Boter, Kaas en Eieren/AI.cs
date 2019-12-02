using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Boter__Kaas_en_Eieren
{
    class AI
    {
        public Veld veld { get; private set; } 
        public int scoreAI { get; private set; } = 0;
        public int stapAI { get; private set; }
        public string naamAI { get; private set; } = "Stalin";
        public BitmapImage plaatjeAI { get; private set; } = new BitmapImage(new Uri("ms-appx:///Assets/Fotos/Dikke O.png"));

        public AI(Veld veld)
        {
            this.veld = veld;
        }
        public void ZetStapAI()
        {
            List<int> temp = new List<int>();

            for (int i = 1; i < veld.Velden.Count; i++)
            {
                if (veld.Velden[i] != "X" && veld.Velden[i] != "O")
                {
                    temp.Add(i);
                }
            }

            int vak = GenereerNummer(temp.Count, temp);

            if (CheckVak(vak))
            {
                veld.Velden[vak] = "O";
                stapAI = vak;
            }
            else
            {
                ZetStapAI();
            }
        }

        private int GenereerNummer(int overgeblevenGetallen, List<int> temp)
        {
            Random rnd = new Random();
            int vak = rnd.Next(1, overgeblevenGetallen);


            return temp[vak];
        }
        private bool CheckVak(int vak)
        {
            if (veld.Velden[vak] == "X" || veld.Velden[vak] == "O")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void SetScoreAIZero(int zero)
        {
            if (scoreAI < 0)
            {
                scoreAI = 0;
            }
        }
        public void SetScoreAI(int score)
        {
            scoreAI += score;
        }
    }
}
