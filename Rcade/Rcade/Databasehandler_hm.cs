using System;
using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_hm : Databasehandler
    {
        public Databasehandler_hm(bool testTable)
        {
            isTestVersion = testTable;
        }

        public bool CheckUser(int id)
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT COUNT(*) FROM Test_Galgje WHERE user_ID = @ID", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT COUNT(*) FROM Galgje WHERE user_ID = @ID", GetCon());
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
                cmd = new SqlCommand("INSERT INTO Test_Galgje(user_ID, totaal_punten, totaal_fouten, laatst_gespeeld) VALUES(@ID, 0, 0, @Datetime)", GetCon());
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO Galgje(user_ID, totaal_punten, totaal_fouten, laatst_gespeeld) VALUES(@ID, 0, 0, @Datetime)", GetCon());
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
                cmd = new SqlCommand("SELECT * FROM Test_Galgje WHERE user_ID = @ID", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Galgje WHERE user_ID = @ID", GetCon());
            }

            cmd.Parameters.AddWithValue("ID", id);

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            adapt.Fill(table);
            CloseConnectionToDB();
        }

        public void SetUser(int id, int points, int mistakes, DateTime lastPlayed)
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("UPDATE Test_Galgje SET totaal_punten = @Points, totaal_fouten = @Mistakes, laatst_gespeeld = @LastPlayed Where user_ID = @ID", GetCon());
            }
            else
            {
                cmd = new SqlCommand("UPDATE Galgje SET totaal_punten = @Points, totaal_fouten = @Mistakes, laatst_gespeeld = @LastPlayed Where user_ID = @ID", GetCon());
            }

            cmd.Parameters.AddWithValue("ID", id);
            cmd.Parameters.AddWithValue("Points", points);
            cmd.Parameters.AddWithValue("Mistakes", mistakes);
            cmd.Parameters.AddWithValue("LastPlayed", lastPlayed);

            OpenConnectionToDB();
            cmd.ExecuteNonQuery();
            CloseConnectionToDB();
        }
    }
}