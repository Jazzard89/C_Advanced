using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    ////als wij een class willen complien als een andere class zetten we 'internal class Werknemers : Persoon'
    //internal class Werknemers : Persoon
    //{
    //    private string functie;

    //    public DateTime DatumInDienst { get; set; }

    //    public string fucntie
    //    {
    //        get { return functie }
    //        set { functie = value; }
    //    }


    //    //typ prop en dan op shift om basis data in te vullen en aantepassen

    //    //wil je kijken wat override kan worden typ dan override en kijk wat er kan overgeschreven word, wat virtual is

    //    public override string Gegevens { get => base.Gegevens; set => base.Gegevens = value; }

    //    //public override string Gegevens { get; set; }
    //    //op deze manier haalt hij geen gegevens terug
    //}

    public class Werknemer : Persoon
    {
        public DateTime DatumInDienst { get; set; }
        public string Functie { get; set; } = "Lector";


        // automatisch initialiseren
        // Override (overschrijf) de implementatie van Gegevens van de base classPersoon.4
        // Een Medewerker object heeft nu zijn eigen implementatie van Gegevens.
        // base.Gegevens: roept de property Gegevens aan van de base class
        // Dus base.Gegevens is de implementatie die in de class Persoon staat
        // Hierachter vullen we dan aan met de Functie.

        public override string Gegevens => $"{base.Gegevens} - {Functie}";
    }


}
