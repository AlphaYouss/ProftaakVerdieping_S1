using System.Collections.Generic;

namespace Rcade
{
    class Errorhandler
    {
        List<string> connectionError = new List<string>();
        List<string> loginError = new List<string>();
        List<string> accountError = new List<string>();

        public Errorhandler()
        {
            connectionError.Add("Connection to the database failed, contact us!");

            loginError.Add("Username must be bewteen 3 and 10 long. Letters only.");
            loginError.Add("Password must be 8 long. 1 capital letter and 1 number.");
            loginError.Add("Fill the username and password correctly.");

            accountError.Add("Account doesn't exist!");
            accountError.Add("Username and/or password do not match!");
        }
        public string GetConnectionError(int error)
        {
            return connectionError[error];
        }

        public string GetLoginError(int error)
        {
            return loginError[error];
        }
        public string GetAccountError(int error)
        {
            return accountError[error];
        }
    }
}