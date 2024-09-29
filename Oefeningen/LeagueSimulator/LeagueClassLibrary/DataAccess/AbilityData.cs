using LeagueClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueClassLibrary.DataAccess
{
    public static class AbilityData
    {
        private static List<Ability> Abilities { get; set; }



        public static void LoadCSV(string padNaarCsv)
        {
            //LoadCSV(string padNaarCsv) zorgt er voor dat de Abilities list
            //geïnitialiseerd is.De methode gebruikt het pad naar het csv bestand
            //dat meegegeven wordt om de List te vullen met Ability objecten.
            Abilities = new List<Ability>();
            using (StreamReader streamReader = new StreamReader(padNaarCsv))
            {
                if (!streamReader.EndOfStream)
                {
                    string line;
                    streamReader.ReadLine();
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(';');
                        if (fields.Length == 3 && !string.IsNullOrWhiteSpace(fields[0])) 
                        {
                            try
                            {
                                int idd = Convert.ToInt32(fields[0]);
                                Abilities.Add(new Ability(idd, fields[1], fields[2]));
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

        public static List<Ability> GetAbilitiesByChampionName(string championName)
        {
            //Deze methode geeft een list terug van Ability objecten die van een
            //champion zijn met de gegeven naam. Gebruik hier een Linq query
            //voor.
            var chosenChampion = (
                from champion in Abilities
                where champion.Name == championName
                select champion).ToList();

            return chosenChampion;
        }
    }
}
