using ImportFifaPlayers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ImportFifaPlayers.DAOs
{
    class LeagueDAO
    {
        public League GetLeague(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            DataTable dt = ConnectionPool.GetInstance().ExectuteStoredProcedureForValues("dbo.usp_leagues_get_league",parameters);
            if(dt.Rows.Count == 0)
            {
                throw new ArgumentException("No rows match this id");
            }
            else
            {
                DataRow leagueRow = dt.Rows[0];
                League league = new League()
                {
                    Id=id,
                    Name = leagueRow["name"].ToString(),
                    AbbrName = leagueRow["abbrName"].ToString()
                };
                return league;
            }
        }

        public void InsertLeague(League league)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("@id", league.Id);
            parameters.Add("@name", league.Name);
            parameters.Add("@abbrName", league.AbbrName);
            ConnectionPool.GetInstance().ExectuteStoredProcedure("dbo.usp_leagues_insert_new_league", parameters);
        }
    }
}
