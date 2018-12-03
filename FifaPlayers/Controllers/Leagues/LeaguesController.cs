using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifaPlayers.DAOs.Leagues;
using Microsoft.AspNetCore.Mvc;

namespace FifaPlayers.Controllers.Leagues
{
    [Route("league")]
    public class LeaguesController : Controller
    {
        private LeagueDAO leagueDAO;
        public LeaguesController(LeagueDAO leagueDAO)
        {
            this.leagueDAO = leagueDAO;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}