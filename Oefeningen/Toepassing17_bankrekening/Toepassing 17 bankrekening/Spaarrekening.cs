using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing_17_bankrekening
{
    internal class Spaarrekening: Bankrekening
    {
       public Spaarrekening(double opening, string name, string adress) : base(opening, name, adress)
        {
            
        }
        public override double BerekenRente()
        {
            return (HuidigSaldo * (1.5 / 100)) - 100;
        }

    }
}
