using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Toepassing19_iList
{
    public class ListModule : Modules<string>
    {
        private int aantal;
        private List<string> modules;
        public ListBox ListofDoom;
        public List<string> Inhoud
        {
            get
            {
                return modules;
            }
            set
            {
                modules = value; ;
            }
        }
        public ListModule(ListBox IntroBox)
        {
            ListofDoom = IntroBox;
            Inhoud = new List<string>();
            modules = new List<string>();
        }
        public void Add(string InputTekst)
        {
            ListofDoom.Items.Add(InputTekst);
            Inhoud.Add(InputTekst);
        }
        public int IndexOf(string InputTekst)
        {
            int Index = ListofDoom.Items.IndexOf(InputTekst);
            return Index;
        }
        public void Remove(string InputIndex)
        {
            int OutputIndex = IndexOf(InputIndex);
            if (OutputIndex != -1)
            {
                RemoveAt(OutputIndex);
            }
        }
        public void RemoveAt(int Index)
        {
            ListofDoom.Items.RemoveAt(Index);
            Inhoud.RemoveAt(Index);
        }
    }
}
