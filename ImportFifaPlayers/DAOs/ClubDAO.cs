using ImportFifaPlayers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ImportFifaPlayers.DAOs
{
    class ClubDAO
    {
        private LeagueDAO leagueDAO;
        public ClubDAO(LeagueDAO leagueDAO)
        {
            this.leagueDAO = leagueDAO;
        }

        public Club GetClub(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            DataTable dt = ConnectionPool.GetInstance().ExectuteStoredProcedureForValues("dbo.usp_clubs_get_club", parameters);
            if (dt.Rows.Count == 0)
            {
                throw new ArgumentException("No rows match this id");
            }
            else
            {
                DataRow clubRow = dt.Rows[0];
                int league_id = (int)clubRow["league"];
                League league = leagueDAO.GetLeague(league_id);
                Club club = new Club()
                {
                    Id = id,
                    Name = clubRow["name"].ToString(),
                    AbbrName = clubRow["abbrName"].ToString(),
                    League = league
                };
                return club;
            }
        }

        public void InsertClub(Club club)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("@id", club.Id);
            parameters.Add("@name", club.Name);
            parameters.Add("@abbrName", club.AbbrName);
            parameters.Add("@league", club.League.Id);
            ConnectionPool.GetInstance().ExectuteStoredProcedure("dbo.usp_clubs_insert_new_club", parameters);
        }
    }
}
