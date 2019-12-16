using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galgje
{
    class Player
    {
        public int score { get; private set; }
        public int turn { get; private set; } = 0;
        public string playerName { get; private set; }
        private enum ScoreOptions {Ten = 10, Seven = 7, Five = 5, Three = 3, One = 1, Zero = 0 }



        //Start
        public void SetScore()
        {
            if (turn == 1)
            {
                score += Convert.ToInt32(ScoreOptions.Ten);
            }
            else if (turn >= 2 && turn < 4)
            {
                score += Convert.ToInt32(ScoreOptions.Seven);
            }
            else if (turn >= 4 && turn < 6)
            {
                score += Convert.ToInt32(ScoreOptions.Five);
            }
            else if (turn >= 6 && turn < 9)
            {
                score += Convert.ToInt32(ScoreOptions.Three);
            }
            else if (turn >= 9 && turn < 11)
            {
                score += Convert.ToInt32(ScoreOptions.One);
            }
            else if (turn >= 11)
            {
                score += Convert.ToInt32(ScoreOptions.Zero);
            }
        }



        //Change variables
        public void AddTurn()
        {
            turn++;
        }

        public void ResetTurn()
        {
            turn = 0;
        }

        public void SetPlayerName(string name)
        {
            playerName = name;
        }
    }
}
