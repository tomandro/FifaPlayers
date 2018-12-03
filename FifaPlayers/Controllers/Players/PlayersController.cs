using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifaPlayers.DAOs.Players;
using FifaPlayers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FifaPlayers.Controllers.Players
{

    [Route("Players")]
    public class PlayersController : Controller
    {
        PlayerDAO playerDAO;

        public PlayersController(PlayerDAO playerDAO)
        {
            this.playerDAO = playerDAO;
        }
        // GET: Players
        public ActionResult Index()
        {
            var players = playerDAO.GetPlayers();
            ViewData["players"] = players;
            return View();
        }

        [HttpGet]
        [Route("SearchPlayers")]
        public JsonResult SearchPlayers(string league,string  club,string nation)
        {
            List<Player> players = playerDAO.SearchPlayers(league, club, nation);
            return Json(players);
        }
        
    }
}