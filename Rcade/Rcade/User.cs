using CryptSharp;
using System.Text.RegularExpressions;

namespace Rcade
{
    internal class User
    {
        private Databasehandler_User_gegevens dbh_UG = new Databasehandler_User_gegevens(true);
        private Databasehandler_Blackjack dbh_BJ = new Databasehandler_Blackjack(true);
        private Databasehandler_Boter_kaas_en_eieren dbh_BKE = new Databasehandler_Boter_kaas_en_eieren(true);
        private Databasehandler_Galgje dbh_GJ = new Databasehandler_Galgje(true);
        private Databasehandler_Ganzenbord dbh_GB = new Databasehandler_Ganzenbord(true);
        private Databasehandler_Roulette dbh_RL = new Databasehandler_Roulette(true);

        private Errorhandler errorHandler = new Errorhandler();

        public bool exists { get; private set; } = false;
        public bool loggedIn { get; private set; } = false;
        public string userName { get; private set; } = "";
        public int id { get; private set; } = 0;

        public string ShowError(string list, int error)
        {
            string errorMessage = "";
            switch (list)
            {
                default:
                    break;
                case "Login":
                    errorMessage = errorHandler.GetLoginError(error);
                    break;
                case "Account":
                    errorMessage = errorHandler.GetAccountError(error);
                    break;
                case "Blackjack":
                    break;
                case "Roulette":
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

        public void CheckIfUserExists(string username)
        {
            if (dbh_UG.CheckIfUserExists(username) == false)
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
                id = dbh_UG.GetUserID(userName);

                CheckPassword(password, dbh_UG.GetUserHash(id));
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

        //public void WriteData()
        //{
        //    d_UG.GetUsersData();

        //    foreach (DataRow row in d_UG.table.Rows)
        //    {
        //        string name = row["Username"].ToString();
        //    }
        //}
    }
}
