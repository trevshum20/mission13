using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo  {get; set;}

        //private ITeamsRepository bro { get; set; }

        public HomeController(IBowlersRepository yare)
        {
            _repo = yare;
            //bro = temp;
        }

        public IActionResult Index()
        {
            ViewBag.Teams = _repo.Teams.ToList();
            var bowlers = _repo.Bowlers.ToList();
            return View(bowlers);
        }

        public IActionResult Team(int teamid)
        {
            ViewBag.Team = _repo.Teams.Single(x => x.TeamID == teamid);
            ViewBag.Teams = _repo.Teams.ToList();
            var teamPlayers = _repo.Bowlers
                .Where(x => x.TeamID == teamid)
                .ToList();
            return View(teamPlayers);
        }
    }
}
