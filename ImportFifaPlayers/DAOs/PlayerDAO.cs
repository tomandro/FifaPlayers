using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ImportFifaPlayers.Models;

namespace ImportFifaPlayers.DAOs
{
    class PlayerDAO
    {
        private ClubDAO clubDAO;
        public PlayerDAO(ClubDAO clubDAO)
        {
            this.clubDAO = clubDAO;
        }

        public Player GetClub(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            DataTable dt = ConnectionPool.GetInstance().ExectuteStoredProcedureForValues("dbo.usp_players_get_player", parameters);
            if (dt.Rows.Count == 0)
            {
                throw new ArgumentException("No rows match this id");
            }
            else
            {
                DataRow playerRow = dt.Rows[0];
                int club_id = (int)playerRow["club"];
                Club club = clubDAO.GetClub(club_id);
                Player player = new Player()
                {
                    Id = (int)playerRow["id"],
                    Name = playerRow["name"].ToString(),
                    Age = (int)playerRow["age"],
                    Height = (int)playerRow["height"],
                    Weight= (int)playerRow["weight"],
                    Rating = (int)playerRow["rating"],
                    Nation = playerRow["nation"].ToString(),
                    Position = playerRow["position"].ToString(),
                    Club = club,

                };
                return player;
            }
        }

        public void InsertPlayer(Player player)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("@name", player.Name);
            parameters.Add("@rating", player.Rating);
            parameters.Add("@height", player.Height);
            parameters.Add("@age", player.Age);
            parameters.Add("@weight", player.Weight);
            parameters.Add("@club", player.Club.Id);
            parameters.Add("@position", player.Position);
            parameters.Add("@nation", player.Nation);
            ConnectionPool.GetInstance().ExectuteStoredProcedure("dbo.usp_players_insert_new_player", parameters);
        }
    }
}
