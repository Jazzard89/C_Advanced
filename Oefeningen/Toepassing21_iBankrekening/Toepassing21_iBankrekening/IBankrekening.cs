using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing21_iBankrekening
{
    public interface IBankrekening
    {
        string Naam { get; }
        int Rekeningnummer { get; }

        double Saldo { get; }

        /////////////////////////

        void Opname(double withdrawal);

        void Storting(double deposit);
    }
}
