using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FifaPlayers.DAOs.Leagues;
using FifaPlayers.Models;
using FifaPlayers.Utils;

namespace FifaPlayers.DAOs.Clubs
{
    public class ProceduresClubDAO : ClubDAO
    {
        private Procedures proc;
        private LeagueDAO leagueDAO;
        public ProceduresClubDAO(Procedures proc,LeagueDAO leagueDAO)
        {
            this.proc = proc;
            this.leagueDAO = leagueDAO;
        }

        public Club GetClub(int id)
        {
            throw new NotImplementedException();
        }

        public List<Club> GetClubs()
        {
            throw new NotImplementedException();
        }

        public List<Club> SearchClubNames(string clubName,string leagueName)
        {
            List<Club> clubs = new List<Club>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@club", clubName);

            parameters.Add("@league", leagueName);
            DataTable clubsTable = proc.ExectuteStoredProcedureForValues("dbo.usp_clubs_search_club", parameters);

            foreach (DataRow clubRow in clubsTable.Rows)
            {
                Club club = new Club()
                {
                    Id = (int)clubRow["id"],
                    Name = clubRow["name"].ToString(),
                    AbbrName = clubRow["abbr_name"].ToString(),
                    LeagueId = (int)clubRow["league"]
                };
                clubs.Add(club);
            }
            return clubs;
        }
    }
}
