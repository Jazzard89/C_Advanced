using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing07_KlasseBerkening
{
    public class Bankrekening
    {
        public int HuidigSaldo { get; private set; }

        public Bankrekening()
        {
            HuidigSaldo = 0;
        }

        public void Opname(int bedrag)
        {
            HuidigSaldo -= bedrag;

        }

        public void Storting(int bedrag)
        {
            HuidigSaldo += bedrag;

        }
    }
}
