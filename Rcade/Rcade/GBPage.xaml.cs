﻿using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rcade
{
    public sealed partial class GBPage : Page
    {
        private List<Image> boxImages { get; set; } = new List<Image> { };
        private GB gb { get; set; }
        private User user { get; set; }
        public string Spelernaam1 { get; private set; }
        public string Spelernaam2 { get; private set; }
        public string Spelernaam3 { get; private set; }
        public string Spelernaam4 { get; private set; }
        public string Spelernaam5 { get; private set; }

        public GBPage(int aantalSpelers, string Spelernaam2, string Spelernaam3, string Spelernaam4, string Spelernaam5)
        {
            InitializeComponent();

            gb = new GB(aantalSpelers, boxImages);

            this.Spelernaam2 = Spelernaam2;
            this.Spelernaam3 = Spelernaam3;
            this.Spelernaam4 = Spelernaam4;
            this.Spelernaam5 = Spelernaam5;

            Speler2.Text = Spelernaam2;
            Speler3.Text = Spelernaam3;
            Speler4.Text = Spelernaam4;
            Speler5.Text = Spelernaam5;

            VulImages();
        }

        private void VulImages()
        {
            boxImages.Add(vak0);
            boxImages.Add(vak1);
            boxImages.Add(vak2);
            boxImages.Add(vak3);
            boxImages.Add(vak4);
            boxImages.Add(vak5);
            boxImages.Add(vak6);
            boxImages.Add(vak7);
            boxImages.Add(vak8);
            boxImages.Add(vak9);
            boxImages.Add(vak10);

            boxImages.Add(vak11);
            boxImages.Add(vak12);
            boxImages.Add(vak13);
            boxImages.Add(vak14);
            boxImages.Add(vak15);
            boxImages.Add(vak16);
            boxImages.Add(vak17);
            boxImages.Add(vak18);
            boxImages.Add(vak19);
            boxImages.Add(vak20);

            boxImages.Add(vak21);
            boxImages.Add(vak22);
            boxImages.Add(vak23);
            boxImages.Add(vak24);
            boxImages.Add(vak25);
            boxImages.Add(vak26);
            boxImages.Add(vak27);
            boxImages.Add(vak28);
            boxImages.Add(vak29);
            boxImages.Add(vak30);

            boxImages.Add(vak31);
            boxImages.Add(vak32);
            boxImages.Add(vak33);
            boxImages.Add(vak34);
            boxImages.Add(vak35);
            boxImages.Add(vak36);
            boxImages.Add(vak37);
            boxImages.Add(vak38);
            boxImages.Add(vak39);
            boxImages.Add(vak40);

            boxImages.Add(vak41);
            boxImages.Add(vak42);
            boxImages.Add(vak43);
            boxImages.Add(vak44);
            boxImages.Add(vak45);
            boxImages.Add(vak46);
            boxImages.Add(vak47);
            boxImages.Add(vak48);
            boxImages.Add(vak49);
            boxImages.Add(vak50);

            boxImages.Add(vak51);
            boxImages.Add(vak52);
            boxImages.Add(vak53);
            boxImages.Add(vak54);
            boxImages.Add(vak55);
            boxImages.Add(vak56);
            boxImages.Add(vak57);
            boxImages.Add(vak58);
            boxImages.Add(vak59);
            boxImages.Add(vak60);

            boxImages.Add(vak61);
            boxImages.Add(vak62);
            boxImages.Add(vak63);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Eventvak.Text = "Dobbellen...";
            //Task.Delay(2000).Wait();

            gb.PlayerMove();

            switch (gb.field)
            {
                default:
                    Eventvak.Text = "";
                    break;
                case "brug":
                    Eventvak.Text = SelecteerSpeler(gb.playerTurn) + ", landed on a bridge! You have been moved to field 12.";
                    break;
                case "herberg":
                    Eventvak.Text = SelecteerSpeler(gb.playerTurn) + ", you're staying at an inn for tonight. You have to skip your next turn.";
                    break;
                case "put":
                    Eventvak.Text = SelecteerSpeler(gb.playerTurn) + ", you are stuck in a well. You have to stay here untill someone gets you out or untill you climb out in 3 turns";
                    break;
                case "doolhof":
                    Eventvak.Text = SelecteerSpeler(gb.playerTurn) + ", you were lost in a maze. You are moved back to field 37.";
                    break;
                case "gevangenis":
                    Eventvak.Text = SelecteerSpeler(gb.playerTurn) + ", you're in prison! You have to stay here untill someone bails you out or untill you escape in 3 turns";
                    break;
                case "dood":
                    Eventvak.Text = SelecteerSpeler(gb.playerTurn) + ", you've been caught in a trap. You'll have to start over from the ";
                    break;
                case "dubbeleworp":
                    Eventvak.Text = SelecteerSpeler(gb.playerTurn) + ", you've landed on a special field. Your dice throw is doubled";
                    break;
                case "TweeOpÉénVak":
                    Eventvak.Text = SelecteerSpeler(gb.playerTurn) + ", you landed on a field someone was already on. You've been moved back to your old position.";
                    break;
                case "NineOnFirstTurn":
                    Eventvak.Text = SelecteerSpeler(gb.playerTurn) + ", lucky you! You landed on field 9 in your first turn! You've been moved to field 26;";
                    break;
            }

            dobbel.Text = "Number of pips thrown:" + " " + Convert.ToString(gb.dice.pipCount) + "\n" + SelecteerSpeler(gb.playerTurn) + ", You are now on field:" + " " + gb.players[gb.playerTurn].location;

            if (gb.winGame)
            {
                Eventvak.Text = SelecteerSpeler(gb.playerTurn) + " " + "Won the Game! You can either play another game or go back to the home menu";
                btnDobbel.IsEnabled = false;
                btnRestart.Visibility = Visibility.Visible;
            }

            gb.NextPlayer();


            if (gb.CheckSkippingTurn())
            {
                gb.ChangeSkipTurn();
                gb.NextPlayer();
            }
            else if (gb.CheckStuck())
            {
                if (gb.number == 2)
                {
                    gb.ChangeStuck();
                    gb.number = 0;
                }
                else
                {
                    gb.number++;
                    gb.NextPlayer();
                }
            }

            SelecteerSpeler(gb.playerTurn);
        }

        internal void SetUser(User user)
        {
            this.user = user;
            this.Spelernaam1 = Spelernaam1;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage();
            hub.SetUser(user);

            Content = hub;
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            gb.Restart();
            btnDobbel.IsEnabled = true;

            GBPlayersPage gbp = new GBPlayersPage();
            gbp.SetUser(user);

            Content = gbp;
        }

        private string SelecteerSpeler(int player)
        {
            switch (player)
            {
                default:
                    return "";
                case 0:
                    speler.Text = "Frankie is playing" + " " + "(purple)";
                    return "Frankie";
                case 1:
                    speler.Text = Spelernaam2 + " " + "is playing" + " " + "(blue)";
                    return Spelernaam2;
                case 2:
                    speler.Text = Spelernaam3 + " " + "is playing" + " " + "(green)";
                    return Spelernaam3;
                case 3:
                    speler.Text = Spelernaam4 + " " + "is playing" + " " + "(red)";
                    return Spelernaam4;
                case 4:
                    speler.Text = Spelernaam5 + " " + "is playing" + " " + "(black)";
                    return Spelernaam5;
            }
        }
    }
}