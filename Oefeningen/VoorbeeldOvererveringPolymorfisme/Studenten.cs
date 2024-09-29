using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Navigation;

namespace VoorbeeldOvererveringPolymorfisme
{
    public class Studenten : Persoon
    {

        //we maken een private hiervoor

        private float inschrijvingsbedrag;
        public float Inschrijvingsbedrag 
        { get 
            {
                if (TypeStudent == "G")
                {
                    return 520;
                }
                else
                {
                    return 50f + (8.6667f * Studiepunten);
                }
            } 
        }

        private int studiepunten;

        public int Studiepunten
        {
            get 
            {
                if (TypeStudent == "I")
                {
                    return studiepunten;
                }
                else
                { 
                    return 60;
                }
            }
            
            set
            {
                if (value < 0)
                {
                    studiepunten= 0;
                }
                else if (value > 99)
                {
                    studiepunten= 99;
                }
                else
                {
                    studiepunten = value;
                }
                studiepunten = value;
            }
        }

        //public string Betaald 
        public char Betaald { get; set; }
        public override string Gegevens { get { return $"{VolledigeNaam()} {TypeStudent} {Betaald} {Inschrijvingsbedrag}"; } }


        public string Opleiding { get; set; }
        public DateTime StartDatum { get; set; }


        public string TypeStudent { get; set; }
    


        public string AfdrukAdres()
        {
            throw new NotImplementedException();
            //return $"{Studenten.VolledigeNaam()} {Studenten.Straat} {Studenten.Postcode}";
        }
        public string AfdrukStartDatum()
        {
            return $"{VolledigeNaam()} {StartDatum}";
        }
        public override void Info(string tekst)
        {
            base.Info(tekst);
        }

        //Constructor moet dezelfde naam hebben als klasse,
        //Maakt object van klasse
        public Studenten()// : base()
        {
            //construcotr
            StartDatum = DateTime.Now;
        }

        //de benaming ToString werkt niet
        public override string ToString()
        {
            //Er moet altijd een return zijn daarom exception, 
            if (TypeStudent == "I")
            {
                return $"Student met individueel traject: {Studiepunten} SP-  Inschrijvingsgeld: {Inschrijvingsbedrag:c} : Betaald: {Betaald}";
            }
            else
            {
                return $"Standaardstudent: {Studiepunten} SP-  Inschrijvingsgeld: {Inschrijvingsbedrag:c} : Betaald: {Betaald}";
            }
        }
    }
}






//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.IO;
//using System.Windows.Navigation;

//namespace VoorbeeldOvererveringPolymorfisme
//{
//    public class Studenten : Persoon
//    {

//        //we maken een private hiervoor

//        private float inschrijvingsbedrag;
//        public float Inschrijvingsbedrag { get { return inschrijvingsbedrag; } }

//        private int studiepunten;

//        public int Studiepunten
//        {
//            get { return studiepunten; }
//            set { studiepunten = value; }
//        }

//        //public string Betaald 
//        public char Betaald { get; set; }
//        public override string Gegevens { get { return $"{VolledigeNaam()} {TypeStudent} {Betaald} {Inschrijvingsbedrag}"; } }


//        public string Opleiding { get; set; }
//        public DateTime StartDatum { get; set; }


//        private string typeStudent;

//        public string TypeStudent
//        {
//            get
//            {
//                return typeStudent;
//            }
//            set
//            {
//                typeStudent = value;
//                if (value == "G")
//                {
//                    //private moet aangepast
//                    inschrijvingsbedrag = 520;
//                    studiepunten = 60;
//                }
//                else if (value == "I")
//                {
//                    inschrijvingsbedrag = 50 + (8.66667f * studiepunten);
//                }
//            }
//        }


//        public string AfdrukAdres()
//        {
//            return $"{VolledigeNaam()} {Straat} {Postcode}";
//        }
//        public string AfdrukStartDatum()
//        {
//            return $"{VolledigeNaam()} {StartDatum}";
//        }
//        public override void Info(string tekst)
//        {
//            base.Info(tekst);
//        }

//        //Constructor moet dezelfde naam hebben als klasse,
//        //Maakt object van klasse
//        public Studenten()
//        {
//            //construcotr
//            StartDatum = DateTime.Now;
//        }

//        //de benaming ToString werkt niet
//        public override string ToString()
//        {
//            //Er moet altijd een return zijn daarom exception, 
//            if (TypeStudent == "I")
//            {
//                return $"Student met individueel traject: {Studiepunten} SP-  Inschrijvingsgeld: {Inschrijvingsbedrag:c} : Betaald: {Betaald}";
//            }
//            else
//            {
//                return $"Standaardstudent: {Studiepunten} SP-  Inschrijvingsgeld: {Inschrijvingsbedrag:c} : Betaald: {Betaald}";
//            }
//        }




//    }
//}
