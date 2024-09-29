using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlassePersoneel2
{
    public class Personeel
    {
        //moet private zijn zodat enkel de mensen in de class er aan kunnen
        private int cijfer;
        //public is pascal casing, private is dat niet
        //indien in de opdracht get, set staat weten we dat deze public moeten zijn
        public int Beordelingscijfer
        {
            //indien iemand het beoordelingscijfer wilt weten, geven we cijfer
            //we doen dit om de cijfers te dupliceren en om hier iets mee te doen, maar zonder de originele te bewerken
            get { return cijfer; }
            set 
            {
                if (Beordelingscijfer >= 0 || Beordelingscijfer <= 10)
                {
                    cijfer = value;
                }
                else
                {
                    throw new Exception("foute input voor beoordelingscijfer");
                }
            }
        }

        public string Naam
        {
            get;
            set;
        }
        public string Voornaam
        {
            get;
            set;
        }
        public string Geslacht
        {
            get;

            //op deze manier kan het geslacht enkel via de class aangepast worden na de set
            private set;
        }
        public int Startjaar
        {
            get;

            set;
        }

        public int Dienstjaren
        {
            get;
        }
        public string Geslachttekst
        {
            get;
        }

        public double Premie
        {
            get;
        }

        //constructor mogen parameters mee hebben. voor deze oefenigen roepen we deze parameters op omdat hier een set staat,
        //met andere woorden zijn deze aanpasbaar.
        public Personeel(int BeordelingscijferC, string NaamC, string VoornaamC, string GeslachtC, int StartjaarC )
        {
            //hier zetten we dat onze meegegeven data hetzelfde is als hierboven staat
            Beordelingscijfer= BeordelingscijferC;
            Naam=NaamC;
            Voornaam=VoornaamC;
            Geslacht=GeslachtC;
            Startjaar=StartjaarC;
        }

        //voor niets mee te geven we de default data mee aan de constructor
        public Personeel() : this(5, "Pepers", "Jan", "M", 2012)
        {

        }



        ////////////////////////////////////methods
        ///

        private float BerekenPremie()
        {
            //Dienstjaren + BeoordelingsCijfer
            //eerst word het basisbedrag berekend 
            // decimal. De premie wordt als volgt bepaald: eerst wordt het basisbedragberekend:
            // 500€, vermeerderd met 20€ per dienstjaar.
            //
            // Dit bedrag wordt gehalveerdvoor personeelsleden
            // die een Beoordelingscijfer hebben dat lager is dan 5. Voordiegenen die een beoordelingscijfer
            // van 7 of 8 hebben, wordt het basisbedrag met50% verhoogd. Voor wie een beoordelingscijfer
            // van 9 of 10 heeft, wordt hetbasisbedrag verdubbeld.

            const int BasisBedrag = 500;
            int basis = BasisBedrag + (20 * Dienstjaren);

        }



    }
}
