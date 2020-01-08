using System;

namespace Roulette
{
    class RL
    {
        public RL_Wheel wheel { get; private set; }
        public RL_Player player { get; private set; }
        public int multiplier { get; private set; }
        public enum chips { Fifty = 50, OneHundred = 100, TwoHundred = 200, FiveHundred = 500 }
        public enum numbers { btnZero = 0, btnOne = 1, btnTwo = 2, btnThree = 3, btnFour = 4, btnFive = 5, btnSix = 6, btnSeven = 7, btnEight = 8, btnNine = 9, btnTen = 10, btnEleven = 11, btnTwelve = 12, btnThirteen = 13, btnFourteen = 14, btnFifteen = 15, btnSixteen = 16, btnSeventeen = 17, btnEighteen = 18, btnNineteen = 19, btnTwenty = 20, btnTwentyone = 21, btnTwentytwo = 22, btnTwentythree = 23, btnTwentyfour = 24, btnTwentyfive = 25, btnTwentysix = 26, btnTwentyseven = 27, btnTwentyeight = 28, btnTwentynine = 29, btnThirty = 30, btnThirtyone = 31, btnThirtytwo = 32, btnThirtythree = 33, btnThirtyfour = 34, btnThirtyfive = 35, btnThirtysix = 36 }
        public enum colors { btnRed = 0, btnBlack = 1 };
        public enum bets { btnEven = 0, btnOdd = 1 };
        public enum halves { btnFirstEighteen = 0, btnLastEighteen = 1 };
        public enum columns { btnFirstTwelve = 0, btnSecondTwelve = 1, btnThirdTwelve = 2 };
        public enum rows { btnFirstRow = 0, btnSecondRow = 1, btnThirdRow = 2 };

        public RL()
        {
            wheel = new RL_Wheel();
            player = new RL_Player();
        }

        public void SpinWheel()
        {
            wheel.Spin();
        }

        public void PlaceBet(string buttonName, int type, int amount)
        {
            string value = "";
            int number = 0;

            switch (type)
            {
                case 0:
                    int selectedNumber = Convert.ToInt32((numbers)Enum.Parse(typeof(numbers), buttonName));
                    value = selectedNumber.ToString();
                    break;
                case 1:
                    number = Convert.ToInt32((columns)Enum.Parse(typeof(columns), buttonName));

                    value = GetColumn(number);
                    break;
                case 2:
                    number = Convert.ToInt32((rows)Enum.Parse(typeof(rows), buttonName));

                    value = GetRow(number);
                    break;
                case 3:
                    number = Convert.ToInt32((halves)Enum.Parse(typeof(halves), buttonName));

                    value = GetHalves(number);
                    break;
                case 4 :
                    number = Convert.ToInt32((bets)Enum.Parse(typeof(bets), buttonName));

                    value = GetBet(number);
                    break;
                case 5:
                    number = Convert.ToInt32((colors)Enum.Parse(typeof(colors), buttonName));

                    value = GetColor(number);
                    break;
            }
            player.PlaceBet(value, amount);
        }

        private string GetColumn(int number)
        {
            string name = "";
            switch (number)
            {
                case 0:
                    name = "1st 12";
                    break;
                case 1:
                    name = "2nd 12";
                    break;
                case 2:
                    name = "3rd 12";
                    break;
            }
            return name;
        }

        private string GetRow(int number)
        {
            string name = "";
            switch (number)
            {
                case 0:
                    name = "1st row";
                    break;
                case 1:
                    name = "2nd row";
                    break;
                case 2:
                    name = "3rd row";
                    break;
            }
            return name;
        }

        private string GetHalves(int number)
        {
            string name = "";
            switch (number)
            {
                case 0:
                    name = "1-18";
                    break;
                case 1:
                    name = "19-36";
                    break;
            }
            return name;
        }

        private string GetBet(int number)
        {
            string name = "";
            switch (number)
            {
                case 0:
                    name = "Even";
                    break;
                case 1:
                    name = "Odd";
                    break;
            }
            return name;
        }

        private string GetColor(int number)
        {
            string name = "";
            switch (number)
            {
                case 0:
                    name = "Red";
                    break;
                case 1:
                    name = "Black";
                    break;
            }
            return name;
        }
    }
}