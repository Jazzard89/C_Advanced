using LeagueClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeagueClassLibrary.DataAccess
{
    public static class MatchData
    {
        private static DataTable DataTableMatches { get; set; }

        public static void InitializeDataTableMatches()
        {
            //Deze methode initialiseert de DataTableMatches met een Id(int),
            //Code(string) en Winner(string) kolom.Zorg er voor dat de Id kolom
            //automatisch incrementeert.Zie tabel 3.

            DataTableMatches = new DataTable();

            // Create the Id column with auto-increment
            DataColumn idColumn = new DataColumn("Id", typeof(int));
            idColumn.AutoIncrement = true;
            idColumn.AutoIncrementSeed = 1; // Start value for the auto-increment
            idColumn.AutoIncrementStep = 1; // Increment value for the auto-increment
            DataTableMatches.Columns.Add(idColumn);


            DataTableMatches.Columns.Add("Code", typeof(string));
            DataTableMatches.Columns.Add("Winner", typeof (string));
        }

        public static void AddFinishedMatch(Match match)
        {
            //Deze methode voegt een match toe aan de DataTableMatches.
            //Verander de team code van het match object naar de namen: “Red”
            //of “Blue”. Als de Winner eigenschap van het match object gelijk is
            //aan 1, dan wint team “Red”. Zoniet, dan wint team “Blue”.

            if (match.Winner == 1)
            {
                match.Code = "Red";
            }
            else
            {
                match.Code = "Blue";
            }

            DataTableMatches.Rows.Add(match);


        }

        public static DataView GetDataViewMatches()
        {
            //Deze methode zet de data uit DataTableMatches om naar een DataView.
            DataView dataView = new DataView(DataTableMatches);
            
            return dataView;
        }
        
        public static void ExportToXML()
        {
            //Deze methode exporteert de inhoud van DataTableMatches naar een
            //bestand, genaamd “Matches.xml”. Laat de gebruiker zelf kiezen waar
            //hij of zij dit bestand wenst op te slaan.
            DataTableMatches.WriteXml("Matches.xml");
        }

        public static bool IsUniqueCode(string code)
        {
            //Deze methode geeft true terug als de gegeven code nog niet
            //voorkomt in DataTableMatches.

            if (!DataTableMatches.Columns.Contains(code))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
