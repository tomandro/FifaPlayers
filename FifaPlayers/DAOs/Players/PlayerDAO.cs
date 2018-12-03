using FifaPlayers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifaPlayers.DAOs.Players
{
    public interface PlayerDAO
    {
        List<Player> GetPlayers();
        Player GetPlayer(int id);
        List<string> GetNations(string nation);
        List<Player> SearchPlayers(string league,string club,string nation);
    }
}
