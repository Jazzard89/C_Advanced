using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Mammal : Animal
    {
        //property 'IsInfant' is read-only, de waarde van deze property wordt bepaald door de geboortedatum van het dier.
        //indien het dier 365 dag en minder oud is dan geeft dit true, anders falls

        public bool IsInfant
        {
            get
            {
                DateTime eenJaarGeleden = DateTime.Now.AddYears(-1);
                if (DayOfBirth > eenJaarGeleden)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Mammal() { }

        public Mammal(string naam, string type, bool isDanger, string diet, string gender, DateTime dayOfBirth, string country ) 
        {
            Name = naam;
            Type = type;
            IsDangerous = isDanger;
            Diet = diet;
            Gender = gender;
            DayOfBirth = dayOfBirth;
            Country = country;
        }

        public Mammal(string naam)
        {
            Name = naam;
        }

        public override string Describe()
        {
            if (IsInfant == true)
            {
                return $"{Name.ToString().ToUpper()}, de {Type}. de zuigeling vermaakt zich fantastisch in {zijnOfHaar} persoonlijke habitat die aangepast is om te lijken op {zijnOfHaar} thuisland, {Country}.";
            }
            else
            {
                return $"{Name.ToString().ToUpper()}, de {Type}. vermaakt zich fantastisch in {zijnOfHaar} persoonlijke habitat die aangepast is om te lijken op {zijnOfHaar} thuisland, {Country}.";
            }
        }

        public override void ToCSV()
        {
            using (StreamWriter sw = new StreamWriter("Mammel.txt"))
            {
                sw.WriteLine($"M;{Name}; {Type}; {IsDangerous}; {Diet}; {Gender}; {DayOfBirth}; {Country}");
            }
        }
    }
}
