using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galgje
{
    class Hangman
    {
        public Player player = new Player();

        public char[] correctLetters { get; private set; }
        public char[] displayedLetters { get; private set; }
        public string word { get; private set; }
        public List<char> guessedLetters { get; private set; } = new List<char>();
        public string Result { get; private set; } = "";
        





        //Start
        public void start()
        {
            GenerateWord();
            ClearDisplayLetters();
        }


        public void GenerateWord()
        { 
            string word = "FEEST";
            SplitWord(word);
        }


        private void SplitWord(string word)
        {
            correctLetters = word.ToCharArray();
            displayedLetters = new char[correctLetters.Length];
        }






        // Clear
        private void ClearDisplayLetters()
        {
            for (int i = 0; i < displayedLetters.Length; i++)
            {
                displayedLetters[i] = '-';
            }
        }


        public void Clear()
        {
            Array.Clear(correctLetters, 0, correctLetters.Length);
            ClearDisplayLetters();
            guessedLetters.Clear();
            word = "";
            Result = "";
        }






        // Controles
        public void CheckLetters(char letter)
        {
            bool ContainsLetter = false;

            for (int i = 0; i < correctLetters.Length; i++)
            {
                if (letter == correctLetters[i])
                {
                    displayedLetters[i] = letter;
                    ContainsLetter = true;
                }
            }

            if (!ContainsLetter && !guessedLetters.Contains(letter))
            {
                guessedLetters.Add(letter);
                player.AddTurn();
            }
        }


        public bool WinCheck()
        {
            int x = 0;
            for (int i = 0; i < correctLetters.Length; i++)
            {
                if (correctLetters[i] == displayedLetters[i])
                {
                    x++;
                }

                if (x == correctLetters.Length)
                {
                    Result = "Je hebt gewonnen!";
                    return true;
                }
            }
            return false;
        }


        public bool EndGameCheck()
        {
            if (player.turn == 11)
            {
                Result = "Je hebt verloren!";
                return true;
            }

            return false;
        }
    }
}
