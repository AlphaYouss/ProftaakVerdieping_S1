using System.Data.SqlClient;

namespace Rcade
{
    class Databasehandler_hm : Databasehandler
    {
        public Databasehandler_hm(bool testTable)
        {
            isTestVersion = testTable;
        }
    }
}