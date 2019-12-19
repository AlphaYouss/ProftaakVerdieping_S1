using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_Boter_kaas_en_eieren : Databasehandler
    {
        public Databasehandler_Boter_kaas_en_eieren(bool testTable)
        {
            isTestVersion = testTable;
        }

        public void GetUsersData()
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
