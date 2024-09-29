using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing_17_bankrekening
{
    internal class BankException : ApplicationException
    {
        //public string message = "Not enough money :(";
        public BankException(string bericht) : base(bericht) 
        {
            //message = bericht;
        }
    }
}
