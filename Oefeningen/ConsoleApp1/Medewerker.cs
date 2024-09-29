using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //class is abstract
    public abstract class Medewerker
    {
        private double bruto;
        // De klasse Werknemer is een abstracte klasse.
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        public double Uurloon { get; set; }
        public double UrenGewerkt { get; set; }

        //deze bruto word opgevuld in de constructor hieronder
        public double Bruto() => bruto;
        // Constructor.
        // Bedienden
        public Medewerker(string firstName, string familyName, double salary)
        {
            //deze is voor debediende
            Uurloon= salary / 4 / 40;
            Voornaam = firstName;
            Naam = familyName;
            bruto = salary;
        }
        // Arbeiders
        public Medewerker(string firstName, string familyName, double hourlyWage, double hours)
        {
            Uurloon= hourlyWage;
            Voornaam = firstName;
            Naam = familyName;
            bruto = hourlyWage * hours;
        }
        // Abstracte methode. het enige wat we kunnen doen is inheriten
        //Het onderste MOET in de arbeiders class gedefineerd worden
        public abstract double RSZ();
        public abstract double BV();
        public abstract double Netto();


        //public double rsz(); // body moet er zijn dus 
        //public double rsz() { }; // er moet nu ook iets in zitten

        //public double rsz()
        //{
        //    return bruto;
        //}
    }
}
