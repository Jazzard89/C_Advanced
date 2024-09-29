using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueClassLibrary.Entities
{
    public interface IWinnable
    {
        int Winner { get; set; }
        void DecideWinner();
        
            //o De winnaar wordt bepaald op basis van de volgende criteria:
            //▪ Het team met de champions die het meest recente gemiddelde
            //ReleaseYear hebben wint.
            //▪ Indien twee teams hetzelfde gemiddelde ReleaseYear hebben,
            //dan wint het team met de meeste champions die de Assassin
            //Class hebben.
            //▪ Indien beide teams evenveel Assassin Classes hebben, dan wint
            //team 1(“Red”).

      

    }
}
