using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueClassLibrary.Entities
{
    public abstract class Match : IWinnable
    {
        public List<Champion> Team1Champions { get; set; }
        public List<Champion> Team2Champions { get; set; }

        public int Winner { get; set; }

        public string Code { get; set; }
        public Match(string code)
        {
            this.Code = code;
        }

        public void DecideWinner()
        {

        }

        public abstract void GenereerTeams();
    }
}
