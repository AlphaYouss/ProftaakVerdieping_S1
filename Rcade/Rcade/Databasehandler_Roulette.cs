using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_Roulette : Databasehandler
    {
        public Databasehandler_Roulette(bool testTable)
        {
            isTestVersion = testTable;
        }

        public void GetUsersData()
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