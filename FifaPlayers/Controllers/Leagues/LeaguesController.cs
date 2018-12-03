using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifaPlayers.DAOs.Leagues;
using FifaPlayers.Models;
using Microsoft.AspNetCore.Mvc;

namespace FifaPlayers.Controllers.Leagues
{
    [Route("Leagues")]
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

        [HttpGet]
        [Route("SearchLeagues")]
        public JsonResult SearchLeagues(string league)
        {
            List<League> leagues = leagueDAO.SearchLeagueNames(league);
            return Json(leagues);
        }
    }
}