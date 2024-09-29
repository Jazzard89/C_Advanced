using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing28_DbMedewerkersClassLib
{
    public class Medewerker
    {
        public int MnrID { get; set; }

        public string Voornaam { get; set; }

        public string Naam { get; set; }

        public string Functie { get; set; }

        public int Chef { get; set; }

        public DateTime GbDatum { get; set; }

        public float Maandsalaris { get; set; }

        public float Comm { get; set; }

        public int Afdeling { get; set; }
    }
}
