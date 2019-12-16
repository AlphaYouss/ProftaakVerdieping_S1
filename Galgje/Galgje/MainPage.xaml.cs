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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Galgje
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Hangman host = new Hangman();
        public char letter { get; private set; }
        public MainPage()
        {
            this.InitializeComponent();
            Start();
        }

        private void UpdateDisplay()
        {
            string Display = "";

            for (int i = 0; i < host.displayedLetters.Length; i++)
            {
                Display = Display + Convert.ToString(host.displayedLetters[i]);
            }
            LetterDisplay.Text = Display;
        }


        private void Start()
        {  
            host.start();
        }

        private void LetterButton_Click(object sender, RoutedEventArgs e)
        {
            letter = Convert.ToChar(LetterInput.Text);
            host.CheckLetters(letter);
            UpdateDisplay();
            host.player.AddTurn();
        }
    }
}
