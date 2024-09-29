using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> driehoek = new List<int>()
            {
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                1, 3, 6, 10, 15, 21, 28, 36, 45,
                1, 4, 10, 20, 35, 56, 84, 120,
                1, 5, 15, 35, 70, 126, 210,
                1, 6, 21, 56, 126, 252,
                1, 7, 28, 84, 210,
                1, 8, 36, 120,
                1, 9, 45,
                1, 10,
                1
            };
            string[] tekst = new string[]
            {
                "langspeelfilm", "vluchtmisdrijf", "dovemansgesprek", "containerpark",
                "confituur", "inox", "valavond", "enerverend", "lopen", "bank", "vieruurtje",
                "waterzooi", "maaltijdcheque", "arrondissement", "eindtermen", "nieuwjaarsbrief"
            };



            var teksten = (
                from t in tekst
                where t.Length > 10
                select t

                );
            Console.WriteLine( "oefenening 1" );
            foreach( var t in teksten)
            {
                Console.WriteLine( t );
            }

            ///////////////////////////////////////////////:
            Console.WriteLine(" ");
            Console.WriteLine("oefening 2");

            var groterDan = (
                from g in driehoek
                where g > 100
                select g);

            double gemiddelde = Math.Round(groterDan.Average(), 2);
            Console.WriteLine(gemiddelde.ToString());


            ///////////////////////////////////////////////:
            Console.WriteLine(" ");
            Console.WriteLine("oefening 3");
            var unique = (
                from u in driehoek
                select u).Distinct();

            foreach( var u in unique)
            {
                Console.WriteLine(u.ToString());
            }


            ///////////////////////////////////////////////:
            Console.WriteLine(" ");
            Console.WriteLine("oefening 4");

            var unique2 = (
                from u in driehoek
                where u % 3 == 0
                || u % 5 == 0
                select u).Distinct();

            foreach (var u in unique2)
            {
                Console.WriteLine(u.ToString());
            }



            ///////////////////////////////////////////////:
            Console.WriteLine(" ");
            Console.WriteLine("oefening 5");

            var gesorteerdLengte = (
                from s in tekst
                orderby s
                orderby s.Length
                select s);

            foreach( var s in gesorteerdLengte)
            {
                Console.WriteLine(s.ToString());
            }


            ///////////////////////////////////////////////:
            Console.WriteLine(" ");
            Console.WriteLine("oefening 6");

            var lettergroep = (
                from w in tekst
                select w[0]);

            foreach( var w in lettergroep)
            {
                Console.WriteLine(w.ToString());
            }

            ///////////////////////////////////////////////:
            Console.WriteLine(" ");
            Console.WriteLine("oefening 7");

            var gevondenParen = (
            from num in driehoek
            from word in tekst
            where word.Length == num
            select new { Getal = num, Woord = word }
        );

            foreach (var pair in gevondenParen)
            {
                Console.WriteLine($"Getal: {pair.Getal}, Woord: {pair.Woord}");
            }


            ///////////////////////////////////////////////:
            Console.WriteLine(" ");
            Console.WriteLine("oefening 8");

            var gevondenParen2 = (
                from num in driehoek
                from word in tekst
                where word.Length == num
                select new { Getal = num, Woord = word }
            ).Distinct();

            foreach (var pair in gevondenParen2)
            {
                Console.WriteLine($"Getal: {pair.Getal}, Woord: {pair.Woord}");
            }


            ///////////////////////////////////////////////:
            Console.WriteLine(" ");
            Console.WriteLine("oefening 9");

            var drieKlinkers = (
                from w in tekst
                where CountVowels(w) > 3
                select w);

            foreach (var w in drieKlinkers)
            {
                Console.WriteLine(w.ToString() );
            }

            int CountVowels(string word)
            {
                int count = 0;
                string vowels = "aeiouAEIOU";

                foreach (char letter in word)
                {
                    if (vowels.Contains(letter))
                    {
                        count++;
                    }
                }

                return count;
            }

            ///////////////////////////////////////////////:
            Console.WriteLine(" ");
            Console.WriteLine("oefening 2.1");



            List<Warehouse> warehouses = new List<Warehouse>
            {
                new Warehouse("Brug4", 0, "Arendonk", 2370, "Holstraat", 14, 3000, new List<int>{ 4, 3, 1, 5 }),
                new Warehouse("Brug1", 1, "Arendonk", 2370, "Holstraat", 3, 8000, new List<int>{ 1, 4, 3, 5, 2, 3, 3, 4, 4}),
                new Warehouse("Poort1", 2, "Gent", 9000, "Stropkaai", 12, 7000, new List<int>{ 5, 4, 3, 4 , 4}),
                new Warehouse("Rijsteller", 3, "Hasselt", 3500, "Industrielaan", 1, 2500, new List<int>{ 5, 4, 3, 5, 2, 3, 4, 4}),
                new Warehouse("Automa klein", 4, "Berchem", 2600, "Nieuwevaart", 77, 10000, new List<int>{ 4 }),
                new Warehouse("Schuifla", 5, "Hasselt", 3500, "Industrielaan", 15, 1500, new List<int>{ 3, 5, 2 }),
                new Warehouse("Automa groot", 6, "Berchem", 2600, "Nieuwevaart", 76, 30000, new List<int>{ 5 }),
                new Warehouse("Brug2", 7, "Arendonk", 2370, "Molenweg", 7, 3000, new List<int>{ 4, 3, 5, 2 }),
                new Warehouse("Veerhal", 8, "Melle", 9090, "Merelstraat", 48, 500, new List<int>{ 5, 5 }),
                new Warehouse("Poort2", 9, "Gent", 9000, "Burgstraat", 113, 6600, new List<int>{ 1, 2, 1, 1, 2, 3}),
                new Warehouse("D1", 10, "Knokke", 8300, "Vaart", 2, 2200, new List<int>{ 5, 4, 1 }),
                new Warehouse("Brug3", 11, "Arendonk", 2370, "Molenweg", 8, 8000, new List<int>{ 5, 2, 3, 5, 5 }),
                new Warehouse("D2", 12, "Knokke", 8300, "Vaart", 4, 2200, new List<int>{ 2, 3, 4 }),
                new Warehouse("D3", 13, "Knokke", 8300, "Vaart", 6, 2200, new List<int>{ 3, 4, 3 })
            };

            List<Employee> employees = new List<Employee>
            {
                new Employee("Jos", "Jansen", 0, 1),
                new Employee("Ted", "Bériault", 1, 0),
                new Employee("Tony", "Hawk", 2, 3),
                new Employee("Peggy", "Corona", 3, 12),
                new Employee("Edna", "Goosen", 4, 0),
                new Employee("Mac", "Kowalski", 5, 11),
                new Employee("Alejandro", "Mendoza", 6, 8),
                new Employee("Aysha", "Lyon", 7, 7),
                new Employee("Tyson", "Dyer", 8, 4),
                new Employee("Nanou", "Hahn", 9, 6),
                new Employee("Kevin", "Hahn", 10, 5),
                new Employee("Kris", "Jacobsen", 11, 1),
                new Employee("Boros", "Orzsebet", 12, 2),
                new Employee("Buday", "Gedeon", 13, 2),
                new Employee("Szölôsi", "Taksony", 14, 1),
                new Employee("Kocsis", "Gyula", 15, 8),
                new Employee("Asif", "Atiyeh", 16, 7),
                new Employee("Ruwayd", "Akram", 17, 13),
                new Employee("Makary", "Sobczak", 18, 12),
                new Employee("Pawel", "Symanski", 19, 1),
                new Employee("Settimio", "Calabresi", 20, 10),
                new Employee("Ivo", "Bellucci", 21, 7),
                new Employee("Matthieu", "Camus", 22, 9),
                new Employee("Jacques", "Huard", 23, 8),
                new Employee("Melville", "Bériault", 24, 4),
                new Employee("René", "Michaud", 25, 9)
            };


            //Deel 2.1
            var magazijnNamenInBerchem = (
                from magazijn in warehouses
                where magazijn.City == "Berchem"
                select magazijn.BuildingName
            );

            foreach ( var city in magazijnNamenInBerchem)
            {
                Console.WriteLine(city);
            }


            //Deel 2.2
            Console.WriteLine(" ");
            Console.WriteLine("oefening 2.2");
            var magazijnNamenEnSteden = (
                from magazijn in warehouses
                orderby magazijn.EmployeeSatisfactionRating.Average()
                select magazijn.BuildingName + " " + magazijn.City
            );

            foreach (var naam in magazijnNamenEnSteden)
            {
                Console.WriteLine(naam);
            }





            //Deel 2.3
            Console.WriteLine(" ");
            Console.WriteLine("oefening 2.3");

            var alleNamen = (
                from namen in employees
                orderby namen.LastName
                select namen.FirstName + " " + namen.LastName + " " + namen.ID);

            foreach (var naam in alleNamen)
            {
                Console.WriteLine(naam);
            }


            //Deel 2.4
            Console.WriteLine(" ");
            Console.WriteLine("oefening 2.4");

            var rangschikMagazijnen = (
                from rangschik in warehouses
                orderby rangschik.EmployeeSatisfactionRating.Average()
                select rangschik.BuildingName);

            foreach (var rangschikker in rangschikMagazijnen)
            {
                Console.WriteLine(rangschikker);
            }




            //Deel 2.5
            Console.WriteLine(" ");
            Console.WriteLine("oefening 2.5");

            var postcodeOrder = (
                from order in warehouses
                where order.PostCode < 4000
                orderby order.City
                select order.BuildingName + " " + order.City);

            foreach (var code in postcodeOrder)
            {
                Console.WriteLine(code.ToString());
            }



            //Deel 2.6
            Console.WriteLine(" ");
            Console.WriteLine("oefening 2.6");


            var voledigeNamen = (
                from e in employees
                from w in warehouses
                where w.StorageCapacity > 2000 && w.WarehouseId == e.WarehouseId
                select e.FirstName + " " + e.LastName + "werkt in het magazijn " + w.BuildingName + " met opslagruimte van " + w.StorageCapacity + " vierkante meter");

            foreach (var namen in voledigeNamen)
            {
                Console.WriteLine(namen.ToString());
            }

            //Deel 2.7
            Console.WriteLine(" ");
            Console.WriteLine("oefening 2.7");

            var idEnVoornaam = (
                from werknemer1 in employees
                from werknemer2 in employees
                where werknemer1.FirstName != werknemer2.FirstName &&
                werknemer1.LastName == werknemer2.LastName
                select werknemer1.FirstName + " " + werknemer1.LastName + " " + werknemer1.ID);

            foreach (var id in idEnVoornaam)
            {
                Console.WriteLine(id.ToString());
            }


























            Console.ReadLine();
        }
    }
}
