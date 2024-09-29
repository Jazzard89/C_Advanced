using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueClassLibrary.Entities
{
    public class Champion
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Class { get; set; }
        public int ReleaseYear { get; set; }
        public List<Ability> Abilities { get; set; }

        public List<String> Positions { get; set; }
        public string IconSource { get; set; }
        public string BannerSource { get; set; }
        public int CostIP { get; set; }
        public int CostRP { get; set; }

        public Champion(string name, string title, string @class, int releaseYear, List<Ability> abilitiy, List<string> positions, string iconSource, string bannerSource, int costIP, int costRP)
        {
            Name = name;
            Title = title;
            Class = @class;
            ReleaseYear = releaseYear;
            Abilities = abilitiy;
            Positions = positions;
            IconSource = iconSource;
            BannerSource = bannerSource;
            CostIP = costIP;
            CostRP = costRP;
        }

        public override string ToString()
        {
            return Name + " " + Title;
            //Deze methode geeft de naam en titel terug van de champion.
        }

        public string GetCost()
        {
            //Deze methode geeft de IP en RP cost terug in de volgende template:
            //“RP: { CostRP} / IP: { CostIP}”.
            string value = $"RP: {CostRP} / IP: {CostIP}";
            return value;
        }
    }
}
