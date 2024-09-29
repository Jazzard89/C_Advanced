using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Navigation;

namespace VoorbeeldOvererveringPolymorfisme
{

    //Field = private var     property = public


    public class Lector : Persoon
    {
        private string afdeling;

        public string Afdeling 
        { 
            get {return afdeling ; } 
            set { afdeling = value; } 
        }


        public override string Gegevens { get { return $"{VolledigeNaam()} {Statuut} {Afdeling}"; } }
        public DateTime Indienst { get; set; }
        //public string Statuut 
        //{
        //    get { return Statuut == "FT" ? "Voltijds" : "Deeltijds"; }
        //    set { Statuut = value; }
        //}

        public string Statuut { get; set; }


        //public string Afdelingsnaam(string afd)
        private string Afdelingsnaam(string afd)
        {
            switch (afd)
            {
                case "IOT":
                    return "Internet of Things";

                case "SNE":
                    return "Systemen en netwerken";

                case "DVG":
                    return "Digitale vormgeving";

                case "PRO":
                    return "Programeren";

                default:
                    return "NIET GEKEND";
            }
        }

        public string AfdrukAdres()
        {
            return $"{VolledigeNaam()} {Straat} {Postcode}";
        }

        public string AfdrukIndienst()
        {
            return $" {VolledigeNaam()} is in dienst sinds: {Indienst:d}";
        }

        public override void Info(string tekst)
        {
            //do something
        }

        public override string ToString()
        {
            return $"{VolledigeNaam()} is {(Statuut == "FT" ? "voltijds" : "deeltijds")} actief";

            //if (Statuut == "FT")
            //{
            //    return $"{VolledigeNaam()} lector is voltijds actief";
            //}
            //else
            //{
            //    return $"{VolledigeNaam()} lector is deeltijds actief";
            //}
        }
    }
}










//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Windows.Navigation;

//namespace VoorbeeldOvererveringPolymorfisme
//{

//    //Field = private var     property = public


//    public class Lector : Persoon
//    {
//        private string afdeling;

//        public string Afdeling
//        {
//            get { return afdeling; }
//            set { afdeling = value; }
//        }


//        public override string Gegevens { get { return $"{VolledigeNaam()} {Statuut} {Afdeling}"; } }
//        public DateTime Indienst { get; set; }
//        public string Statuut { get; set; }


//        //public string Afdelingsnaam(string afd)
//        private string Afdelingsnaam(string afd)
//        {

//            if (afdeling == "SNE")
//            {
//                afd = "Systemen en netwerken";
//            }
//            else if (afdeling == "PRO")
//            {
//                afd = "Programmeren";
//            }
//            else if (afdeling == "DVG")
//            {
//                afd = "Digitale vormgeving";
//            }
//            else
//            {
//                afd = "Internet of Things";
//            }

//            return afd;
//        }

//        public string AfdrukAdres()
//        {
//            return $"{VolledigeNaam()} {Straat} {Postcode}";
//        }

//        public string AfdrukIndienst()
//        {
//            return $" {VolledigeNaam()} is in dienst sinds: {Indienst:d}";
//        }

//        public override void Info(string tekst)
//        {
//            //do something
//        }

//        public override string ToString()
//        {
//            if (Statuut == "FT")
//            {
//                return $"{VolledigeNaam()} lector is voltijds actief";
//            }
//            else
//            {
//                return $"{VolledigeNaam()} lector is deeltijds actief";
//            }
//        }
//    }
//}
