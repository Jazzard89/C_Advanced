using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing20_Hondenras
{
    internal class Boom : IOuderdom
    {
        public Boom(int plantjaarMK, string soortMK)
        {
            ringen = plantjaarMK;
            soort = soortMK;
        }

        /////////////////////////////////////////////////////

        private int ringen { get; set; }

        private string soort { get; set; }


        /////////////////////////////////////////////////////
        public string Naam
        {
            get { return soort; }
            set { soort = value; }
        }

        public int Ouderdom
        {
            get { return ringen - Convert.ToInt32(DateTime.Now.Year); }
            set { ringen = Convert.ToInt32(value); }
        }
    }
}
