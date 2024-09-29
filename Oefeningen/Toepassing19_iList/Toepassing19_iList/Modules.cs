using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing19_iList
{
    //deze word geerft in Listmodule
    public interface Modules<T>
    {
        //elke class die we baseren op deze interface MOET deze elementen bevatten
        void Add(T InputTekst);
        int IndexOf(T InputTekst);
        void Remove(T InputIndex);
    }
}
