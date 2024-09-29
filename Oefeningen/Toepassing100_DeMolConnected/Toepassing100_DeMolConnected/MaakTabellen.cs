using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing100_DeMolConnected
{
    internal static class MaakTabellen
    {
        //maak database en tabellen
        static DataSet ds = new DataSet("DeMolDS");
        public static DataTable dtSpelers = new DataTable("Spelers"); //moest static zijn omdat de class static is en we moesten er aan komen 

        public static DataTable dtSpellen = new DataTable("Spellen");

    }
}
