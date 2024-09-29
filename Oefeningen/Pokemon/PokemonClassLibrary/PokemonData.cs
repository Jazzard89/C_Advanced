using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
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

        public static void GetPokemonDataTable()
        {
            InitializePokemonDataTable();
        }

        /// <summary>
        /// De data van alle pokemons zit in een Database. Deze methode start een SqlConnectie
        /// en haalt de data op met een SqlDataAdapter en slaat ze vervolgens op in een DataTable.
        /// Neem een kopie van de DataTable die de SqlDataAdapter heeft ge-Fill'ed met .Copy().
        /// </summary>
        public static void InitializePokemonDataTable()
        {

            PokemonDataSettings settings = new PokemonDataSettings();
            string cn = settings.ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(cn);
            sqlConnection.Open();

            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {

                /// en haalt de data op met een SqlDataAdapter en slaat ze vervolgens op in een DataTable.
                /// Neem een kopie van de DataTable die de SqlDataAdapter heeft ge-Fill'ed met .Copy().
                PokemonDataTable = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "select * from pokemons";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(PokemonDataTable); //.Copy()
                PokemonDataTable.TableName = POKEMONS_DATATABLE_NAME;
            }
            else
            {
                throw new Exception("Connection not open");
            }

            //throw new NotImplementedException();
        }

        // Deze methode geeft een DataView terug van PokemonDataTable
        public static DataView GetPokemonDataView()
        {
            DataView
            dv = new DataView(PokemonDataTable);
            return dv;
        }

        // Gebruik een LINQ query om alle pokemons te filteren op POKEMONS_COLUMN_NAME.
        // Je kan met de methode .AsDataView() een EnumerableRowCollection<DataRow> omzetten
        // naar een DataView.
        public static DataView GetPokemonDataViewByNameFilter(string filter)
        {
            var filteredPokemons = (
                from pokemon in PokemonDataTable.AsEnumerable()
                where pokemon.Field<string>(POKEMONS_COLUMN_NAME).Contains(filter)
                select pokemon);

            return filteredPokemons.AsDataView();
        }


        // Gebruik een LINQ query om alle pokemon nummers te selecteren. Geef vervolgens
        // het grootst geselecteerde element terug.
        public static int GetMaxPokemonNumber()
        {
            if (PokemonDataTable.Rows != null)
            {
                var maxPokemonNumber = (from pokemon in PokemonDataTable.AsEnumerable()
                                        select Convert.ToInt32(pokemon["PokemonId"])).Max();


                //var maxPokemonNumber = (from pokemon in PokemonDataTable.AsEnumerable()
                //                        select pokemon.Field<int>("PokemonId")).Max();

                //var maxPokemonNumber = PokemonDataTable.AsEnumerable().Max(pokemon => pokemon.Field<int>("PokemonId"));
                return maxPokemonNumber;
            }
            else
            {
                return 1; //dit is mogelijk fout
            }


        }
    }
}
