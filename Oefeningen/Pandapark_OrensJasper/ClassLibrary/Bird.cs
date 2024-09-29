using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Bird : Animal
    {
        public string NestType { get; set; }

        public string WingSpan { get; set; }

        public Bird()
        {

        }

        public Bird(string naam, string type, bool isDanger, string diet, string gender, DateTime dayOfBirth, string country, string nestType, string wingSpan)
        {
            Name = naam;
            Type = type;
            IsDangerous = isDanger;
            Diet = diet;
            Gender = gender;
            DayOfBirth = dayOfBirth;
            Country = country;
            WingSpan = wingSpan;
            NestType = nestType;
        }
 
        public Bird(string naam)
        {
            Name = naam;
        }

        public override string Describe()
        {
            return $"{Name.ToString().ToUpper()}, de {Type}. vermaakt zich fantastisch in {zijnOfHaar} {NestType} waar {hijOfZij} rond vliegt met een spanwijdte van {WingSpan} cm.";
        }

        public override void ToCSV()
        {
            using (StreamWriter sw = new StreamWriter("Bird.txt"))
            {
                sw.WriteLine($"B;{Name}; {Type}; {IsDangerous}; {Diet}; {Gender}; {DayOfBirth}; {Country}; {NestType}; {WingSpan}");
            }
        }
    }


}
