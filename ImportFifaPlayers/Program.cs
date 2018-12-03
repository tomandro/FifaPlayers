using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using ImportFifaPlayers.DAOs;
using ImportFifaPlayers.Models;
using Newtonsoft.Json.Linq;

namespace ImportFifaPlayers
{
    class Program
    {
        static List<Club> clubs;
        static List<League> leagues;

        PlayerDAO playerDAO;
        ClubDAO clubDAO;
        LeagueDAO leagueDAO;

        public Program()
        {
            leagueDAO = new LeagueDAO();
            clubDAO = new ClubDAO(leagueDAO);
            playerDAO = new PlayerDAO(clubDAO);
        }

        static void Main(string[] args)
        {
            try
            {
                Program p = new Program();
                clubs = new List<Club>();
                leagues = new List<League>();
                List<Player> players = p.ImportPlayers();
                Console.WriteLine("Imported players");
                p.AddPlayers(players);
                
                    

                Console.WriteLine("Success");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadKey();
        }

        public void AddPlayers(List<Player> players)
        {
            foreach(Player p in players)
            {
                playerDAO.InsertPlayer(p);
            }
        }

        public  void InsertIfNewClub(Club club)
        {
            if(!clubs.Contains(club))
            {
                clubDAO.InsertClub(club);
                clubs.Add(club);
            }
        }

        public  void InsertIfNewLeague(League league)
        {
            if (!leagues.Contains(league))
            {
                leagueDAO.InsertLeague(league);
                leagues.Add(league);
            }
        }

        public List<Player> ImportPlayers()
        {
            List<Player> players = new List<Player>();
            List<int> baseIDS = new List<int>();

            String baseURL = "https://www.easports.com/fifa/ultimate-team/api/fut/item?page=";
            int page = 1;
            int totalPages = 200;
            Boolean requestFailed = false;
            do
            {
                String instanceUrl = baseURL + page;
                Console.WriteLine("Connecting to " + instanceUrl);
                WebRequest request = WebRequest.Create(instanceUrl);
                using (WebResponse response = request.GetResponse())
                {
                    String responseEncodingStr = response.ContentType;

                    MemoryStream ms = new MemoryStream();
                    response.GetResponseStream().CopyTo(ms);
                    byte[] responseBody = ms.ToArray();
                    String s = Encoding.UTF8.GetString(responseBody);
                    JObject jsonData = JObject.Parse(s);
                    if (totalPages == -1)
                    {
                        totalPages = jsonData["totalPages"].Value<int>();
                    }

                    JArray items = jsonData["items"].Value<JArray>();
                    //loop through items array,  contains json for each player.
                    for (int i = 0; i < items.Count; i++)
                    {
                        JObject json = (JObject)items[i];
                        int baseId = json.Value<int>("baseId");
                        if (baseIDS.Contains(baseId) == false)
                        {
                            baseIDS.Add(baseId);
                            string name;
                            string commonName = json.Value<string>("commonName");
                            if (commonName == "")
                            {
                                name = json.Value<string>("firstName")
                                    + " " + json.Value<string>("lastName");
                            }
                            else
                            {
                                name = commonName;
                            }

                            Player p = new Player();
                            p.Name = name;
                            p.Age = json["age"].Value<int>();
                            p.Height = json["height"].Value<int>();
                            p.Weight = json["weight"].Value<int>();
                            p.Rating = json["rating"].Value<int>();
                            p.Position = json["position"].Value<string>();
                            p.Nation = json["nation"]["name"].Value<string>();
                            League league = new League()
                            {
                                Id = json["league"]["id"].Value<int>(),
                                Name= json["league"]["name"].Value<string>(),
                                AbbrName = json["league"]["abbrName"].Value<string>()
                            };
                            this.InsertIfNewLeague(league);
                            Club club = new Club()
                            {
                                Id = json["club"]["id"].Value<int>(),
                                Name = json["club"]["name"].Value<string>(),
                                AbbrName = json["club"]["abbrName"].Value<string>(),
                                League = league
                            };
                            this.InsertIfNewClub(club);
                            p.Club = club;

                            if (p.Club.Name != "Icons")
                            {
                                players.Add(p);
                            }
                            
                        }
                    }


                    page++;
                    if (page > totalPages)
                    {
                        requestFailed = true;
                    }
                }

            } while (!requestFailed);

            return players;
        }

        public void ReadPlayers(SqlConnection con, String query)
        {
            using (SqlCommand command = new SqlCommand(query, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    bool f = reader.Read();
                }
            }
        }
    }
}
