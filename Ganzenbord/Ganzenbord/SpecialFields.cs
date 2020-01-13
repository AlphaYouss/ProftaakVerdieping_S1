using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    class SpecialFields
    {
        public Ganzenbord ganzenbord { get; private set; }
        public Board board { get; private set; }
        public Dice dice { get; private set; }
        public int Throw { get; private set; } 
        public SpecialFields(Dice dice)
        {
            this.board = board;
            this.dice = dice;
            Throw = dice.ThrowCount;
            
        }

        public int DubbelWorp(int location)
        {
            location = location + dice.ThrowCount;
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

        public int BurgEvent(int locatie)
        {
            dice.ChangeThrowCount(6);
            return locatie = 12;

        }

        public bool HerbergEvent()
        {
            return true;
        }

        public bool PutEvent()
        {
            return true;
        }

        public int DoolhofEvent(int locatie)
        {
            dice.ChangeThrowCount(-5);
            return locatie = 37;
        }

        public bool GevangenisEvent()
        {
            return true;   
        }

        public int DoodEvent(int locatie)
        {
            return locatie = 0;
        }

        public bool EindeEvent()
        {
            return true;
        }

    }
}
