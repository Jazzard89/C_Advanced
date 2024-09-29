using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindomSimClassLibrary.Entities
{
    public class Speler
    {
        public int Economy { get; set; }
        public int Happiness { get; set; }
        public int Id { get; set; }
        public int Military { get; set; }
        public string Naam { get; set; }
        public int Piety { get; set; }
        public string Wachtwoord { get; set; }


        public bool IsSpelerLevend()
        {
            bool outcome = false;
            if ((Military > 0) && (Piety > 0) && (Economy > 0))
            {
                outcome = true;
            }
            else
            {
                outcome = false;
            }
            return outcome;
        }
        public void ResetKingdom()
        {

        }


        public Speler(int id, string naam, string wachtwoord)
        {
            Id = id;
            Naam = naam;
            Wachtwoord = wachtwoord;
            Military = 50;
            Piety = 50;
            Economy = 50;
            Happiness = 50;
        }

        public void VeranderAlleCategorieen(int waarde)
        {

        }

        public void VeranderCategorie(string categorie, int waarde)
        {
            switch (categorie)
            {
                case "Military":
                    Military += waarde;
                    break;
                case "Piety":
                    Piety += waarde; 
                    break;
                case "Economy":
                    Economy += waarde;
                    break;
                default:
                    break;
            }
        }

        public int WaardeVanCategorie(string categorie)
        {
            int returnValue = 0;
            switch (categorie)
            {
                case "Military":
                    Military = returnValue;
                    break;
                case "Piety":
                    Piety = returnValue;
                    break;
                case "Economy":
                    Economy = returnValue;
                    break;
                default:
                    break;
            }

            return returnValue;
        }




    }
}
