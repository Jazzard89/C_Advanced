using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClassLibrary
{
    public static class TrainerData
    {
        public const string TRAINERS_DATATABLE_NAME = "Trainers";
        private const string TRAINERS_COLUMN_ID = "TrainerId";
        private const string TRAINERS_COLUMN_NAME = "TrainerName";
        private const string TRAINERS_COLUMN_PASSWORD = "TrainerPass";

        public static DataTable TrainerDataTable { get; set; }

        /// <summary>
        /// In de statische constructor verzekeren we dat de DataTable
        /// geïnitialiseerd is.
        /// </summary>
        static TrainerData()
        {
            if (!File.Exists(DataBewerking.TRAINER_FILE))
            {
                InitializeTrainderDataTable();
            }
            else
            {
                return;
            }
        }

        // Maak een DataTable aan met drie kolommen: trainerId (int), trainerName (string)
        // en trainerPassword (string). Gebruik de constante die bovenaan in de klasse 
        // gegeven zijn.
        public static void InitializeTrainderDataTable()
        {
            TrainerDataTable = new DataTable();
            TrainerDataTable.TableName = TRAINERS_DATATABLE_NAME;
            TrainerDataTable.Columns.Add(TRAINERS_COLUMN_ID, typeof(int));
            TrainerDataTable.Columns.Add(TRAINERS_COLUMN_NAME, typeof(string));
            TrainerDataTable.Columns.Add(TRAINERS_COLUMN_PASSWORD, typeof(string));

            TrainerDataTable.Rows.Add(0, "jasper", "jasper");

            //throw new NotImplementedException();
        }

        // Gebruik de methodes van het disconnected ADO.NET model om een nieuwe
        // rij toe te voegen aan de DataTable. Gebruik GetNextTrainerId() om het correct 
        // TrainerId te vinden voor de DataRow.
        public static void CreateTrainer(string trainerName, string password)
        {
            TrainerDataTable.Rows.Add(GetNextTrainerId(), trainerName, password);
            //throw new NotImplementedException();
        }

        // Gebruik een LINQ query om een verzameling van alle trainerId's te
        // selecteren. Geef vervolgens het hoogste id terug en tel er één bij op.
        private static int GetNextTrainerId()
        {

            int trainerIds = TrainerDataTable.AsEnumerable().Max(trainer => Convert.ToInt32(trainer[TRAINERS_COLUMN_ID]));



            if (trainerIds == 0)
            {
                return 1;
            }
            else
            {
                return trainerIds + 1;
            }


            //throw new NotImplementedException();
        }

        // Gebruik een LINQ query om een verzameling van trainers te selecteren
        // die de gegeven naam en wachtwoord hebben. Vervolgens controleer je of
        // er meer dan nul trainers geselecteerd zijn.
        public static bool CheckTrainerLogin(string trainerName, string password)
        {
            //var trainerCollectie = (
            //    from allTrainerNames in TrainerDataTable.Columns[TRAINERS_COLUMN_NAME].ToString()
            //    from allTrainerPasswords in TrainerDataTable.Columns[TRAINERS_COLUMN_PASSWORD].ToString()
            //    where allTrainerNames.ToString() == trainerName
            //    && allTrainerPasswords.ToString() == password
            //    select allTrainerNames);

            //if (trainerCollectie == null)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}

            var matchingTrainersExist = TrainerDataTable.AsEnumerable()
            .Any(trainers => trainers.Field<string>(TRAINERS_COLUMN_NAME) == trainerName &&
             trainers.Field<string>(TRAINERS_COLUMN_PASSWORD) == password);

            return matchingTrainersExist;



            //throw new NotImplementedException();
        }

        // Gebruik een LINQ query om een verzameling van trainers te selecteren met de
        // gegeven naam. Vervolgens controleer je of er exact nul trainers zijn geselecteerd.
        public static bool CheckUniqueTrainerName(string trainerName)
        {
            var matchingTrainersExist = TrainerDataTable.AsEnumerable()
                .Any(trainers => trainers.Field<string>(TRAINERS_COLUMN_NAME) == trainerName);

            if (!matchingTrainersExist)
            {
                return true;
            }
            else
            {
                return false;
            }
            //throw new NotImplementedException();
        }

        // Gebruik een LINQ query om een verzameling van id's (int) te selecteren uit
        // de DataTable van TrainerData. Geef vervolgens het eerste element terug.
        public static int GetTrainerIdByTrainerName(string trainerName)
        {
            var idVerzameling = (
                from ids in TrainerDataTable.Columns[TRAINERS_COLUMN_ID].ToString()
                from trainers in TrainerDataTable.Columns[TRAINERS_COLUMN_NAME].ToString()
                where trainers.ToString() == trainerName
                select ids).DefaultIfEmpty();

            int intIds = Convert.ToInt32(idVerzameling.First());

            return intIds;
            //throw new NotImplementedException();
        }
    }
}
