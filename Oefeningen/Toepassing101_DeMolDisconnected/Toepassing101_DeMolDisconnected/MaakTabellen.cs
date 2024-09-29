using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing101_DeMolDisconnected
{
    internal static class MaakTabellen
    {
        //maak database en tabellen
        static DataSet ds = new DataSet("DeMolDS");
        public static DataTable dtSpelers = new DataTable("Spelers"); //moest static zijn omdat de class static is en we moesten er aan komen 

        public static DataTable dtSpellen = new DataTable("Spellen");


        public static void MaakTabellenMethod()
        {


            DataColumn SpelId = new DataColumn("SpelId ", typeof(int)); //PK
            DataColumn Jaar = new DataColumn("Jaar", typeof(int));
            DataColumn Locatie = new DataColumn("Locatie", typeof(string));

            //add de koloms
            dtSpellen.Columns.Add(SpelId);
            dtSpellen.Columns.Add(Jaar);
            dtSpellen.Columns.Add(Locatie);

            DataColumn SpelerId = new DataColumn("SpelerId", typeof(int)); //PK
            DataColumn SpelId_Spelers = new DataColumn("SpelId ", typeof(int)); //FK anderenaam in C@ niet in tabel
            DataColumn Naam = new DataColumn("Naam", typeof(string));
            DataColumn Wachtwoord = new DataColumn("Wachtwoord", typeof(string));
            DataColumn IsMol = new DataColumn("IsMol", typeof(bool));
            DataColumn LeeftijdTijdensDeelname = new DataColumn("LeeftijdTijdensDeelname", typeof(int));
            DataColumn Beroep = new DataColumn("Beroep ", typeof(string));

            //add de koloms
            dtSpelers.Columns.Add(SpelerId);
            dtSpelers.Columns.Add(SpelId_Spelers);
            dtSpelers.Columns.Add(Naam);
            dtSpelers.Columns.Add(Wachtwoord);
            dtSpelers.Columns.Add(IsMol);
            dtSpelers.Columns.Add(LeeftijdTijdensDeelname);
            dtSpelers.Columns.Add(Beroep);

            //PrimaryKey
            dtSpellen.PrimaryKey = new DataColumn[] { dtSpellen.Columns["SpelId"] };
            dtSpelers.PrimaryKey = new DataColumn[] { dtSpelers.Columns["SpelerId"] };

            //Dataset in Database zetten
            ds.Tables.Add(dtSpellen);
            ds.Tables.Add(dtSpelers);

            //vul databases
            dtSpellen.Rows.Add(0, 1999, "Frankrijk");
            dtSpellen.Rows.Add(1, 2000, "Spanje");
            dtSpellen.Rows.Add(2, 2003, "Italië");
            dtSpellen.Rows.Add(3, 2015, "Argentië");
            dtSpellen.Rows.Add(9, 2020, "Duitsland");

            dtSpelers.Rows.Add(0, 0, "Magda Ral", "RaldeMag", 1, 40, "Reisleidster");
            dtSpelers.Rows.Add(1, 0, "Hugo De Bie", "hug000", 0, 43, "Personeelschef");
            dtSpelers.Rows.Add(2, 0, "Mon De Ridder", "r1dm1mon", 0, 60, "Gepensioneerd leraar");
            dtSpelers.Rows.Add(3, 0, "Guy Peers", "G00dGuy", 0, 41, "Zaakvoerder");
            dtSpelers.Rows.Add(4, 0, "Belle Seurs", "Wachtwoord123", 0, 31, "Zangeres");
            dtSpelers.Rows.Add(5, 0, "Sylvie De Clercq", "SuperSylvie", 0, 24, "Romaniste");
            dtSpelers.Rows.Add(6, 0, "Moniek Van de Velde", "M0n1ECK", 0, 43, "Ballonvaarder");
            dtSpelers.Rows.Add(7, 0, "Reggy Samyn", "GJLlma421", 0, 37, "Cafébaas");
            dtSpelers.Rows.Add(8, 0, "Anke Van Berendoncks", "qd68wùé3", 0, 22, "Fotograaf");
            dtSpelers.Rows.Add(9, 0, "Dimi Claeys", "jkecvzs!!!", 0, 24, "Creatief therapeut");
            dtSpelers.Rows.Add(10, 1, "Hugo Daemen", "NotMol!", 1, 67, "Gepensioneerd kolonel");
            dtSpelers.Rows.Add(11, 1, "Marianne Dupon", "BornToWin", 0, 28, "Crisismanager");
            dtSpelers.Rows.Add(12, 1, "Niki De Boeck", "toeasy", 0, 49, "Kinesiste");
            dtSpelers.Rows.Add(13, 1, "Carine Leroy", "helderdenken", 0, 33, "Bediende");
            dtSpelers.Rows.Add(14, 1, "David Devogele", "IhaveADream", 0, 24, "Student marketing");
            dtSpelers.Rows.Add(15, 1, "Eef Mahauden", "QSfsmiamknw", 0, 20, "Studente archeologie");
            dtSpelers.Rows.Add(16, 1, "Dominiek Roosen", "R35DS6?5M34", 0, 30, "Opvoeder");
            dtSpelers.Rows.Add(17, 1, "Luc Schelfaut", "16q313XXXfg", 0, 51, "Chauffeur");
            dtSpelers.Rows.Add(18, 1, "Marie-Rose Mels", "PXM5?33µmlm", 0, 45, "Zelfstandige");
            dtSpelers.Rows.Add(19, 1, "Bart Debbaut", "6549873156987", 0, 28, "Adjunct-bankdirecteur");
            dtSpelers.Rows.Add(20, 2, "Marc Simons", "NotMol!", 1, 45, "Verzekeraar");
            dtSpelers.Rows.Add(21, 2, "Stijn Vandaele", "3vqDdv69ZCCw5qR6", 0, 22, "Student sinologie");
            dtSpelers.Rows.Add(22, 2, "Sandra Welvaert", "XNgkcm6BWPywE6B4", 0, 30, "Gerante kledingzaak");
            dtSpelers.Rows.Add(23, 2, "Inge Boere", "sbf46brv4beeSdTq", 0, 35, "Dierenarts");
            dtSpelers.Rows.Add(24, 2, "Shadia Bellafkih", "xGDczqTkrjAzRPMc", 0, 25, "IT-specialist");
            dtSpelers.Rows.Add(25, 2, "Corry Deltour", "W3CBdxWapWAxtd8W", 0, 39, "Bediende");
            dtSpelers.Rows.Add(26, 2, "Walter Sap", "HgRuxcuLKGAPpErr", 0, 50, "Postbode");
            dtSpelers.Rows.Add(27, 2, "Bruno De Roover", "PxKrRmvXASPuwRXG", 0, 30, "Striptekenaar");
            dtSpelers.Rows.Add(28, 2, "Nicole Van Herck", "Hvd7M3F7AEUrrTxf", 0, 41, "Bediende");
            dtSpelers.Rows.Add(29, 2, "Christophe Grosjean", "ARqScaBHd36uGd2S", 0, 34, "Manager");
            dtSpelers.Rows.Add(30, 9, "Annelotte De Brandt", "AKDdzk3mC66Z2mb2", 1, 25, "Recruiter");
            dtSpelers.Rows.Add(31, 9, "Lennart Driesen", "rrEM9xt3Z74ZUrrz", 0, 25, "Opvoeder");
            dtSpelers.Rows.Add(32, 9, "Sven Uyttersprot", "GAgS5mPQBQA5bQPz", 0, 41, "Horeca-uitbater");
            dtSpelers.Rows.Add(33, 9, "Philip De Cleen", "gCMPpvVSbggG3wnC", 0, 51, "Docent marketing");
            dtSpelers.Rows.Add(34, 9, "Jasmien Foré", "FKK6R2Fv39sbzqsb", 0, 30, "Advocate");
            dtSpelers.Rows.Add(35, 9, "Samina Carremans", "d6w8rfSaq2YuAsJJ", 0, 42, "Flamencolerares");
            dtSpelers.Rows.Add(36, 9, "Katrien Cuppens", "5hLZ4Gpbe2XZJDwG", 0, 39, "Vaatchirurg");
            dtSpelers.Rows.Add(37, 9, "Noah Vlieghe", "y62srZqk4s3BsW4k", 0, 18, "Student orthopedagogie");
            dtSpelers.Rows.Add(38, 9, "Kevin Cuykens", "eankrbWRE4qwaUCJ", 0, 30, "Jurist");
            dtSpelers.Rows.Add(39, 9, "Dami Oguntubi", "8xs9RVhvY8k36rZg", 0, 20, "Studente psychologie");
            dtSpelers.Rows.Add(40, 9, "Jens Zutterman", "5hLZ4Gpbe2XZJDwG", 0, 30, "Schrijnwerker");





            //datarelations
            //DataRelation dtSpelers_dtSpellen_FK = ds.Relations.Add("Spelid", dtSpellen.Columns["SpelId"], dtSpelers.Columns["SpelId"]);
        }



        //public DataSet ds 
        //{
        //    get { return new DataSet("DeMolDS"); ; }
        //    set { ds = value; } 
        //}

    }
}
