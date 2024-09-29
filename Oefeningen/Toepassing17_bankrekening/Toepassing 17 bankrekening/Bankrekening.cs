using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing_17_bankrekening
{
    public abstract class Bankrekening
    {
        protected double saldo;
        public string Adres { get; set; }
        public double HuidigSaldo
        {
            get
            {
                return saldo;
            }

            set
            {
                saldo = value;
            }
        }
        public string Naam { get; set; }

        public Bankrekening(double opening, string name, string adress) 
        {
            if (opening >= 0) 
            { 
                saldo = opening;
                Naam = name;
                Adres = adress;
            
            
            }
        }
        public Bankrekening() 
        {
            saldo = 0;
            Naam = "Bob Kees";
            Adres = "KaasStraat";
        }
        public abstract double BerekenRente();
        
        public virtual double CreditSaldo(double moneyinput)
        {
            return HuidigSaldo + moneyinput; 
        }
        public virtual double DebetSaldo(double geldInput)
        {
            return HuidigSaldo + geldInput;
        }

    }
}
