using Windows.UI.Xaml.Media.Imaging;

namespace Rcade
{
    class GB_Player
    {
        public GB_Board bord { get; private set; }
        public GB_Dice dice { get; private set; }
        public GB_SpecialFields specialFields { get; private set; }
        public BitmapImage playerImage { get; private set; }
        public int location { get; private set; }
        public bool skipTurn { get; private set; }
        public bool stuckInWellPrison { get; private set; }
        public string field { get; private set; }
        public bool winGame { get; private set; }

        public GB_Player(GB_Board board, GB_Dice dice, GB_SpecialFields specialFields, BitmapImage playerImage)
        {
            this.playerImage = playerImage;
            this.specialFields = specialFields;
            this.dice = dice;

            bord = board;
            location = 0;

            skipTurn = false;
            stuckInWellPrison = false;
        }

        public string PlayerMove()
        {
            dice.XD6(2);
            if (location == 0 && dice.throwCount == 9)
            {
                location = 26;

                field = "NineOnFirstTurn";
                return "NineOnFirstTurn";
            }
            else
            {
                location = location + dice.throwCount;

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
            if (field == "NineOnFirstTurn")
            {
                location = location - 26;
            }
            else
            {
                location = location - dice.throwCount;
            }
        }

        public void EventStart(string Event)
        {
            switch (Event)
            {
                default:
                    break;
                case "brug":
                    location = specialFields.BridgeEvent(location);
                    break;
                case "herberg":
                    skipTurn = specialFields.InnEvent();
                    break;
                case "put":
                    stuckInWellPrison = specialFields.WellEvent();
                    break;
                case "doolhof":
                    location = specialFields.MazeEvent(location);
                    break;
                case "gevangenis":
                    stuckInWellPrison = specialFields.PrisonEvent();
                    break;
                case "dood":
                    location = specialFields.DeathEvent(location);
                    break;
                case "einde":
                    winGame = specialFields.EndEvent();
                    break;
                case "dubbeleworp":
                    location = specialFields.DoubleThrow(location);
                    break;
            }
        }

        public void Restart()
        {
            location = 0;
        }

        public void ChangeStuckInWellPrison()
        {
            stuckInWellPrison = false;
        }

        public void ChangeSkipTurn()
        {
            skipTurn = false;
        }

        public void ChangeLocation(int number)
        {
            location = location + number;
        }
    }
}