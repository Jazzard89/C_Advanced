using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing11_KlasseHuis
{
    public class Huis
    {
        private int floorCount;
        private double length;
        private double width;


        public string Locatie { get; set; }
        public double Lengte
        {
            get
            {
                return length;
            }
            set
            {
                if (value >= 0)
                {
                    length = value;
                }
                else
                {
                    throw new Exception("Dit moet groter zijn dan 0");
                }

            }
        }
        public double Breedte
        {
            get
            {
                return width;
            }
            set
            {
                if (value >= 0)
                {
                    width = value;
                }
                else
                {
                    throw new Exception("Dit moet groter zijn dan 0");
                }

            }
        }
        public int AantalVerdieping
        {
            get
            {
                return floorCount;
            }
            set
            {
                //na de if statement gaat hij een exception throwen dus gaat hij uit de 'set' dus moet er geen else geschreven worden hier
                if (value <= 0)
                {
                    throw new Exception("Een huis zonder verdieping is als een smartphone zonder scherm.");
                }
                else
                {
                    floorCount = value;


                }

            }
        }
        private string TypeTekst;
        public string Type

        {
            get
            {
                return TypeTekst;
            }

            private set
            {
                //reden waarom we een private eerst zetten is om een validatie te doen in onze public, anders hadden we geen
                //private nodig eigenlijk

                //hier voert hij eerst de if uit, en als deze niet correct is gaat hij naar de else moeten gaan om uit de set te gaan

                if (value == "O")
                { TypeTekst = "Open"; }
                else if (value == "H")
                { TypeTekst = "Halfopen"; }
                else if (value == "G")
                { TypeTekst = "Gesloten"; }


            }
        }

        public Huis(string Locatie, double Lengte, double Breedte, int AantalVerdieping, string Type)
        {
            this.Type = Type;
            this.Locatie = Locatie;
            this.Lengte = Lengte;
            this.Breedte = Breedte;
            this.AantalVerdieping = AantalVerdieping;


        }
        //we moeten ook een constructor hebben zonder parameters
        public Huis() : this("Onbekend", 1, 1, 1, "O")
        { }

        public void VerhoogAantalVerdiepingen(int aantal = 1)
        {
            //we gebruiken de private versie van 'aantalverdiepingen' in plaats van de public 'Aantalverdiepingen'
            //omdat we toch niet negatief gaan, want dit word gecontrolleerd in Aantalverdiepingen
            AantalVerdieping += aantal;
        }

        public void VerlaagAantalVerdiepingen(int aantal = 1)
        {
            //indien de verdiepingen vermiderd word en deze methode word opgeroepen

            //gezien er wel moet gecontrolleerd worden op een verdiepingen onder de null gaan we hier wel de public gebruiken
            //dus we gebruiken aantalVerdiepingen in plaats van Aantalverdiepingen (capitalen, niet capitalen)
            AantalVerdieping -= aantal;
        }

        public double Oppervlakte()
        {
            //we roepen weer de public versies op
            double surface = length * width;
            return surface;
        }
        public double Inhoud()
        {
            //gebruik method of property
            double volume = length * width * 2.5 * floorCount;
            return volume;
        }

    }
}
