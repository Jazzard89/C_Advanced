using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Arbeiders : Medewerker
    {
        private double rsz, belastbaar, bruto, bv;

        //Arbeiders constructor met constructed chain -> ' : ' dit zegt dat we terug vallen op onze basis class
        public Arbeiders(string firstName, string familyName, double hourlyWage, double hours) :
        base(firstName, familyName, hourlyWage, hours)
        {
            bruto = Bruto();
        }

        //als een methood virtual is gezet kan dit overschreden worden met 'override' maar dit is niet noodzakelijk

        //een abstracte classe defineerd waaraan een basis class moet voldoen !!!!!! heel belangrijk
        public override double BV()
        {
            belastbaar = bruto - RSZ();
            if (belastbaar <= 50000)
            {
                bv = belastbaar * 0.45f;
            }
            else
            {
                bv = (bruto - 50000) * 0.5f + (50000 * 0.45f);
            }
            return bv;
        }
        public override double Netto() => belastbaar - bv;
        public override double RSZ()
        {
            rsz = bruto * 1.08 * 0.1307;
            return rsz;
        }

        //public override double BV()
        //{
        //    throw new NotImplementedException();)
        //}
        //public override double Netto()
        //{
        //    throw new NotImplementedException();
        //}
        //public override bool RSZ()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
