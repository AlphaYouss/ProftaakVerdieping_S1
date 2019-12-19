using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_Blackjack : Databasehandler
    {
        public Databasehandler_Blackjack(bool testTable)
        {
            isTestVersion = testTable;
        }

        public void GetUsersData()
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

            if (TestConnection() == true)
            {
                OpenConnectionToDB();

                SqlDataAdapter adapt = new SqlDataAdapter(cmd);

                adapt.Fill(table);

                CloseConnectionToDB();
            }
            else
            {
                isDatabaseLive = false;
            }
        }
    }
}
