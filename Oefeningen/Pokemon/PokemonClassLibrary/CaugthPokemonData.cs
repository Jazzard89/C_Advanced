﻿using System;
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

        public static DataTable CaugthPokemonDataTable { get; set; }

        static CaugthPokemonData()
        {
            if (!File.Exists(DataBewerking.TRAINER_FILE))
            {
                InitializeCaugthPokemonDataTable();
            }
            else
            {

            }
        }

        // Maak een DataTable aan met drie kolommen: CAUGHTPOKEMONS_COLUMN_ID (int),
        // CAUGHTPOKEMONS_COLUMN_POKEMON_ID (string) en CAUGHTPOKEMONS_COLUMN_TRAINER_ID (string).
        // Gebruik de constante die bovenaan in de klasse gegeven zijn.
        public static void InitializeCaugthPokemonDataTable()
        {
            CaugthPokemonDataTable = new DataTable();
            CaugthPokemonDataTable.TableName = CAUGHTPOKEMONS_DATATABLE_NAME;
            CaugthPokemonDataTable.Columns.Add(CAUGHTPOKEMONS_COLUMN_ID, typeof (int));
            CaugthPokemonDataTable.Columns.Add(CAUGHTPOKEMONS_COLUMN_POKEMON_ID, typeof(string));
            CaugthPokemonDataTable.Columns.Add(CAUGHTPOKEMONS_COLUMN_TRAINER_ID, typeof(string));
            //throw new NotImplementedException();
        }

        // Gebruik een LINQ query om een verzameling van alle caughtPokemonId's te
        // selecteren. Geef vervolgens het hoogste id terug en tel er één bij op.
        private static int GetNextCaugthPokemonId()
        {
            var caughtPokemonId = (
                from pokemonId in CAUGHTPOKEMONS_COLUMN_POKEMON_ID
                select pokemonId
                ).Max() + 1;

            return caughtPokemonId;
            //throw new NotImplementedException();
        }

        // Gebruik LINQ om alle pokemon nummers van alle pokemon te selecteren 
        // die gevangen zijn voor het gegeven trainerId.
        // Je kan de methode .ToList() gebruiken om een EnumerableRowCollection<> om
        // te zetten naar een List<>

        public static List<int> GetCaugthPokemonIdsByTrainerId(int trainerId)
        {
            var caughtPokemons = (
                from pokemon in CaugthPokemonDataTable.AsEnumerable()
                where Convert.ToInt32(pokemon.Field<string>(CAUGHTPOKEMONS_COLUMN_TRAINER_ID)) == trainerId
                select Convert.ToInt32(pokemon.Field<string>(CAUGHTPOKEMONS_COLUMN_POKEMON_ID))).ToList();

            return caughtPokemons;
        }




        // Gebruik GetNextCaugthPokemonId en de gegeven argumenten om een nieuwe
        // rij toe te voegen aan de CaugthPokemonDataTable.
        public static void CatchPokemon(int trainerid, int pokemonNumber)
        {
            CaugthPokemonDataTable.Rows.Add(GetNextCaugthPokemonId(), pokemonNumber, trainerid);
            //throw new NotImplementedException();
        }

    }
}