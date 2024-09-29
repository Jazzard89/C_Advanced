using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClassLibrary
{
    public static class DataBewerking
    {
        internal const string TRAINER_FILE = "trainer.xml";

        private static DataSet pokemonTrainerDataSet;

        // Deze methode zorgt voor initialisatie van de pokemonTrainerDataSet
        public static void InitializeDataBewerking()
        {
            pokemonTrainerDataSet = new DataSet("TrainerDataSet");

            if (!File.Exists(TRAINER_FILE))
            {

                InitializeNewDataSet();
                pokemonTrainerDataSet.Tables.Add(TrainerData.TrainerDataTable);
                pokemonTrainerDataSet.Tables.Add(CaugthPokemonData.CaugthPokemonDataTable);
                pokemonTrainerDataSet.Tables.Add(PokemonData.PokemonDataTable);
            }
            else
            {
                // Lees file met bestaande trainers en gevangen pokemon
                pokemonTrainerDataSet.ReadXml(TRAINER_FILE);
                TrainerData.TrainerDataTable = pokemonTrainerDataSet.Tables[TrainerData.TRAINERS_DATATABLE_NAME];
                PokemonData.PokemonDataTable = pokemonTrainerDataSet.Tables[PokemonData.POKEMONS_DATATABLE_NAME];
                CaugthPokemonData.CaugthPokemonDataTable = pokemonTrainerDataSet.Tables[CaugthPokemonData.CAUGHTPOKEMONS_DATATABLE_NAME];

                //foreach (DataRow trainerRow in TrainerData.TrainerDataTable.Rows)
                //{
                //    int trainerID = (int)trainerRow["TrainerID"];
                //}



            }
        }

        /// <summary>
        /// Deze methode initialiseert een NIEUWE trainer DataSet. De methode
        /// roept InitializeTrainderDataTable(), InitializeCaugthPokemonDataTable()
        /// en GetPokemonDataTable() van PokemonData op om de tabellen in de DataSet
        /// te initialiseren.
        /// </summary>
        private static void InitializeNewDataSet()
        {
            TrainerData.InitializeTrainderDataTable();
            CaugthPokemonData.InitializeCaugthPokemonDataTable();
            PokemonData.InitializePokemonDataTable();
            //throw new NotImplementedException();
        }

        // Deze methode exporteert alle gegevens uit de pokemonTrainerDataSet naar een
        // xml bestand, genaamd TRAINER_FILE.


        public static void SaveTrainerDataSet()
        {
            try
            {
                if (pokemonTrainerDataSet != null && pokemonTrainerDataSet.Tables.Count > 0)
                {
                    pokemonTrainerDataSet.WriteXml(TRAINER_FILE);
                }
                else
                {
                    throw new Exception("no data exported");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
