using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_rl : Databasehandler
    {
        public Databasehandler_rl(bool testTable)
        {
            isTestVersion = testTable;
        }
    }
}