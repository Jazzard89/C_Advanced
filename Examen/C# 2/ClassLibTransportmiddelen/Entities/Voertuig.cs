using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTransportmiddelen.Entities
{
    public abstract class Voertuig
    {
        public string Type { get; set; }
        public string Omschrijving { get; set; }
        public double Aankoopprijs { get; set; }
        public int KilometerStand { get; set; } 
        public abstract string Info { get; } //moet overschreven worden

        public override string ToString()
        {
            //Geeft het volgende terug "Voertuig - {Omschrijving}"
            return $"Voertuig - {Omschrijving}";
        }

        public Voertuig(string type, string omschrijving, double aankoopprijs, int kilometerStand) 
        {
            Type = type ;
            Omschrijving = omschrijving ;
            Aankoopprijs = aankoopprijs ;
            KilometerStand = kilometerStand ;
        }

    }
}
