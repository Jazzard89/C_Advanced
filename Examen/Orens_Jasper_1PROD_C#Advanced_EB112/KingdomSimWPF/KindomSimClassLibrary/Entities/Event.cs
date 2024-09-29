using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindomSimClassLibrary.Entities
{
    public class Event: IKeuze
    {
        public int Id { get; set; }
        public string Keuze1 { get; }
        public string Keuze2 { get; }
        public string Naam { get; set; }
        public int Uitleg { get; set; }

        
        public Event (string csvRegel)
        {
            Naam = csvRegel;
            Keuze1 = csvRegel;
            Keuze2 = csvRegel;
        }

        public virtual void VerwerkKeuzeVoorSpeler(Speler speler, int keuze)
        {

        }
    }
}
