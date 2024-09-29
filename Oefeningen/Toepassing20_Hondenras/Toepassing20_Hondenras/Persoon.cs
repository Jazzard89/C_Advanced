using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toepassing20_Hondenras
{
    internal class Persoon : IOuderdom
    {
        public Persoon(string voornaamMK, string naamMK, int geboortejaarMK)
        {
            voornaam = voornaamMK;
            naam = naamMK;
            geboortejaar = geboortejaarMK;
        }

        ////////////////////////////////////////////////////////
        private int geboortejaar { get; set; }

        private string naam { get; set; }

        private string voornaam { get; set; }

        ////////////////////////////////////////////////////////
        //word vereisd in IOuderdom

        public string Naam
        {
            get
            {
                return voornaam + " " + naam;
            }
            set
            {
                Naam = value;
            }
        }

        public int Ouderdom
        {
            get { return DateTime.Now.Year - geboortejaar; }
            set
            {
                geboortejaar = DateTime.Now.Year - value;
            }
        }


    }
}
