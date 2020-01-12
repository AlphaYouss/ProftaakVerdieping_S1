using CryptSharp;
using System.Text.RegularExpressions;

namespace Rcade
{
    internal class User
    {
        public Databasehandler dbh { get; private set; } = new Databasehandler();
        private Databasehandler_user dbh_U { get; set; } = new Databasehandler_user(true);
        private Errorhandler errorHandler { get; set; } = new Errorhandler();
        public bool exists { get; private set; } = false;
        public bool loggedIn { get; private set; } = false;
        public string userName { get; private set; } = "";
        public int id { get; private set; } = 0;

        public void CheckUser(string username)
        {
            if (dbh_U.CheckUser(username) == false)
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
                case "Webbrowser":
                    errorMessage = errorHandler.GetWebbrowserError(error);
                    break;
            }
            return errorMessage;
        }
    }
}