using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rcade
{
    class GB_SpecialFields
    {
        public GB ganzenbord { get; private set; }
        public GB_Board board { get; private set; }
        public GB_Dice dice { get; private set; }
        public GB_SpecialFields(GB_Dice dice)
        {
            this.board = board;
            this.dice = dice;
        }

        public int DoubleThrow(int location)
        {
            location = location + dice.ThrowCount;
            dice.ChangeThrowCount(dice.ThrowCount);
            if (location > 63)
            {
                int number = 0;
                number = location - 63;
                location = 63;
                location = location - number;
                dice.ChangeThrowCount(-number);
            }
            return location;
        }

        public int BridgeEvent(int locatie)
        {
            dice.ChangeThrowCount(6);
            return locatie = 12;

        }

        public bool InnEvent()
        {
            return true;
        }

        public bool WellEvent()
        {
            return true;
        }

        public int MazeEvent(int locatie)
        {
            dice.ChangeThrowCount(-5);
            return locatie = 37;
        }

        public bool PrisonEvent()
        {
            return true;
        }

        public int DeathEvent(int locatie)
        {
            return locatie = 0;
        }

        public bool EndEvent()
        {
            return true;
        }
    }
}
