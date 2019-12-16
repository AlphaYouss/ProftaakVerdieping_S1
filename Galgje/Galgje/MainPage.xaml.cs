using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Galgje
{

    public sealed partial class MainPage : Page
    {
        Hangman host = new Hangman();
        public char letter { get; private set; }
        List<string> Numbers = new List<string> { "number0", "number1", "number2", "number3", "number4", "number5", "number6", "number7", "number8", "number9", "number10", "number11" };
        List<Button> Buttons = new List<Button> {};



        public MainPage()
        {
            this.InitializeComponent();
            AddButtons();
            Start();

        }






        // Start
        private void Start()
        {
            NewGameBtn.Visibility = Visibility.Collapsed;
            host.start();
            UpdateDisplay();
        }


        private void AddButtons()
        {
            Buttons.Add(A);
            Buttons.Add(B);
            Buttons.Add(C);
            Buttons.Add(D);
            Buttons.Add(E);
            Buttons.Add(F);
            Buttons.Add(G);
            Buttons.Add(H);
            Buttons.Add(I);
            Buttons.Add(J);
            Buttons.Add(K);
            Buttons.Add(L);
            Buttons.Add(M);
            Buttons.Add(N);
            Buttons.Add(O);
            Buttons.Add(P);
            Buttons.Add(Q);
            Buttons.Add(R);
            Buttons.Add(S);
            Buttons.Add(T);
            Buttons.Add(U);
            Buttons.Add(V);
            Buttons.Add(W);
            Buttons.Add(X);
            Buttons.Add(Y);
            Buttons.Add(Z);
        }






        // Update gegevens tijdens spel
        private void UpdateDisplay()
        {
            TbLetterDisplay.Text = new String(host.displayedLetters);
            TbGuessedLetters.Text = new String(host.guessedLetters.ToArray());
            UpdateImage(HangmanImage);
            TbResult.Text = host.Result;

            if (host.player.score != 0)
            {
                TbScore.Text = "Score: " + Convert.ToString(host.player.score);
            }
        }






        //Het 'toetsenbord'
        private void Alphabet_Click(object sender, RoutedEventArgs e)
        {
            char letter = Convert.ToChar(((Control)sender).Name);

            Button button = sender as Button;
            button.IsEnabled = false;

            host.CheckLetters(letter);
            UpdateDisplay();

            if (host.WinCheck() || host.EndGameCheck())
            {
                EndGame();
            }
        }






        //Einde van het spel
        private void EndGame()
        {
            TbResult.Text = host.Result;
            NewGameBtn.Visibility = Visibility.Visible;

            host.player.SetScore();
            TbScore.Text = "Score: " + Convert.ToString(host.player.score);

            host.player.ClearTurn();
            host.Clear();

            Buttons.ForEach(x => x.IsEnabled = false);         
        }






        // Images
        private void UpdateImage(Image image)
        {
            string Location = "ms-appx:///Assets/Numbers/" + Numbers[host.player.turn] + ".jpg";
            BitmapImage ImageSource = new BitmapImage(new Uri(Location));
            image.Source = ImageSource;
        }






        // New Game
        private void NewGameBtn_Click(object sender, RoutedEventArgs e)
        {
            NewGameBtn.Visibility = Visibility.Collapsed;
            Buttons.ForEach(x => x.IsEnabled = true);
            Start();
        }
    }
}
