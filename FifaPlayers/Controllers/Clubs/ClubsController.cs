using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifaPlayers.DAOs.Clubs;
using FifaPlayers.Models;
using Microsoft.AspNetCore.Mvc;

namespace FifaPlayers.Controllers.Clubs
{
    [Route("Clubs")]
    public class ClubsController : Controller
    {
        private ClubDAO clubDAO;
        public ClubsController(ClubDAO clubDAO)
        {
            this.clubDAO = clubDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("SearchClubs")]
        public JsonResult SearchClubs(string club,string league=null)
        {
            List<Club> clubs = clubDAO.SearchClubNames(club,league);
            return Json(clubs);
        }
    }
}