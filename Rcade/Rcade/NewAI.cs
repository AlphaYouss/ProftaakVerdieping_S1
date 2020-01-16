using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Rcade
{
    class NewAI
    {
        TTT_Field field = new TTT_Field();
        string[,] Rows;

        public BitmapImage imageAi { get; private set; } = new BitmapImage(new Uri("ms-appx:///Assets/Images/bke/o.png"));
        public bool FirstMoveDone {  get;  set; }

        public string nameAi { get; private set; } = "Gibby";
        public int scoreAi { get; private set; } = 0;
        public int moveAI { get; private set; }
 


        public NewAI(TTT_Field field)
        {
            this.field = field;

            UpdateRows();
        }



        private void UpdateRows()
        {
            Rows = new string[,]
            {
                {field.box[1], field.box[2], field.box[3]},
                {field.box[4], field.box[5], field.box[6]},
                {field.box[7], field.box[8], field.box[9]},

                {field.box[1], field.box[4], field.box[7]},
                {field.box[2], field.box[5], field.box[8]},
                {field.box[3], field.box[6], field.box[9]},

                {field.box[1], field.box[5], field.box[9]},
                {field.box[3], field.box[5], field.box[7]},
            };
        }



        public void NewMove()
        {
            if (!FirstMoveDone)
            {
                RandomTurn();
                FirstMoveDone = true;
            }

            else
            {
               ForkBlock();
            }
        }
       
        
 
        private void RandomTurn()
        {
                List<int> remainingBoxes = new List<int>();

                for (int i = 1; i < field.box.Count; i++)
                {
                    if (field.box[i] != "X" && field.box[i] != "O")
                    {
                        remainingBoxes.Add(i);
                    }
                }

                int box = GenerateNumber(remainingBoxes.Count, remainingBoxes);

                field.box[box] = "O";
                moveAI = box;
        }



        private int GenerateNumber(int remainingNumbers, List<int> remainingBoxes)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, remainingNumbers);

            return remainingBoxes[number];
        }

        private void Clear()
        {
            Array.Clear(Rows, 0, 24);
        }



        private void ForkBlock()
        {
            Clear();
            UpdateRows();
            int i = 0;
            i = 0;
            int x = 0;
            x = 0;
            bool done = false;


            int Contains = 0;
            int NotContains = 0;


            for ( i = 0; i < Rows.GetLength(0); i++)
            {

                for ( x = 0; x < 3; x++)
                {
                    if (Rows[i, x] == "X" && Rows[i, x] != "O")
                    {
                        Contains++;
                    }
                    else
                    {
                        NotContains++;

                        if (Rows[i, x] != "X" && Rows[i, x] != "O" )
                        {
                            moveAI = Convert.ToInt32(Rows[i, x]);
                        }
                        
                    }

                }

                if (Contains == 2 && field.box[moveAI] != "O")
                {
                    field.box[moveAI] = "O";
                    done = true;
                    break;
                }
                else
                {
                    Contains = 0;
                    NotContains = 0;
                }
            }

            if (!done)
            {
                RandomTurn();
            }
            done = false;
        }







        public void SetScore(int score)
        {
            scoreAi += score;
        }

        public void SetScore()
        {
            if (scoreAi < 0)
            {
                scoreAi = 0;
            }
        }



    }
}
