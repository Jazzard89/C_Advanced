using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Toepassing_17_bankrekening
{
    internal class Zichtrekening: Bankrekening
    {
        public Zichtrekening(double opening, string name, string adress) : base(opening, name, adress)
        {
            
        }
        public override double BerekenRente()
        {
            return HuidigSaldo * (0.5 / 100);
        }
        public override double CreditSaldo(double moneyinput)
        {
            if(HuidigSaldo + moneyinput >=0)
            {
                return base.CreditSaldo(moneyinput);
            }
            else
            {
                BankException error = new BankException("help me");
                MessageBox.Show("");
                return HuidigSaldo;
            }
            
        }

    }
}
