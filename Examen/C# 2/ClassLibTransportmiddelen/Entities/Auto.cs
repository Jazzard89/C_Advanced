using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTransportmiddelen.Entities
{
    public class Auto : Voertuig, IVerkoop
    {
        public bool Ongevalvrij { get; set; }
        public string Aandrijving { get; set; }
        public override string Info
        {
            get { return $"Auto '{Omschrijving}' is '{Aandrijving}' aangedreven en wordt verkocht aan €{VerkoopPrijs}."; }
        }

        public double VerkoopPrijs 
        {
            get
            {
                double korting;
                if (Ongevalvrij == false)
                {
                    korting = 30;
                }
                else
                {
                    if (Aandrijving == "achterwiel")
                    {
                        korting = 70;
                    }
                    else
                    {
                        korting = 1;
                    }
                }

                return VerkoopPrijs - ((VerkoopPrijs / 100) * korting);
            }
            set
            {
                VerkoopPrijs = value;
            }
        }

        //De verkoopprijs van een auto is afhankelijk van het feit of hij een ongeval heeft gehad of niet.
        //In geval van een ongeval wordt hij verkocht aan 30% van de aankoopprijs. Indien hij ongevalvrij is,
        //dan is het afhankelijk van zijn aandrijving.
        //achterwiel aangedreven auto's worden verkocht aan 70% van de aankoopprijs.



        public Auto(string type, string omschrijving, double aankoopprijs, int kilometerStand, bool ongevalvrij, string aandrijving) : base(type, omschrijving, aankoopprijs, kilometerStand)
        {
            Type = type ;
            Omschrijving = omschrijving ;
            Aankoopprijs = aankoopprijs ;
            KilometerStand = kilometerStand ;
            Ongevalvrij = ongevalvrij;
            Aandrijving = aandrijving ;
        }

        public override string ToString()
        {
            //Geeft het volgende terug "Voertuig - {Omschrijving}"
            return $"Auto - {Omschrijving}";
        }
    }
}
