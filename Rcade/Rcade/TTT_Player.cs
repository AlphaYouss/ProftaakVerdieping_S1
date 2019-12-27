using System;
using Windows.UI.Xaml.Media.Imaging;

namespace Rcade
{
    class TTT_Player
    {
        public TTT_Field field { get; private set; }
        public BitmapImage imagePlayer { get; private set; } = new BitmapImage(new Uri("ms-appx:///Assets/Afbeeldingen/BKE/X.png"));
        public string namePlayer { get; private set; }
        public int scorePlayer { get; private set; } = 0;

        public TTT_Player(TTT_Field field)
        {
            this.field = field;
        }

        public void TakesTurn(int box)
        {
            field.box[box] = "X";
        }

        public void SetScorePlayer(int score)
        {
            scorePlayer += score;
        }

        public void SetScorePlayer()
        {
            if (scorePlayer < 0)
            {
                scorePlayer = 0;
            }
        }
    }
}