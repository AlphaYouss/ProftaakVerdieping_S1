using System;
using System.Data;
using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler
    {
       private SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
       private SqlConnection con;
       public DataTable table = new DataTable("allPrograms");

        public Databasehandler()
        {
            builder.DataSource = "rcade.database.windows.net";
            builder.UserID = "rcade";
            builder.Password = "Kanker!25";
            builder.InitialCatalog = "Rcade";

            con = new SqlConnection(builder.ConnectionString);
        }

        public bool TestConnection()
        {
            bool open = false;

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
            }
            catch (Exception)
            {
                return false;
            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    open = true;
                }

                con.Close();
            }

            if (!open)
            {
                return false;
            }
            return open;
        }

        public void OpenConnectionToDB()
        {
            con.Open();
        }

        public void CloseConnectionToDB()
        {
            con.Close();
        }

        public SqlConnection GetCon()
        {
            return con;
        }

        public void Execute(string query)
        {
            SqlCommand queryExecute = new SqlCommand(query, con);

            try
            {
                TestConnection();
                OpenConnectionToDB();

                queryExecute.Prepare();
                queryExecute.ExecuteReader();

                CloseConnectionToDB();
            }
            catch (Exception)
            {
                CloseConnectionToDB();
            }
        }

        public void GetUserData()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM User_gegevens", GetCon());

            TestConnection();
            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            adapt.Fill(table);

            CloseConnectionToDB();
        }
    }
}