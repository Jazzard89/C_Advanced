using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClassLibrary
{
    public static class CaugthPokemonData
    {
        internal const string CAUGHTPOKEMONS_DATATABLE_NAME = "CaughtPokemons";

        private const string CAUGHTPOKEMONS_COLUMN_ID = "CaughtPokemonId";
        private const string CAUGHTPOKEMONS_COLUMN_POKEMON_ID = "PokemonId";
        private const string CAUGHTPOKEMONS_COLUMN_TRAINER_ID = "TrainerId";

        internal static DataTable CaugthPokemonDataTable { get; set; }

        static CaugthPokemonData()
        {
            if (!File.Exists(DataBewerking.TRAINER_FILE))
            {
                InitializeCaugthPokemonDataTable();
            }
        }

        // Maak een DataTable aan met drie kolommen: CAUGHTPOKEMONS_COLUMN_ID (int),
        // CAUGHTPOKEMONS_COLUMN_POKEMON_ID (string) en CAUGHTPOKEMONS_COLUMN_TRAINER_ID (string).
        // Gebruik de constante die bovenaan in de klasse gegeven zijn.
        public static void InitializeCaugthPokemonDataTable()
        {
            DataColumn dcCaughtPokemonId = new DataColumn("CaughtPokemonId", typeof(int));
            DataColumn dcTrainerId = new DataColumn("TrainerId", typeof(int));
            DataColumn dcPokemonId = new DataColumn("PokemonId", typeof(int));

            CaugthPokemonDataTable.Columns.Add(dcCaughtPokemonId);
            CaugthPokemonDataTable.Columns.Add(dcTrainerId);
            CaugthPokemonDataTable.Columns.Add(dcPokemonId);

            DataColumn[] primaryKey = { dcCaughtPokemonId };
            CaugthPokemonDataTable.PrimaryKey = primaryKey; 
        }

        // Gebruik een LINQ query om een verzameling van alle caughtPokemonId's te
        // selecteren. Geef vervolgens het hoogste id terug en tel er één bij op.
        private static int GetNextCaugthPokemonId()
        {
            throw new NotImplementedException();
        }

        // Gebruik LINQ om alle pokemon nummers van alle pokemon te selecteren 
        // die gevangen zijn voor het gegeven trainerId.
        // Je kan de methode .ToList() gebruiken om een EnumerableRowCollection<> om
        // te zetten naar een List<>
        public static List<int> GetCaugthPokemonIdsByTrainerId(int trainerId)
        {
            throw new NotImplementedException();
        }

        // Gebruik GetNextCaugthPokemonId en de gegeven argumenten om een nieuwe
        // rij toe te voegen aan de CaugthPokemonDataTable.
        public static void CatchPokemon(int trainerid, int pokemonNumber)
        {
            throw new NotImplementedException();
        }

    }
}
