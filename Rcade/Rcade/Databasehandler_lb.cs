using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_lb : Databasehandler
    {
        private string query { get; set; } = "";
        private string testquery { get; set; } = "";
        public int choice { get; private set; } = 1;
        public List<string> usernames { get; private set; } = new List<string>();
        public string table1Name { get; private set; } = "";
        public List<string> table1 { get; private set; } = new List<string>();
        public string table2Name { get; private set; } = "";
        public List<string> table2 { get; private set; } = new List<string>();
        public string table3Name { get; private set; } = "";
        public List<string> table3 { get; private set; } = new List<string>();
        public string table4Name { get; private set; } = "";
        public List<string> table4 { get; private set; } = new List<string>();
        public string table5Name { get; private set; } = "";
        public List<string> table5 { get; private set; } = new List<string>();

        public Databasehandler_lb(bool testTable)
        {
            isTestVersion = testTable;
        }

        public void ChoiceMaker()
        {
            Clear();
            switch (choice)
            {
                case 1:
                    SelectFromBlackjack();
                    testquery = "SELECT Test_User_gegevens.Username, Test_Blackjack.user_ID FROM Test_User_gegevens INNER JOIN Test_Blackjack ON Test_User_gegevens.ID = Test_Blackjack.user_ID";
                    query = "SELECT User_gegevens.Username, Blackjack.user_ID FROM User_gegevens INNER JOIN Blackjack ON User_gegevens.ID = Blackjack.user_ID";
                    break;
                case 2:
                    SelectFromRoulette();
                    testquery = "SELECT Test_User_gegevens.Username, Test_Roulette.user_ID FROM Test_User_gegevens INNER JOIN Test_Roulette ON Test_User_gegevens.ID = Test_Roulette.user_ID";
                    query = "SELECT User_gegevens.Username, Roulette.user_ID FROM User_gegevens INNER JOIN Roulette ON User_gegevens.ID = Roulette.user_ID";
                    break;

                case 3:
                    SelectFromHangman();
                    testquery = "SELECT Test_User_gegevens.Username, Test_Galgje.user_ID FROM Test_User_gegevens INNER JOIN Test_Galgje ON Test_User_gegevens.ID = Test_Galgje.user_ID";
                    query = "SELECT User_gegevens.Username, Galgje.user_ID FROM User_gegevens INNER JOIN Galgje ON User_gegevens.ID = Galgje.user_ID";
                    break;

                case 4:
                    SelectFromBKE();
                    testquery = "SELECT Test_User_gegevens.Username, Test_BKE.user_ID FROM Test_User_gegevens INNER JOIN Test_BKE ON Test_User_gegevens.ID = Test_BKE.user_ID";
                    query = "SELECT User_gegevens.Username, BKE.user_ID FROM User_gegevens INNER JOIN BKE ON User_gegevens.ID = BKE.user_ID";
                    break;

                case 5:
                    SelectFromGanzenbord();
                    testquery = "SELECT Test_User_gegevens.Username, Test_Ganzenbord.user_ID FROM Test_User_gegevens INNER JOIN Test_Ganzenbord ON Test_User_gegevens.ID = Test_Ganzenbord.user_ID";
                    query = "SELECT User_gegevens.Username, Ganzenbord.user_ID FROM User_gegevens INNER JOIN Ganzenbord ON User_gegevens.ID = Ganzenbord.user_ID";
                    break;
            }

            UserIDToUsername();
        }

        public void Clear()
        {
            table.Clear();

            usernames.Clear();

            table1.Clear();
            table2.Clear();
            table3.Clear();
            table4.Clear();
            table5.Clear();

            table1Name = "";
            table2Name = "";
            table3Name = "";
            table4Name = "";
            table5Name = "";
        }

        public void ChangeChoice(int myChoice)
        {
            choice = myChoice;
        }

        private void UserIDToUsername()
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand(testquery, GetCon());
            }
            else
            {
                cmd = new SqlCommand(query, GetCon());
            }

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(table);

            CloseConnectionToDB();

            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToString(row["Username"]) != "")
                {
                    usernames.Add(Convert.ToString(row["Username"]));
                }
            }
        }

        private void SelectFromBlackjack()
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT * FROM Test_Blackjack", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Blackjack", GetCon());
            }

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(table);

            CloseConnectionToDB();

            DateTime dt;

            table1Name = "Username";
            table2Name = "Balance";
            table3Name = "Last seen";

            foreach (DataRow row in table.Rows)
            {
                table1.Add(Convert.ToString(row["user_ID"]));
                table2.Add(Convert.ToString(row["saldo"]));

                dt = Convert.ToDateTime(row["laatst_gespeeld"]);

                table3.Add(dt.Date.ToString("MM/dd/yyyy"));
            }
        }
        private void SelectFromBKE()
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT * FROM Test_BKE", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM BKE", GetCon());
            }

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(table);

            CloseConnectionToDB();

            DateTime dt;

            table1Name = "Username";
            table2Name = "Games won";
            table3Name = "Games lost";
            table4Name = "Games tied";
            table5Name = "Last seen";

            foreach (DataRow row in table.Rows)
            {
                table1.Add(Convert.ToString(row["user_ID"]));
                table2.Add(Convert.ToString(row["gewonnen_potjes"]));
                table3.Add(Convert.ToString(row["verloren_potjes"]));
                table4.Add(Convert.ToString(row["gelijkspel_potjes"]));

                dt = Convert.ToDateTime(row["laatst_gespeeld"]);

                table5.Add(dt.Date.ToString("MM/dd/yyyy"));
            }
        }

        private void SelectFromHangman()
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT * FROM Test_Galgje", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Galgje", GetCon());
            }


            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(table);

            CloseConnectionToDB();

            DateTime dt;

            table1Name = "Username";
            table2Name = "Total points";
            table3Name = "Total mistakes";
            table4Name = "Last seen";

            foreach (DataRow row in table.Rows)
            {
                table1.Add(Convert.ToString(row["user_ID"]));
                table2.Add(Convert.ToString(row["totaal_punten"]));
                table3.Add(Convert.ToString(row["totaal_fouten"]));

                dt = Convert.ToDateTime(row["laatst_gespeeld"]);

                table4.Add(dt.Date.ToString("MM/dd/yyyy"));
            }
        }

        private void SelectFromGanzenbord()
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT * FROM Test_Ganzenbord", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Ganzenbord", GetCon());
            }

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(table);

            CloseConnectionToDB();

            DateTime dt;

            table1Name = "Username";
            table2Name = "Dices rolled";
            table3Name = "Games played";
            table4Name = "Last seen";

            foreach (DataRow row in table.Rows)
            {
                table1.Add(Convert.ToString(row["user_ID"]));
                table2.Add(Convert.ToString(row["aantal_worpen"]));
                table3.Add(Convert.ToString(row["gespeelde_potjes"]));

                dt = Convert.ToDateTime(row["laatst_gespeeld"]);

                table4.Add(dt.Date.ToString("MM/dd/yyyy"));
            }
        }

        private void SelectFromRoulette()
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT * FROM Test_Roulette", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Roulette", GetCon());
            }

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(table);

            CloseConnectionToDB();

            DateTime dt;

            table1Name = "Username";
            table2Name = "Balance";
            table3Name = "Last seen";

            foreach (DataRow row in table.Rows)
            {
                table1.Add(Convert.ToString(row["user_ID"]));
                table2.Add(Convert.ToString(row["saldo"]));

                dt = Convert.ToDateTime(row["laatst_gespeeld"]);

                table3.Add(dt.Date.ToString("MM/dd/yyyy"));
            }
        }
    }
}