using System;
using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_ttt : Databasehandler
    {
        public int won { get; set; }
        public int draw { get; set; }
        public int lost { get; set; }
        public DateTime lastPlayed { get; set; }

        public Databasehandler_ttt(bool testTable)
        {
            isTestVersion = testTable;
        }

        public bool CheckUser(int id)
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT COUNT(*) FROM Test_BKE WHERE user_ID = @ID", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT COUNT(*) FROM Test_BKE WHERE user_ID = @ID", GetCon());
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
                cmd = new SqlCommand("INSERT INTO Test_BKE(user_ID, gewonnen_potjes, verloren_potjes, gelijkspel_potjes, laatst_gespeeld) VALUES(@ID, 0, 0, 0, @Datetime)", GetCon());
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO BKE(user_ID, gewonnen_potjes, verloren_potjes, gelijkspel_potjes, laatst_gespeeld) VALUES(@ID, 0, 0, 0, @Datetime)", GetCon());
            }

            cmd.Parameters.AddWithValue("ID", id);
            cmd.Parameters.AddWithValue("Datetime", datetime);

            OpenConnectionToDB();
            cmd.ExecuteNonQuery();
            CloseConnectionToDB();
        }

        public void GetUser(int id)
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("SELECT * FROM Test_BKE WHERE user_ID = @ID", GetCon());
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM BKE WHERE user_ID = @ID", GetCon());
            }

            cmd.Parameters.AddWithValue("ID", id);

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            adapt.Fill(table);
            CloseConnectionToDB();
        }

        public void SetUser(int id, int won, int lost, int draw, DateTime lastPlayed)
        {
            SqlCommand cmd = new SqlCommand();

            if (isTestVersion == true)
            {
                cmd = new SqlCommand("UPDATE Test_BKE SET gewonnen_potjes = @Won, verloren_potjes = @Lost, gelijkspel_potjes = @Draw, laatst_gespeeld = @LastPlayed Where user_ID = @ID", GetCon());
            }
            else
            {
                cmd = new SqlCommand("UPDATE BKE SET gewonnen_potjes = @Won, verloren_potjes = @Lost, gelijkspel_potjes = @Draw, laatst_gespeeld = @LastPlayed Where user_ID = @ID", GetCon());
            }

            cmd.Parameters.AddWithValue("ID", id);
            cmd.Parameters.AddWithValue("Won", won);
            cmd.Parameters.AddWithValue("Lost", lost);
            cmd.Parameters.AddWithValue("Draw", draw);
            cmd.Parameters.AddWithValue("LastPlayed", lastPlayed);

            OpenConnectionToDB();
            cmd.ExecuteNonQuery();
            CloseConnectionToDB();
        }
    }
}