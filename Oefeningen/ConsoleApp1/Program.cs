using inheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ////als we Persoon opvragen krijgen wij dan iets anders dan als we persoon opvragen?

            ////Persoon p = new Persoon();


            //Werknemer p = new Werknemer();

            ////dit kan niet inheriten van een abstracte classen.
            ////Medewerk m = new Medewerker();

            //p.Naam = "Bloemen";
            //p.Voornaam = "Koen";
            //p.Geboortedatum = new DateTime(2020, 01, 15);
            //p.Functie = "Tester";
            //Console.WriteLine("Volledige naam: ");
            //Console.WriteLine(p.VolledigeNaam());
            //Console.WriteLine("Gegevens:\n");
            //Console.WriteLine(p.Gegevens);
            //Console.ReadLine();


            ///////////////////////////////////////
            ///

            ////we hebben geen default constructor dus we moeten argumenten meegeven
            //Arbeiders a = new Arbeiders();

            Arbeiders a = new Arbeiders("Koen", "Bloemen", 1000.15, 65);
            Bedienden b = new Bedienden("Koen_Bloemen", "Bloemen_Bediende", 5000);

            //Medewerker medewerker;

            //medewerker = new Arbeiders("Koen", "Bleomen", 1000.15, 65);
            //medewerker = new Bedienden("Koen_Bediende", "Bloemen_Bediende", 5000);

            Console.WriteLine($"Arbeider {a.Naam} met loon {a.Uurloon} verdient {a.Bruto()} bruto.");
            Console.WriteLine($"Bediende {b.Naam} met loon {b.Uurloon} verdient {b.Bruto()} bruto.");

            Console.ReadLine();
        }
    }
}
