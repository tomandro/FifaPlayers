using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifaPlayers.DAOs.Clubs;
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
    }
}