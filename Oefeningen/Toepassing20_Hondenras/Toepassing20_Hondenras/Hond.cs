using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Toepassing20_Hondenras
{
    internal class Hond : IOuderdom
    {
        public Hond(string dogname, string dogdate, string dogsize, ComboBox hondenbestandcb)
        {
            using (StreamReader sr = new StreamReader("Hondenras.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] waarden = sr.ReadLine().Split(';');
                    grootte = Convert.ToString(waarden[1]);
                    if ((dogdate == "") || (dogname == ""))
                    {
                        hondenbestandcb.Items.Add(waarden[0]);
                    }
                    else
                    {
                        dogsize = Convert.ToString(waarden[1]);
                        geboortejaar = (Convert.ToDouble(DateTime.Now.Year) - Convert.ToDouble(dogdate)) * Convert.ToDouble(waarden[2]);
                        Naam = dogname;
                    }

                }
            }

        }

        /////////////////////////////////////////////////////

        private double geboortejaar { get; set; } //done

        private string grootte { get; set; } //done

        private string naam { get; set; } //done

        private string ras { get; set; } //done


        /////////////////////////////////////////////////////

        public string Naam { get; set; }

        public double Ouderdom
        {
            get
            {
                return geboortejaar;
            }
            set
            {
                geboortejaar = value;
            }
        }

        int IOuderdom.Ouderdom => throw new NotImplementedException();
    }
}
