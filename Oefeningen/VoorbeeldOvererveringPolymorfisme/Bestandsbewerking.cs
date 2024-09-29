using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace VoorbeeldOvererveringPolymorfisme
{
    public static class Bestandsbewerking
    {

        //public static List <string> LeesStudenten()
        public static List <Studenten> LeesStudenten()
        {
            List<Studenten> student = new List<Studenten>();
            using (StreamReader sr = new StreamReader("Studenten.csv"))
            {
                while (!sr.EndOfStream)
                {
                    Studenten stud = new Studenten();
                    string[] waarde = sr.ReadLine().Split(';');
                    stud.Naam= waarde[0];
                    stud.Voornaam= waarde[1];
                    stud.Straat= waarde[2];
                    stud.Postcode= waarde[3];
                    stud.Betaald = waarde[4][0];
                    stud.Opleiding = waarde[5];
                    stud.TypeStudent= waarde[6];
                    if(stud.TypeStudent == "I")
                        stud.Studiepunten = int.Parse(waarde[7]);
                    student.Add(stud);
                }
            }
            return student;
        }

        public static List <Lector> LeesLectoren()
        {
            List<Lector> lectoren = new List<Lector>();
            using (StreamReader sr = new StreamReader("Lectoren.csv"))
            {
                while (!sr.EndOfStream)
                {
                        Lector lect = new Lector();
                        string [] waarde = sr.ReadLine().Split(';');
                        lect.Naam= waarde[0];
                        lect.Voornaam = waarde[1];
                        lect.GeboorteDatum = DateTime.Parse(waarde[2]);
                        lect.Straat= waarde[3];
                        lect.Postcode= waarde[4];
                        lect.Statuut= waarde[5];
                        lect.Afdeling= waarde[6];
                        lect.Indienst = DateTime.Parse(waarde[7]);
                        //
                        
                        lectoren.Add(lect);
                }
            }
            return lectoren;
        }
    }
}





//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Documents;

//namespace VoorbeeldOvererveringPolymorfisme
//{
//    public static class Bestandsbewerking
//    {

//        //public static List <string> LeesStudenten()
//        public static List<string> LeesStudenten()
//        {
//            List<string> student = new List<string>();
//            using (StreamReader sr = new StreamReader("Studenten.csv"))
//            {
//                while (!sr.EndOfStream)
//                {
//                    student.Add(sr.ReadLine());
//                }
//            }
//            return student;
//        }

//        public static List<string> LeesLectoren()
//        {
//            List<string> lector = new List<string>();
//            using (StreamReader sr = new StreamReader("Lectoren.csv"))
//            {
//                while (!sr.EndOfStream)
//                {
//                    lector.Add(sr.ReadLine());
//                }
//            }
//            return lector;
//        }
//    }
//}
