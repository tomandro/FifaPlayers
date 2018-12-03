using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifaPlayers.DAOs.Players;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FifaPlayers.Controllers.Players
{
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
    }
}