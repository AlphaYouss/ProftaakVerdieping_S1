using System;
using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_User_gegevens : Databasehandler
    {
        public Databasehandler_User_gegevens(bool testTable)
        {
            isTestVersion = testTable;
        }

        public bool CheckIfUserExists(string username)
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT COUNT(*) FROM Test_User_gegevens WHERE Username = @Username", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT COUNT(*) FROM User_gegevens WHERE Username = @BSNUsername", GetCon());
            }

            cmd.Parameters.AddWithValue("Username", username);

            if (TestConnection() == true)
            {
                OpenConnectionToDB();

                bool exists = (int)cmd.ExecuteScalar() > 0;

                CloseConnectionToDB();
                return exists;
            }
            else
            {
                isDatabaseLive = false;
                return false;
            }
        } 

        public int GetUserID(string username)
        {
            SqlCommand cmd = new SqlCommand();
            int userID = 0;

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT ID FROM Test_User_gegevens WHERE Username = @Username", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT ID FROM User_gegevens WHERE Username = @BSNUsername", GetCon());
            }

            cmd.Parameters.AddWithValue("Username", username);

            if (TestConnection() == true)
            {
                OpenConnectionToDB();

                userID = Convert.ToInt16(cmd.ExecuteScalar());

                CloseConnectionToDB();
            }
            else
            {
                isDatabaseLive = false;
            }
            return userID;
        }

        public string GetUserHash(int id)
        {
            SqlCommand cmd = new SqlCommand();
            string salt = "";

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT Wachtwoord_hash FROM Test_User_gegevens WHERE ID = @ID", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT Wachtwoord_hash FROM User_gegevens WHERE ID = @ID", GetCon());
            }

            cmd.Parameters.AddWithValue("ID", id);

            if (TestConnection() == true)
            {
                OpenConnectionToDB();

                salt = Convert.ToString(cmd.ExecuteScalar());
                CloseConnectionToDB();
            }
            else
            {
                isDatabaseLive = false;
            }
            return salt;
        }

        public void GetUsersData()
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                 cmd = new SqlCommand("SELECT * FROM Test_User_gegevens", GetCon());
            }
            else
            {
                 cmd = new SqlCommand("SELECT * FROM User_gegevens", GetCon());
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