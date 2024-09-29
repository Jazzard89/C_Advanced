using LeagueClassLibrary.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueClassLibrary.Entities
{
    public class TwistedTreeline : Match
    {
        public override void GenereerTeams()
        {
            //Deze methode zorgt er voor dat de twee lists, Team1Champions en
            //Team2Champions elk gevuld zijn met drie champion objecten met de
            //positions “top”, “top” en “jung”. Gebruik hier de
            //GetRandomChampionByPosition(position) methode van ChampionData
            //voor.
        }

        public TwistedTreeline(string code) : base(code)
        {

        }
    }
}
