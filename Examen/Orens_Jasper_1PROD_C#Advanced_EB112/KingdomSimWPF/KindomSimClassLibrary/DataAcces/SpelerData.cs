using KindomSimClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Linq;

namespace KindomSimClassLibrary.DataAcces
{
    public static class SpelerData
    {
        public static List <Speler> spelers 
        {
            get { 
                Speler speler1 = new Speler (1, "Koen", "123");
                Speler speler2 = new Speler(2, "Kristof", "azerty");
                Speler speler3 = new Speler(3, "Sander", "wachtwoord");
                spelers.Add (speler1);
                spelers.Add (speler2);
                spelers.Add (speler3);
                return spelers;   
            }
            set { spelers = value; }
        }

        public static Speler GetSpelerByNaam(string naam) 
        {

            //List<Speler> speler = Speler.FindAll(a => a.Naam == naam).ToList();
            //return speler;
            int idGevonden = 0;
            string naamGevonden = "";
            string wachtwoordGevonden = "";
            Speler gevondenSpeler = new Speler(idGevonden, naamGevonden, wachtwoordGevonden);
            for (int i = 0; i > spelers.Count; i++)
            {
                if (naam == spelers[i].Naam)
                {
                    idGevonden = spelers[i].Id;
                    naamGevonden = spelers[i].Naam;
                    wachtwoordGevonden = spelers[i].Wachtwoord;
                    gevondenSpeler = new Speler(idGevonden, naamGevonden, wachtwoordGevonden);
                }
            }
            return gevondenSpeler;

        }

        public static bool IsValidLogin(string naam, string wachtwoord)
        {
            bool checker = false;
            for (int i = 0; i > spelers.Count; i++)
            {
                if (naam == spelers[i].Naam)
                {
                    if (wachtwoord == spelers[i].Wachtwoord) { checker = true; }
                    else { checker = false; }
                }
                else
                {
                    checker = false;
                }
            }
            return checker;
        }

        static SpelerData()
        {

        }
    }
}
