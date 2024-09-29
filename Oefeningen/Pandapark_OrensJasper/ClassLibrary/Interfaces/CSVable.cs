using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    internal interface CSVable
    {
        //bevat methode ToCSV
        //kan een klasse omzetten naar een stuk tekst waarin de waarde van de properties onderscheiden worden door ";"

        void ToCSV();
    }
}
