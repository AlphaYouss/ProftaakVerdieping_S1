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
        public Databasehandler_lb(bool testTable)
        {
            isTestVersion = testTable;
            //SelectFromBlackjack();
        }


        public int Choice { get; private set; } = 1;

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



        public void ChoiceMaker()
        {
            Clear();

            switch (Choice)
            {
                case 1:
                    SelectFromBlackjack();
                    break;
                case 2:
                    SelectFromRoulette();
                    break;
                case 3:
                    SelectFromHangman();
                    break;
                case 4:
                    SelectFromBKE();
                    break;
                case 5:
                    SelectFromGanzenbord();
                    break;
            }
        }



        public void Clear()
        {
            table.Clear();

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



        // BlackJack
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
