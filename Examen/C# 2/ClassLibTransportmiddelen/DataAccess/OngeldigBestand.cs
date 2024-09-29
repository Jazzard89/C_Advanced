using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTransportmiddelen.DataAccess
{
    public class OngeldigBestand : MissingFieldException
    {
        //in de dataaccess folder zit ook een klasse OngeldigBestand. Deze erft over van de klasse
        //MissingFieldException.
        //Zorg ervoor dat je
        //bij het oproepen van deze klasse een melding kan meegeven in de vorm van een string.
        public OngeldigBestand() 
        {
            throw new Exception("Ongeldig bestand");
        }

    }
}
