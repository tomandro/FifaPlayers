using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FifaPlayers.Controllers.Clubs
{
    [Route("Clubs")]
    public class ClubsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}