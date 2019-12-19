using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_Galgje : Databasehandler
    {
        public Databasehandler_Galgje(bool testTable)
        {
            isTestVersion = testTable;
        }

        public void GetUsersData()
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
