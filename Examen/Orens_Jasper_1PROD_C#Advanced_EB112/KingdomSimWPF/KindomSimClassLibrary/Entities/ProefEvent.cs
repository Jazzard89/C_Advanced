using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindomSimClassLibrary.Entities
{
    internal class ProefEvent: Event
    {
        public string CategorieProef1 { get; set; }
        public string CategorieProef2 { get; set; }
        public int Drempelwaarde { get; set; }

        public string Keuze1 { get; }
        public string keuze2 { get; }

        public ProefEvent(string csvRegel)
        {
            CategorieProef1 = csvRegel;
            CategorieProef2 = csvRegel;
            Drempelwaarde = csvRegel.Length;
            Keuze1 = csvRegel.Substring(0, csvRegel.Length - 1);
            keuze2 = csvRegel.Substring(0, csvRegel.Length - 1);
        }

        public override void VerwerkKeuzeVoorSpeler(Speler speler, int keuze)
        {

        }
    }
}
