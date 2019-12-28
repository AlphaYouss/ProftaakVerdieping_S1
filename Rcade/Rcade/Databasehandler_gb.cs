using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_gb : Databasehandler
    {
        public Databasehandler_gb(bool testTable)
        {
            isTestVersion = testTable;
        }
    }
}