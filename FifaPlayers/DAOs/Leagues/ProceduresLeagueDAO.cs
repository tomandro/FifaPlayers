using FifaPlayers.Models;
using FifaPlayers.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FifaPlayers.DAOs.Leagues
{
    public class ProceduresLeagueDAO : LeagueDAO
    {
        private Procedures proc;
        public ProceduresLeagueDAO(Procedures proc)
        {
            this.proc = proc;
        }

        public League GetLeague(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            DataTable leagues = proc.ExectuteStoredProcedureForValues("dbo.usp_leagues_get_league",parameters);
            if(leagues.Rows.Count == 0)
            {
                throw new ArgumentException("No leagues matched this id");
            }
            else
            {
                DataRow leagueRow = leagues.Rows[0];
                League league = new League()
                {
                    Id = id,
                    Name = leagueRow["name"].ToString(),
                    AbbrName = leagueRow["abbrName"].ToString()
                };
                return league;
            }
        }

        public List<League> GetLeagues()
        {
            throw new NotImplementedException();
        }

        public List<League> SearchLeagueNames(string leagueName)
        {
            List<League> leagues = new List<League>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@league", leagueName);
            DataTable leaguesTable = proc.ExectuteStoredProcedureForValues("dbo.usp_leagues_search_league", parameters);

            foreach (DataRow leagueRow in leaguesTable.Rows)
            {
                League league = new League()
                {
                    Id = (int)leagueRow["id"],
                    Name = leagueRow["name"].ToString(),
                    AbbrName = leagueRow["abbrName"].ToString()
                };
                leagues.Add(league);
            }
            return leagues;
        }
    }
}
