using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rcade
{
    class Databasehandler_lb : Databasehandler
    {
        string query = "";
        string testquery = "";

       
        public int Choice { get; private set; } = 1;

       
        public List<string> Usernames { get; private set; } = new List<string>();

        public string Table1Name { get; private set; } = "";
        public List<string> Table1 { get; private set; } = new List<string>();


        public string Table2Name { get; private set; } = "";
        public List<string> Table2 { get; private set; } = new List<string>();
      
        
        public string Table3Name { get; private set; } = "";
        public List<string> Table3 { get; private set; } = new List<string>();
      
        
        public string Table4Name { get; private set; } = "";
        public List<string> Table4 { get; private set; } = new List<string>();


        public string Table5Name { get; private set; } = "";
        public List<string> Table5 { get; private set; } = new List<string>();



        public Databasehandler_lb(bool testTable)
        {
            isTestVersion = testTable;
        }


        public void ChoiceMaker()
        {
            Clear();

            switch (Choice)
            {
                case 1:
                    SelectFromBlackjack();
                    testquery = "SELECT Test_User_gegevens.Username, Test_Blackjack.user_ID FROM Test_User_gegevens INNER JOIN Test_Blackjack ON Test_User_gegevens.ID = Test_Blackjack.user_ID";
                    query = "SELECT User_gegevens.Username, Blackjack.user_ID FROM User_gegevens INNER JOIN Blackjack ON User_gegevens.ID = Blackjack.user_ID" ;
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

            UserIDtoUsername();
        }



        public void Clear()
        {
            table.Clear();

            Usernames.Clear();
            Table1.Clear();
            Table2.Clear();
            Table3.Clear();
            Table4.Clear();
            Table5.Clear();
            Table1Name = "";
            Table2Name = "";
            Table3Name = "";
            Table4Name = "";
            Table5Name = "";
        }


        public void ChangeChoice(int MyChoice)
        {
            Choice = MyChoice;
        }




        private void UserIDtoUsername()
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
                    Usernames.Add(Convert.ToString(row["Username"]));
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


            Table1Name = "User ID";
            Table2Name = "Saldo";
            Table3Name = "Last seen";

            foreach (DataRow row in table.Rows)
            {
                Table1.Add(Convert.ToString(row["user_ID"]));
                Table2.Add(Convert.ToString(row["saldo"]));
                Table3.Add(Convert.ToString(row["laatst_gespeeld"]));
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

            Table1Name = "User ID";
            Table2Name = "Games won";
            Table3Name = "Games lost";
            Table4Name = "Games tied";
            Table5Name = "Last seen";

            foreach (DataRow row in table.Rows)
            {
                Table1.Add(Convert.ToString(row["user_ID"]));
                Table2.Add(Convert.ToString(row["gewonnen_potjes"]));
                Table3.Add(Convert.ToString(row["verloren_potjes"]));
                Table4.Add(Convert.ToString(row["gelijkspel_potjes"]));
                Table5.Add(Convert.ToString(row["laatst_gespeeld"]));
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


            Table1Name = "User ID";
            Table2Name = "Total points";
            Table3Name = "Total mistakes";
            Table4Name = "Last seen";

            foreach (DataRow row in table.Rows)
            {
                Table1.Add(Convert.ToString(row["user_ID"]));
                Table2.Add(Convert.ToString(row["totaal_punten"]));
                Table3.Add(Convert.ToString(row["totaal_fouten"]));
                Table4.Add(Convert.ToString(row["laatst_gespeeld"]));
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


            Table1Name = "User ID";
            Table2Name = "dices rolled";
            Table3Name = "Games played";
            Table4Name = "Last seen";

            foreach (DataRow row in table.Rows)
            {
                Table1.Add(Convert.ToString(row["user_ID"]));
                Table2.Add(Convert.ToString(row["aantal_worpen"]));
                Table3.Add(Convert.ToString(row["gespeelde_potjes"]));
                Table4.Add(Convert.ToString(row["laatst_gespeeld"]));
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


            Table1Name = "User ID";
            Table2Name = "Saldo";
            Table3Name = "Last seen";

            foreach (DataRow row in table.Rows)
            {
                Table1.Add(Convert.ToString(row["user_ID"]));
                Table2.Add(Convert.ToString(row["saldo"]));
                Table3.Add(Convert.ToString(row["laatst_gespeeld"]));
            }
        }
    }
}
