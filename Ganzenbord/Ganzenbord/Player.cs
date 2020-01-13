using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Ganzenbord
{
    class Player
    {
        public Board bord { get; private set; }
        public Dice dice { get; private set; }
        public SpecialFields specialFields { get; private set; }
        public string playerName { get; private set; }
        public BitmapImage playerImage { get; private set; }
        public int location { get; private set; }
        public bool skipTurn { get; private set; }
        public bool stuckInWell_Prison { get; private set; }
        public bool winGame { get; private set; } 
        public Player(Board board, Dice dice, SpecialFields specialFields, BitmapImage playerImage)
        {
            this.playerImage = playerImage;
            this.specialFields = specialFields;
            this.dice = dice;
            this.bord = board;
            location = 0;
            skipTurn = false;
            stuckInWell_Prison = false;
            winGame = false;
        }

        public string PlayerMove()
        {
            dice.XD6(2);
            if (location == 0 && dice.ThrowCount == 9)
            {
                location = 26;
                return "NineOnFirstTurn";
            }
            else
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
            }
            return "";
        }

        public void RevertLocation()
        {
            location = location - dice.ThrowCount;
        }

        public void EventStart(string Event)
        {
            switch (Event)
            {
                default:
                    break;
                case "brug":
                  location = specialFields.BurgEvent(location);
                    break;
                case "herberg":
                   skipTurn = specialFields.HerbergEvent();
                    break;
                case "put":
                   stuckInWell_Prison = specialFields.PutEvent();
                    break;
                case "doolhof":
                   location = specialFields.DoolhofEvent(location);
                    break;
                case "gevangenis":
                    stuckInWell_Prison = specialFields.GevangenisEvent();
                    break;
                case "dood":
                   location = specialFields.DoodEvent(location);
                    break;
                case "einde":
                   winGame = specialFields.EindeEvent();
                    break;
                case "dubbeleworp":
                   location = specialFields.DubbelWorp(location);
                    break;
            }
        }

        public void Restart()
        {
            location = 0;
        }

        public void ChangeStuckInWell_Prison()
        {
            stuckInWell_Prison = false;
        }

        public void ChangeSkipTurn()
        {
            skipTurn = false;
        }

        public void ChangeLocation(int getal)
        {
            location = location + getal;
        }
    }
}
