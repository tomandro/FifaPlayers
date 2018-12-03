using FifaPlayers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace FifaPlayers.DAOs.Players
{
    
    /**
     * A dummy Data accessor object for testing.
     */
    public class PlayerTestingDAO :PlayerDAO
    {
        String desktopFilePath = "C:\\Users\\Thomas\\Desktop\\FifaWebApp\\Players.js"; 

        public PlayerTestingDAO()
        {
            if(File.Exists(desktopFilePath))
            {
                File.Create(desktopFilePath).Close();
            }
        }

        public List<string> GetNations(string nation)
        {

            return new string[1]{nation}.ToList();
        }

        public Player GetPlayer(int id)
        {
            return new Player()
            {
                Name = "Thomas Roberts",
                Age = 25,
                Height = 192,
                Weight = 159,
                Rating = 69,
                Club = "Macclesfield",
                Nationality = "Wales",
                Position = "CB"

            };
        }

        public List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player() {
                Name = "Thomas Roberts",
                Age = 25,
                Height = 192,
                Weight = 159,
                Rating = 69,
                Club = "Macclesfield",
                Nationality = "Wales",
                Position = "CB"
                
            });
            players.Add(new Player()
            {
                Name = "Carl Hale",
                Age = 23,
                Height = 175,
                Weight = 140,
                Rating = 64,
                Club = "Macclesfield",
                Nationality = "England",
                Position = "CM"

            });

            players.Add(new Player()
            {
                Name = "Peter Bough",
                Age = 23,
                Height = 183,
                Weight = 145,
                Rating = 62,
                Club = "Macclesfield",
                Nationality = "Wales",
                Position = "ST"

            });

            return players;
        }

        public List<Player> SearchPlayers(string league, string club, string nation)
        {
            throw new NotImplementedException();
        }
    }
}
