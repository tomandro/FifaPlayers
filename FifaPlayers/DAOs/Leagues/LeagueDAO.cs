using FifaPlayers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifaPlayers.DAOs.Leagues
{
    public interface LeagueDAO
    {
        List<League> GetLeagues();
        League GetLeague(int id);
        List<League> SearchLeagueNames(string leagueName);
    }
}
