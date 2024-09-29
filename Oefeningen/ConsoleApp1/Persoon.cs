using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    public class Persoon
    {
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        public DateTime Geboortedatum { get; set; }


        // Virtual method/property staat in de base class
        // Je kan deze overschrijven (override) in de afgeleide class en
        // een eigen implementatie daarvoor voorzien

        //alles wat mischien geweizigd word in de basis class moet je als virtual gaan zetten.


        public virtual string VolledigeNaam() => $"{Voornaam} {Naam}";
        public virtual string Gegevens => $"{Voornaam} {Naam}\r\n{Geboortedatum.ToLongDateString()}";
    }
}
