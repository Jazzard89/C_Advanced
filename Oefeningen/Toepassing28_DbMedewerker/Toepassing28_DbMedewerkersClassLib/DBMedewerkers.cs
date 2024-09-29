using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing28_DbMedewerkersClassLib
{
    public class DBMedewerkers
    {
        public static Medewerker ZoekMnr(int MnrId, string connectionString)
        {
            using (SqlConnection sqlcnn = (DBConnect.MaakConnectie(connectionString)))
            {
                sqlcnn.Open();
                //select * from Medewerkers where mnr = 7788
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcnn;

                cmd.CommandText = $@"select * from Medewerkers where mnr = @mdwId";
                cmd.Parameters.AddWithValue("@mdwId", MnrId);

                //comando uitvoeren
                SqlDataReader rdr = cmd.ExecuteReader();
                //in class steken
                if (rdr.Read())
                {
                    Medewerker mdw = new Medewerker();
                    //geef alle info van mdw
                    mdw.MnrID = MnrId;
                    mdw.Voornaam = Convert.ToString(rdr["voorn"]); //manier 1 voor om te zetten in string
                    mdw.Naam = rdr["naam"].ToString(); //manier 2 voor om te zetten in sring
                    mdw.Functie = (string)rdr["functie"]; //manier 3 voor om te zetten in string
                    mdw.GbDatum = (DateTime)rdr["gbdatum"];
                    mdw.Maandsalaris = Convert.ToSingle(rdr["maandsal"]);
                    if (rdr["comm"] == DBNull.Value) //kan ook rdr["comm"].ToString() == ""
                    {
                        mdw.Comm = 0;
                    }
                    else
                    {
                        mdw.Comm = Convert.ToSingle(rdr["comm"]);
                    }
                    mdw.Afdeling = Convert.ToInt32(rdr["afd"]);
                    mdw.Chef = rdr["chef"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["chef"]); //zelfde if als er boven

                    return mdw;

                }
                else { return null; }

                //sqlcnn.Close(); <- niet nodig omdat we in using zitten
            }


        }

        public static bool UpdateMedewerker(Medewerker oud, Medewerker nieuw, string connectionString)
        {
            using (SqlConnection sqlcnn = (DBConnect.MaakConnectie(connectionString)))
            {
                sqlcnn.Open();

                SqlCommand updCmd = new SqlCommand();
                updCmd.Connection = sqlcnn;
                updCmd.CommandText =
                    "update medewerkers " +
                    "set naam = @naam, naamvoorn = @voornaam " +
                    "where mnr = @mnr ";
                updCmd.Parameters.AddWithValue("@naam", nieuw.Naam);
                updCmd.Parameters.AddWithValue("@voorn", nieuw.Voornaam);
                updCmd.Parameters.AddWithValue("@mnr", oud.MnrID);
                //voor de bool moeten we dit
                int aantalGewijzigdeRijen = updCmd.ExecuteNonQuery();
                /*if (aantalGewijzigdeRijen > 0) //methode 1
                {
                    return true;
                }
                else
                {
                    return false;
                }*/
                return (updCmd.ExecuteNonQuery() > 0); //methode 2
            }
        }

        public static int ToevoegenMedewerker(Medewerker Medewerker, string connectionString) //int omdat het mnr is
        {
            using (SqlConnection sqlcnn = (DBConnect.MaakConnectie(connectionString)))
            {
                sqlcnn.Open();

                SqlCommand inscCmd = new SqlCommand();
                inscCmd.Connection = sqlcnn;
                inscCmd.CommandText =
                    "insert into medewerkers " +
                    "mnr, naam, voorn, functie, chef, gbdatum, maandsal, comm, afd ) " +
                    "values (@mnr, @naam, @voornaam, @functie, @chef, @gbdatum, @maandsal, @comm, @afd )";

                inscCmd.Parameters.AddWithValue("@mnr", Medewerker.MnrID);
                inscCmd.Parameters.AddWithValue("@naam", Medewerker.Naam);
                inscCmd.Parameters.AddWithValue("@voornaam", Medewerker.Voornaam);
                inscCmd.Parameters.AddWithValue("@functie", Medewerker.Functie);
                inscCmd.Parameters.AddWithValue("@chef", Medewerker.Chef);
                inscCmd.Parameters.AddWithValue("@gbdatum", Medewerker.GbDatum);
                inscCmd.Parameters.AddWithValue("@maandsal", Medewerker.Maandsalaris);
                if (Medewerker.Functie != "VERKOPER")
                {
                    inscCmd.Parameters.AddWithValue("@comm", DBNull.Value);
                }
                else
                {
                    inscCmd.Parameters.AddWithValue("@comm", Medewerker.Comm);
                }

                inscCmd.Parameters.AddWithValue("@afd", Medewerker.Afdeling);

                return inscCmd.ExecuteNonQuery();

            }
        }

        public static bool VerwijderMedewerker(Medewerker Medewerker, string connectionString)
        {
            using (SqlConnection sqlcnn = (DBConnect.MaakConnectie(connectionString)))
            {
                sqlcnn.Open();

                SqlCommand inscCmd = new SqlCommand();
                inscCmd.Connection = sqlcnn;
                inscCmd.CommandText = "DELETE FROM Medewerkers WHERE mnr = @mnr";
                inscCmd.Parameters.AddWithValue("@mnr", Medewerker.MnrID);
                return inscCmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
