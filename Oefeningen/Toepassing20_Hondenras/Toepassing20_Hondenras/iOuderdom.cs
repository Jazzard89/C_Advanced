using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing20_Hondenras
{
    //moet public staan, duh!
    public interface IOuderdom
    {
        string Naam { get; }
        int Ouderdom { get; }
    }
}
