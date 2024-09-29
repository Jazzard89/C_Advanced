using ClassLibTransportmiddelen.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTransportmiddelen.DataAccess
{
    public static class VoertuigData
    {
        public static string bestandsLocatie;
        public static DataTable Fietsen { get; set; }
        public static DataTable Autos { get; set; }
        public static void LeesBestand(string bestand)
        {
            //Deze methode maakt gebruik van de methode ControleBestand om te controleren of
            //het opgegeven bestand de juiste structuur bevat.
            //Daarnaast worden 2 datatables aangemaakt, eentje voor fietsen en eentje voor auto's
            //Tenslote wordt het bestand ingelezen en wordt een rij aangemaakt in de juiste datatable.
        }

        private static void ControleBestand()
        {
            //Deze methode controleert of het bestand een correcte indeleing heeft.
            //Een correcte indeling beetekent dat elke fiets rij 5 velden moet
            //bevatten en elke auto rij 6 velden. indien dit niet het geval is,

            //moet er een exception van het type OngeldigBestand worden aangemaakt
            //Deze methode verwacht geen parameters en geft ook niets terug!
            //OPgelet: deze methode mag enkel binnen de klasse voertuigdata worden opgenomen

            try
            {

            }
            catch
            {
                OngeldigBestand ongeldigBestand = new OngeldigBestand();
                throw ongeldigBestand;
            }
        }

        public static List<Fiets> GetFietsList()
        {
            //Deze methode zet de data uit de fietsen datatabel om naar een lijst van fiets objecten.
            Fietsen = new DataTable();
            var fietsenVar = (
                from fietsen in Fietsen.AsEnumerable()
                select fietsen).ToList();

            List<Fiets> fietsenList = new List<Fiets>();

            foreach (DataRow dr in fietsenVar)
            {
                //string type, string omschrijving, double aankoopprijs, int kilometerStand, DateTime aankoopDatum
                Fiets fietser = new Fiets(dr[1].ToString(), dr[2].ToString(), Convert.ToDouble(dr[3]), Convert.ToInt32(dr[4]), Convert.ToDateTime(dr[5]));
                fietsenList.Add(fietser);
            }


            return fietsenList;
        }

        public static List<Auto> GetAutoList()
        {
            //Deze methode zet de data uit de autos datatable om naar een lijst van auto objecten.

            Autos = new DataTable();
            var AutoVar = (
                from autos in Autos.AsEnumerable()
                select autos).ToList();

            List<Auto> autoList = new List<Auto>();

            foreach (DataRow dr in AutoVar)
            {
                //string type, string omschrijving, double aankoopprijs, int kilometerStand, bool ongevalvrij, string aandrijving) : base(type, omschrijving, aankoopprijs, kilometerStand)
                Auto autos = new Auto(dr[1].ToString(), dr[2].ToString(), Convert.ToDouble(dr[3]), Convert.ToInt32(dr[4]), Convert.ToBoolean(dr[5]), dr[6].ToString());
                autoList.Add(autos);
            }


            return autoList;
        }
    }
}
