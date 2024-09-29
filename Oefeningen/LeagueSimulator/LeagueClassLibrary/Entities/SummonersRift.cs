using LeagueClassLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueClassLibrary.Entities
{
    public class SummonersRift : Match
    {
        public override void GenereerTeams()
        {
            // Deze methode zorgt er voor dat de twee lists, Team1Champions en
            //Team2Champions elk gevuld zijn met vijf champion objecten met de
            //positions “sup”, “mid”, “jung”, “bot” en “top”. Gebruik hier de
            //GetRandomChampionByPosition(position) methode van ChampionData
            //voor.


            Team1Champions.Add(ChampionData.GetRandomChampionByPosition("sup"));
            Team1Champions.Add(ChampionData.GetRandomChampionByPosition("mid"));
            Team1Champions.Add(ChampionData.GetRandomChampionByPosition("jung"));
            Team1Champions.Add(ChampionData.GetRandomChampionByPosition("bot"));
            Team1Champions.Add(ChampionData.GetRandomChampionByPosition("top"));

            Team2Champions.Add(ChampionData.GetRandomChampionByPosition("sup"));
            Team2Champions.Add(ChampionData.GetRandomChampionByPosition("mid"));
            Team2Champions.Add(ChampionData.GetRandomChampionByPosition("jung"));
            Team2Champions.Add(ChampionData.GetRandomChampionByPosition("bot"));
            Team2Champions.Add(ChampionData.GetRandomChampionByPosition("top"));
        }

        public SummonersRift(string code) :base(code)
        {

        }
    }
}
