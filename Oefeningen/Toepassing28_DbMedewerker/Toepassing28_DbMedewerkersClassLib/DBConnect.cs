using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toepassing28_DbMedewerkersClassLib;

namespace Toepassing28_DbMedewerkersClassLib
{
    internal class DBConnect
    {
        public static SqlConnection MaakConnectie(string connectionString)
        {
            return new SqlConnection(connectionString); //geeft connectie terug aan DB
        }
    }
}
