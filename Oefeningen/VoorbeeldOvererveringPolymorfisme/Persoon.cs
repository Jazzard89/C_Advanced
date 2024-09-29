using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VoorbeeldOvererveringPolymorfisme
{
    public class Persoon
    {

        public string Email 
        {
            get { return Email ; }
            set {Email = value; }
        }

        public DateTime GeboorteDatum { get; set; }


        //deze string is virtual omdat deze overschreden moet worden
        public virtual string Gegevens 
        {
            get { return $"{VolledigeNaam()} {GeboorteDatum:D}"; }
            //set { Gegevens = value; } 
        }


        public string Postcode { get; set; }
        public string Straat { get; set; }


        public virtual void Info(string text)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Uw persoonlijke gegevens:");
            sb.AppendLine();
            sb.AppendLine($"Naam {VolledigeNaam()}");
            sb.AppendLine($"Adres: {Straat} {Postcode}");
            sb.AppendLine($"Geboortedatum: {GeboorteDatum}");
            sb.AppendLine($"Email: {Email}");
            throw new Exception(sb.ToString());
        }


        public Persoon()
        {
            //List<string> studentData = Bestandsbewerking.LeesStudenten();
            //Naam = "Orens", "Jasper", ////////, 
        }


        ////////////////////naam data///////////////////////////////////////////////////////////////////////

        public string Naam { get; set; }


        public string Voornaam { get; set; }


        public string VolledigeNaam()
        {
            return $"{Voornaam} {Naam}";
        }
    }
}









//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;

//namespace VoorbeeldOvererveringPolymorfisme
//{
//    public class Persoon
//    {

//        public string Email
//        {
//            get { return Email; }
//            set { Email = value; }
//        }

//        public DateTime GeboorteDatum { get; set; }


//        //deze string is virtual omdat deze overschreden moet worden
//        public virtual string Gegevens
//        {
//            get { return $"{VolledigeNaam()} {GeboorteDatum:D}"; }
//            //set { Gegevens = value; } 
//        }


//        public string Postcode { get; set; }
//        public string Straat { get; set; }


//        public virtual void Info(string text)
//        {
//            //MessageBox.Show(text);
//        }


//        public Persoon()
//        {
//            //List<string> studentData = Bestandsbewerking.LeesStudenten();
//            //Naam = "Orens", "Jasper", ////////, 
//        }


//        ////////////////////naam data///////////////////////////////////////////////////////////////////////

//        public string Naam { get; set; }


//        public string Voornaam { get; set; }


//        public string VolledigeNaam()
//        {
//            return $"{Voornaam} {Naam}";
//        }
//    }
//}
