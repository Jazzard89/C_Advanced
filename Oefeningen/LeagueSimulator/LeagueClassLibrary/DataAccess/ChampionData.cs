using LeagueClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeagueClassLibrary.DataAccess
{
    public static class ChampionData
    {
        private static DataTable DataTableChampions {get; set;}
        //De DataTableChampions kolommen voor position2 en position3 kunnen
        //null zijn.Zie de csv en Tabel 1.

        static private Random r = new Random();

        public static void LoadCSV(string padNaarCsv)
        {
            //zorgt er voor dat de DataTableChampions
            //geïnitialiseerd is.De methode gebruikt het pad naar het csv bestand
            //dat meegegeven wordt om de DataTable te vullen met records.

            DataTableChampions = new DataTable();
            DataTableChampions.Columns.Add("ChampionName", typeof(string));
            DataTableChampions.Columns.Add("ChampionTitle", typeof(string));
            DataTableChampions.Columns.Add("ChampionClass", typeof(string));
            DataTableChampions.Columns.Add("ReleaseYear", typeof(string));
            DataTableChampions.Columns.Add("ChampionPosition1", typeof(string));
            DataTableChampions.Columns.Add("ChampionPosition2", typeof(string));
            DataTableChampions.Columns.Add("ChampionPosition3", typeof(string));
            DataTableChampions.Columns.Add("ChampionIcon", typeof(string));
            DataTableChampions.Columns.Add("ChampionBanner", typeof(string));
            DataTableChampions.Columns.Add("ChampionRPCost", typeof (int));
            DataTableChampions.Columns.Add("ChampionIPCost", typeof(int));

            using (StreamReader streamReader = new StreamReader(padNaarCsv))
            {
                streamReader.ReadLine();
                if (!streamReader.EndOfStream)
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(';');
                        if (fields.Length == 11)
                        {
                            int field3 = Convert.ToInt32(fields[3]);
                            int ChampionRPCost = Convert.ToInt32(fields[9]);
                            int ChampionIPCost = Convert.ToInt32(fields[10]);
                            try
                            {

                                DataTableChampions.Rows.Add(fields[0], fields[1], fields[2], field3, fields[4], fields[5], fields[6], fields[7], ChampionRPCost, ChampionIPCost);
                            }
                            catch
                            {
                                throw new Exception("data niet correct gelezen");
                            }
                        }
                        else
                        {
                            throw new Exception("bestand niet volleig");
                        }
                    }


                }

            }
        }

        public static DataView GetDataViewChampion()
        {
            //Deze methode zet de data uit DataTableChampions om naar een  DataView.

            DataView dv = new DataView(DataTableChampions);
            return dv;
        }

        public static DataView GetDataViewChampionsByPosition(string position)
        {
            //Deze methode filtert DataTableChampions op basis van position. Als
            //een champion de gegeven position bevat, dan wordt de champion
            //weergegeven in de DataView.

            var DataFilter = (
                from champion in DataTableChampions.AsEnumerable()
                where champion.Field<string>("ChampionPosition1") == position ||
                      champion.Field<string>("ChampionPosition2") == position ||
                      champion.Field<string>("ChampionPosition3") == position
                select champion).ToList();

            DataView dv2 = new DataView();

            foreach(DataRow dr in DataFilter) 
            {
                dv2.Table.ImportRow(dr);
            }


            return dv2;
        }

        public static DataView GetDataViewChampionsBestToWorst()
        {
            //o Deze methode sorteert de rijen in DataTableChampions op de volgende criteria:
            //▪ Op het jaar dat ze zijn uitgekomen.Meest recent naar oud.
            //▪ Vervolgens op hoeveel posities een champion heeft.Meer posities naar minder.
            //▪ Tot slot op de alfabetische volgorde van de naam.


            DataView bestWorstView = DataTableChampions.DefaultView;

            bestWorstView.Sort = "ReleaseYear DESC, ChampionPosition1 DESC, ChampionName ASC";


            return bestWorstView;
        }





        //Deze methode geeft een willekeurig Champion object terug uit
        //DataTableChampions die de gegeven position bevat. Maak gebruik van
        //de GetAbilitiesByChampionName(string name) methode uit AbilityData
        //om de abilities op te vragen.

        public static Champion GetRandomChampionByPosition(string position)
        {
            // Filter the DataTableChampions based on the specified position
            DataRow[] matchingRows = DataTableChampions.Select($"ChampionPosition1 = '{position}' OR ChampionPosition2 = '{position}' OR ChampionPosition3 = '{position}'");

            if (matchingRows.Length > 0)
            {
                // Generate a random index within the range of matching rows
                int randomIndex = r.Next(0, matchingRows.Length);

                // Retrieve the ChampionName and ChampionTitle
                string championName = matchingRows[randomIndex]["ChampionName"].ToString();
                string championTitle = matchingRows[randomIndex]["ChampionTitle"].ToString();

                // Retrieve the ChampionClass
                string championClass = matchingRows[randomIndex]["ChampionClass"].ToString();

                // Retrieve the ReleaseYear (assuming it's an integer column)
                int releaseYear = Convert.ToInt32(matchingRows[randomIndex]["ReleaseYear"]);

                // Retrieve the ChampionIcon and ChampionBanner
                string championIcon = matchingRows[randomIndex]["ChampionIcon"].ToString();
                string championBanner = matchingRows[randomIndex]["ChampionBanner"].ToString();

                // Retrieve the ChampionRPCost and ChampionIPCost (assuming they are integer columns)
                int championRPCost = Convert.ToInt32(matchingRows[randomIndex]["ChampionRPCost"]);
                int championIPCost = Convert.ToInt32(matchingRows[randomIndex]["ChampionIPCost"]);

                List<string> positions = new List<string>();
                positions.Add((matchingRows[randomIndex]["ChampionPosition1"].ToString()));
                positions.Add((matchingRows[randomIndex]["ChampionPosition2"].ToString()));
                positions.Add((matchingRows[randomIndex]["ChampionPosition3"].ToString()));

                // Retrieve the Champion Abilities (assuming GetAbilitiesByChampionName returns a list of abilities)
                List<Ability> championAbilities = AbilityData.GetAbilitiesByChampionName(championName);

                // List<string> positions, string iconSource, string bannerSource, int costIP, int costRP)
                // Create and return the Champion object
                Champion champion = new Champion(
                    championName,
                    championTitle,
                    championClass,
                    releaseYear,
                    championAbilities,
                    positions,
                    championIcon,
                    championBanner,
                    championRPCost,
                    championIPCost
                );

                return champion;
            }
            else
            {
                // Handle the case where no matching champions were found
                return null;
            }
        }

    }
}
