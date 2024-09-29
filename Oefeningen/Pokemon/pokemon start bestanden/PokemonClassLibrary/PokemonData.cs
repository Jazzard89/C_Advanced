using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClassLibrary
{
    public static class PokemonData
    {
        internal const string POKEMONS_DATATABLE_NAME = "Pokemons";

        private const string POKEMONS_COLUMN_NAME = "Name";
        private const string POKEMONS_COLUMN_NUMBER = "Number";

        private static DataSet pokemonDataSet = new DataSet();
        internal static DataTable PokemonDataTable { get; set; }

        static PokemonData()
        {
            if (!File.Exists(DataBewerking.TRAINER_FILE))
            {
                InitializePokemonDataTable();
            }
        }

        /// <summary>
        /// De data van alle pokemons zit in een Database. Deze methode start een SqlConnectie
        /// en haalt de data op met een SqlDataAdapter en slaat ze vervolgens op in een DataTable.
        /// Neem een kopie van de DataTable die de SqlDataAdapter heeft ge-Fill'ed met .Copy().
        /// </summary>
        public static void InitializePokemonDataTable()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Data.Default.Connection.ToString()))
            {
                SqlCommand cmd = new SqlCommand("select * from pokemons", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);    
                da.Fill(PokemonDataTable);

                foreach (DataRow pokemons in PokemonDataTable.Rows)
                {
                    foreach (DataColumn kolom in PokemonDataTable.Columns)
                    {
                        Console.WriteLine($"{pokemons[kolom].ToString()}");
                    }
                    Console.WriteLine();
                }
            }
            
        }

        // Deze methode geeft een DataView terug van PokemonDataTable
        public static DataView GetPokemonDataView()
        {
            throw new NotImplementedException();
        }

        // Gebruik een LINQ query om alle pokemons te filteren op POKEMONS_COLUMN_NAME.
        // Je kan met de methode .AsDataView() een EnumerableRowCollection<DataRow> omzetten
        // naar een DataView.
        public static DataView GetPokemonDataViewByNameFilter(string filter)
        {
            throw new NotImplementedException();
        }

        // Gebruik een LINQ query om alle pokemon nummers te selecteren. Geef vervolgens
        // het grootst geselecteerde element terug.
        public static int GetMaxPokemonNumber()
        {
            throw new NotImplementedException();
        }
    }
}
