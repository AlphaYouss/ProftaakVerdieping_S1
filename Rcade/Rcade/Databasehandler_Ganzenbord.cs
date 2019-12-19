using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_Ganzenbord : Databasehandler
    {
        public Databasehandler_Ganzenbord(bool testTable)
        {
            isTestVersion = testTable;
        }

        public void GetUsersData()
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
