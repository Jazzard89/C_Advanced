using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PokemonClassLibrary
{
    public static class DataBewerking
    {
        internal const string TRAINER_FILE = "trainer.xml";

        private static DataSet pokemonTrainerDataSet;

        // Deze moethode zorgt voor initialisatie van de pokemonTrainerDataSet
        public static void InitializeDataBewerking()
        {
            pokemonTrainerDataSet = new DataSet("TrainerDataSet");

            if (File.Exists(TRAINER_FILE))
            {
                // Lees file met bestaande trainers en gevangen pokemon
                pokemonTrainerDataSet.ReadXml(TRAINER_FILE);
                TrainerData.TrainerDataTable = 
                    pokemonTrainerDataSet.Tables[TrainerData.TRAINERS_DATATABLE_NAME];
                CaugthPokemonData.CaugthPokemonDataTable =
                    pokemonTrainerDataSet.Tables[CaugthPokemonData.CAUGHTPOKEMONS_DATATABLE_NAME];
                PokemonData.PokemonDataTable =
                    pokemonTrainerDataSet.Tables[PokemonData.POKEMONS_DATATABLE_NAME];
            }
            else
            {
                InitializeNewDataSet();
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

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Trainer");
            DataColumn dcTrainerId = new DataColumn("PokémonId", typeof(int));
            DataColumn dcNumber = new DataColumn("Number", typeof(int));
            DataColumn dcName = new DataColumn("Name", typeof(string));
            DataColumn dcType1 = new DataColumn("Type1", typeof(string));
            DataColumn dcType2 = new DataColumn("Type2", typeof(string));
            DataColumn dcTotal = new DataColumn("Total", typeof(int));
            DataColumn dcHP = new DataColumn("HP", typeof(int));
            DataColumn dcAttack = new DataColumn("Attack", typeof(int));
            DataColumn dcDefence = new DataColumn("Defence", typeof(int));
            DataColumn dcSp_Atk = new DataColumn("Sp_Atk", typeof(int));
            DataColumn dcSp_Def = new DataColumn("Sp_Def", typeof(int));
            DataColumn dcSpeed = new DataColumn("Speed", typeof(int));
            DataColumn dcGeneration = new DataColumn("Generation", typeof(int));
            DataColumn dcLegendary = new DataColumn("Legendary", typeof(int));    

            dt.Columns.Add(dcTrainerId);
            dt.Columns.Add(dcNumber);
            dt.Columns.Add(dcName);
            dt.Columns.Add(dcType1);
            dt.Columns.Add(dcType2);
            dt.Columns.Add(dcTotal);
            dt.Columns.Add(dcHP);
            dt.Columns.Add(dcAttack);
            dt.Columns.Add(dcDefence);
            dt.Columns.Add(dcSp_Atk);
            dt.Columns.Add(dcSp_Def);
            dt.Columns.Add(dcSpeed);
            dt.Columns.Add(dcGeneration);
            dt.Columns.Add(dcLegendary);

            DataColumn[] primaryKey = { dcTrainerId };
            dt.PrimaryKey = primaryKey;

        }

        // Deze methode exporteert alle gegevens uit de pokemonTrainerDataSet naar een
        // xml bestand, genaamd TRAINER_FILE.
        public static void SaveTrainerDataSet()
        {
            throw new NotImplementedException();
        }
    }
}
