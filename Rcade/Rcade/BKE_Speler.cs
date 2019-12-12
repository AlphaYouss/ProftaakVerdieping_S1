using System;
using Windows.UI.Xaml.Media.Imaging;

namespace Rcade
{
    class BKE_Speler
    {
        public BKE_Veld veld { get; private set; }
        public BitmapImage plaatjeSpeler { get; private set; } = new BitmapImage(new Uri("ms-appx:///Assets/Fotos/Dikke x.png"));
        public string naamSpeler { get; private set; } = "Goebles";
        public int scoreSpeler { get; private set; } = 0;

        public BKE_Speler(BKE_Veld veld)
        {
            this.veld = veld;
        }

        public void ZetStapSpeler(int vak)
        {
            veld.Velden[vak] = "X";
        }

        public void SetScoreSpeler(int score)
        {
            scoreSpeler += score;
        }

        public void SetScoreSpelerZero()
        {
            if (scoreSpeler < 0)
            {
                scoreSpeler = 0;
            }
        }
    }
}
