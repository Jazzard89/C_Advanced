using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindomSimClassLibrary.Entities
{
    internal interface IKeuze
    {
        public void VerwerkKeuzeVoorSpeler(Speler speler, int keuze) { }
        public string Keuze1 { get; }
        public string Keuze2 { get; }
    }
}
