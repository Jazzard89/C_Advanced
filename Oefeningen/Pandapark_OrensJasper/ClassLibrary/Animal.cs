using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary
{
    public abstract class Animal : CSVable
    {
        //kan geen instanties aanmaken binnen de klasse


        //  De methode Describe beschrijft het dier in een zin en gebruikt de properties
        //          HijOfZij en ZijnOfHaar om de zin dynamisch op te bouwen.
        //          ○ De beschrijving van een vogel bevat: de naam, het type, het nest type en
        //          de spanwijdte van de vleugels.
        //          Tussentijdse test C# Advanced 2 / 10
        //          ○ De beschrijving van een zoogdier bevat: de naam, het type, of het een
        //          infant is en het geboorteland.
        //          ○ In de Describe methode moet je geen rekening houden met het geslacht
        //          van de woorden (bv: het paard vs de aap). Je mag altijd DE gebruiken. 

        public Animal() { }

        public Animal(string name, string type, string gender, string diet, DateTime dayOfBirth, string country, bool dangerous) 
        {
            Name = name;
            Type = type;
            Gender = gender;
            Diet = diet;
            DayOfBirth = dayOfBirth;
            Country = country;
            isDangerous = dangerous;
        }

        public Animal(string name, string type, string gender, string diet, string country, bool dangerous, string hijzij, string zijnhaar)
        {
            Name = name;
            Type = type;
            Gender = gender;
            Diet = diet;
            Country = country;
            isDangerous = dangerous;
        }

        public string Country { get; set; }

        public DateTime DayOfBirth { get; set; }

        public string Diet { get; set; }

        public string Gender { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        private bool isDangerous;
        public bool IsDangerous 
        {
            get { return isDangerous; } 
            set { isDangerous = value; } 
        }

        protected string hijOfZij 
        {
            get 
            {
                if (Gender == "Mannelijk")
                {
                    return "hij";
                }
                else
                {
                    return "zij";
                }
            }
        }

        protected string zijnOfHaar
        {
            get
            {
                if (Gender == "Mannelijk")
                {
                    return "zijn";
                }
                else
                {
                    return "haar";
                }
            }
        }

        public virtual string Describe()
        {
            return $"{Name.ToString().ToUpper()}, de {Type}. vermaakt zich fantastisch.";
        }

        public virtual void ToCSV()
        {
            using (StreamWriter sw = new StreamWriter("Mammel.txt"))
            {
                sw.WriteLine($"M;{Name}; {Type}; {IsDangerous}; {Diet}; {Gender}; {DayOfBirth}; {Country}");
                throw new Exception("done");
            }
        }


    }
}
