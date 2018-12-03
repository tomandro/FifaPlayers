using FifaPlayers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifaPlayers.DAOs.Clubs
{
    public interface ClubDAO
    {
        List<Club> GetClubs();
        Club GetClub(int id);
        List<Club> SearchClubNames(string clubName);
    }
}
