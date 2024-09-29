using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindomSimClassLibrary.Entities
{
    internal class BeslissingEvent : Event
    {
        public string CategorieJaPositief { get; set; }
        public string CategorieJaNegatief { get; set; }
        public string CategorieNeePositief { get; set; }
        public string CategorieNeeNegatief { get; set; }
        public string Keuze1 { get { return $"JA - {CategorieJaPositief}"; } }
        public string Keuze2 { get { return $"NEE - {CategorieNeePositief}"; } }

        public BeslissingEvent(string csvRegel)
        {

        }

        public override void VerwerkKeuzeVoorSpeler(Speler speler, int keuze)
        {

        }

        //public categorie CategorieJaPositief=Happiness

        public VerwerkKeuzeVoorSpeler()
        {

        }
    }
}
