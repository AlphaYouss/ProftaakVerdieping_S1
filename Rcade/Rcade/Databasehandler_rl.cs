using System;
using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_rl : Databasehandler
    {
        public Databasehandler_rl(bool testTable)
        {
            isTestVersion = testTable;
        }

        public bool CheckUser(int id)
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT COUNT(*) FROM Test_Roulette WHERE user_ID = @ID", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT COUNT(*) FROM Roulette WHERE user_ID = @ID", GetCon());
            }

            cmd.Parameters.AddWithValue("ID", id);

            OpenConnectionToDB();

            bool exists = (int)cmd.ExecuteScalar() > 0;

            CloseConnectionToDB();
            return exists;
        }

        public void CreateUser(int id)
        {
            SqlCommand cmd = new SqlCommand();
            string datetime = DateTime.Now.ToString();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("INSERT INTO Test_Roulette(user_ID, saldo, laatst_gespeeld) VALUES(@ID, 25000, @Datetime)", GetCon());
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO Roulette(user_ID, saldo, laatst_gespeeld) VALUES(@ID, 25000, @Datetime)", GetCon());
            }

            cmd.Parameters.AddWithValue("ID", id);
            cmd.Parameters.AddWithValue("Datetime", datetime);

            OpenConnectionToDB();
            cmd.ExecuteNonQuery();
            CloseConnectionToDB();
        }

        public void GetUser(int id)
        {
            if (CheckUser(id) == false)
            {
                CreateUser(id);
            }

            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT * FROM Test_Roulette WHERE user_ID = @ID", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Roulette WHERE user_ID = @ID", GetCon());
            }

            cmd.Parameters.AddWithValue("ID", id);

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            adapt.Fill(table);
            CloseConnectionToDB();
        }

        public void SetUser(int id, int saldo, DateTime lastPlayed)
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("UPDATE Test_Roulette SET saldo = @Saldo, laatst_gespeeld = @LastPlayed Where user_ID = @ID", GetCon());
            }
            else
            {
                cmd = new SqlCommand("UPDATE Roulette SET saldo = @Saldo, laatst_gespeeld = @LastPlayed Where user_ID = @ID", GetCon());
            }

            cmd.Parameters.AddWithValue("ID", id);
            cmd.Parameters.AddWithValue("Saldo", saldo);
            cmd.Parameters.AddWithValue("LastPlayed", lastPlayed);

            OpenConnectionToDB();
            cmd.ExecuteNonQuery();
            CloseConnectionToDB();
        }
    }
}