using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTransportmiddelen.Entities
{
    public class Fiets : Voertuig, IVerkoop
    {
        public DateTime AankoopDatum { get; set; }
        public override string Info
        { get
            {
                return $"Fiets '{Omschrijving}' is {AantaldagenOud()} dagen oud en wordt verkocht aan €{VerkoopPrijs}.";
            } 
        }

        public  double VerkoopPrijs 
        {
            get
            {
                double korting = AantaldagenOud() * 5;
                return VerkoopPrijs - ((VerkoopPrijs / 100) * korting);
            }
            set
            {
                VerkoopPrijs = value;
            }
        }
        public int AantaldagenOud()
        {
            //De verkooopprijs van een fiets is afhankelijk van de aankoopdatum. Per leeftijdsjaar van de fiets krijg je 5%
            //korting. Dus als de fiets 10 jaar oud is krijg je 50% korting op de aankoopprijs, als hij 3 jaar oud is krijg je 15%
            //korting, enz
            DateTime huidigedatum = DateTime.Now;
            int aantalDagen = Convert.ToInt32(AankoopDatum.Subtract(huidigedatum));
            //korting = aantaldagen x 5
            return aantalDagen;
        }

        public Fiets(string type, string omschrijving, double aankoopprijs, int kilometerStand, DateTime aankoopDatum) : base(type, omschrijving, aankoopprijs, kilometerStand)
        {
            Type = type;
            Omschrijving = omschrijving;
            Aankoopprijs = aankoopprijs;
            KilometerStand = kilometerStand;
            AankoopDatum = aankoopDatum;
        }

        public override string ToString()
        {
            //Geeft het volgende terug "Voertuig - {Omschrijving}"
            return $"Fiets - {Omschrijving}";
        }
    }
}
