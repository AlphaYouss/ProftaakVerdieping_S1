using System.Collections.Generic;

namespace Rcade
{
    class Errorhandler
    {
        List<string> loginErrors = new List<string>();
        List<string> accountErrors = new List<string>();

        public Errorhandler()
        {
            loginErrors.Add("Username must be bewteen 3 and 10 long. Letters only.");
            loginErrors.Add("Password must be 8 long. 1 capital letter and 1 number.");
            loginErrors.Add("Fill the username and password correctly.");

            accountErrors.Add("Account doesn't exist!");
            accountErrors.Add("Username and/or password do not match!");
        }

        public string GetLoginError(int error)
        {
            return loginErrors[error];
        }
        public string GetAccountError(int error)
        {
            return accountErrors[error];
        }
    }
}