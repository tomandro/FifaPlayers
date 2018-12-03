using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FifaPlayers.DAOs.Clubs;
using FifaPlayers.Models;
using FifaPlayers.Utils;

namespace FifaPlayers.DAOs.Players
{
    public class ProceduresPlayerDAO : PlayerDAO
    {
        private Procedures proc;
        private ClubDAO clubDAO;
        public ProceduresPlayerDAO(Procedures proc,ClubDAO clubDAO)
        {
            this.proc = proc;
            this.clubDAO = clubDAO;
        }

        public List<string> GetNations(string nation)
        {
            throw new NotImplementedException();
        }

        public Player GetPlayer(int id)
        {
            throw new NotImplementedException();
        }

        public List<Player> GetPlayers()
        {
            List <Player> players = SearchPlayers(null, null, null);
            return players;
        }

        public List<Player> SearchPlayers(string league, string club, string nation)
        {
            List<Player> players = new List<Player>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@club", club);
            parameters.Add("@league", league);
            parameters.Add("@nation", nation);
            DataTable playerTable = proc.ExectuteStoredProcedureForValues("dbo.usp_players_search_players", parameters);

            foreach (DataRow playerRow in playerTable.Rows)
            {
                Player player = new Player()
                {
                    Id = (int)playerRow["id"],
                    Name = playerRow["player_name"].ToString(),
                    Height = (int)playerRow["height"],
                    Weight = (int)playerRow["weight"],
                    Rating = (int)playerRow["rating"],
                    Club = playerRow["club_name"].ToString(),
                    Nationality = playerRow["nation"].ToString(),
                    League = playerRow["league_name"].ToString()
                };
                players.Add(player);
            }
            return players;
        }
    }
}
