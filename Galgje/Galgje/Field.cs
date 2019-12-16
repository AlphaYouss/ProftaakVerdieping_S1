using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galgje
{

    class Field
    {
        public string HangmanImage { get; private set; }


        private void GenerateField()
        {

        }

        public void UpdateField(Hangman hangman)
        {
           // HangmanImage = "Hangman" + hangman.guessedLetters.Count + ".jpg";

          //  hangman.displayedLetters = new char[hangman.correctLetters.Length];


            for (int i = 0; i < hangman.displayedLetters.Length; i++)
            {
                if (hangman.displayedLetters[i] != '-')
                {

                }
            }
        }
    }
}
