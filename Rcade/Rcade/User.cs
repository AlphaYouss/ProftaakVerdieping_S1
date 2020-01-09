using CryptSharp;
using System;
using System.Data;
using System.Text.RegularExpressions;

namespace Rcade
{
    internal class User
    {
        private Databasehandler dbh { get; set; } = new Databasehandler();
        private Databasehandler_user dbh_U { get; set; } = new Databasehandler_user(true);
        private Databasehandler_bj dbh_BJ { get; set; } = new Databasehandler_bj(true);
        private Databasehandler_ttt dbh_TTT { get; set; } = new Databasehandler_ttt(true);
        private Databasehandler_hm dbh_HM { get; set; } = new Databasehandler_hm(true);
        private Databasehandler_gb dbh_GB { get; set; } = new Databasehandler_gb(true);
        private Databasehandler_rl dbh_RL { get; set; } = new Databasehandler_rl(true);
        private Errorhandler errorHandler { get; set; } = new Errorhandler();
        public bool exists { get; private set; } = false;
        public bool loggedIn { get; private set; } = false;
        public string userName { get; private set; } = "";
        public int id { get; private set; } = 0;

        public string ShowError(string list, int error)
        {
            string errorMessage = "";
            switch (list)
            {
                case "Login":
                    errorMessage = errorHandler.GetLoginError(error);
                    break;
                case "Account":
                    errorMessage = errorHandler.GetAccountError(error);
                    break;
                case "Database":
                    errorMessage = errorHandler.GetConnectionError(error);
                    break;
            }
            return errorMessage;
        }

        public bool ValidateUsername(string username)
        {
            var regex = @"^[a-zA-Z0-9]{3,10}$";
            var match = Regex.Match(username, regex, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidatePassword(string password)
        {
            var regex = @"^(?=.*\d)(?=.*[A-Z])(?!.*[^a-zA-Z0-9])(.{3,100})$";
            var match = Regex.Match(password, regex, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CanConnectToDatabase()
        {
            return dbh.TestConnection();
        }

        public void CheckIfUserExists(string username)
        {
            if (dbh_U.CheckIfUserExists(username) == false)
            {
                exists = false;
            }
            else
            {
                exists = true;
            }
        }

        public void Login(string username, string password)
        {
            if (exists != false)
            {
                userName = username;
                id = dbh_U.GetUserID(userName);

                CheckPassword(password, dbh_U.GetUserHash(id));
            }
        }

        private void CheckPassword(string password, string hashed)
        {
            if (Crypter.CheckPassword(password, hashed) == true)
            {
                loggedIn = true;
            }
            else
            {
                loggedIn = false;
            }
        }

        public void CheckIfUserHasTTTRow()
        {
            if (dbh_TTT.CheckIfUserRowExists(id) == false)
            {
                dbh_TTT.CreateRow(id);
            }
        }

        public void CheckIfUserHasBJRow()
        {
            if (dbh_BJ.CheckIfUserRowExists(id) == false)
            {
                dbh_BJ.CreateRow(id);
            }
        }

        public string[] GetTTTRow()
        {
            dbh_TTT.GetRow(id);

            string[] tttValues = new string[3];

            foreach (DataRow row in dbh_TTT.table.Rows)
            {
                tttValues[0] = Convert.ToString(row["gewonnen_potjes"]);
                tttValues[1] = Convert.ToString(row["verloren_potjes"]);
                tttValues[2] = Convert.ToString(row["gelijkspel_potjes"]);
            }
            return tttValues;
        }

        public int GetBJRow()
        {
            dbh_BJ.GetRow(id);

            int bjSaldo = 0;

            foreach (DataRow row in dbh_BJ.table.Rows)
            {
                bjSaldo = Convert.ToInt32(row["saldo"]);
            }

            return bjSaldo;
        }

        public void SettTTTRow(int id, int won, int lost, int draw, DateTime lastTime)
        {
            dbh_TTT.SetRow(id ,won, lost, draw, lastTime);
        }

        public void SetBJRow(int id, int saldo, DateTime lastTime)
        {
            dbh_BJ.SetRow(id, saldo, lastTime);
        }
    }
}