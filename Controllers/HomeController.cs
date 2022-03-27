using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using Microsoft.EntityFrameworkCore;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository repo  {get; set;}

        //private ITeamsRepository bro { get; set; }

        public HomeController(IBowlersRepository yare)
        {
            repo = yare;
            //bro = temp;
        }

        public IActionResult Index()
        {
            ViewBag.Teams = repo.Teams.ToList();
            var bowlers = repo.Bowlers.ToList();
            return View(bowlers);
        }

        public IActionResult Team(int teamid)
        {

            ViewBag.Team = repo.Teams.Single(x => x.TeamID == teamid);
            ViewBag.Teams = repo.Teams.ToList();
            var teamPlayers = repo.Bowlers
                .Where(x => x.TeamID == teamid)
                .ToList();
            return View(teamPlayers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teams = repo.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Bowler bl)
        {

            if (ModelState.IsValid)
            {
                repo.Add(bl);
                repo.SaveChanges(bl);
                return RedirectToAction("Index");
            }
            else
            {
                
                return View(bl);
            }
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Teams = repo.Teams.ToList();
            var bowler = repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View(bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            repo.SaveChanges(b);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int bowlerid)
        {
            repo.Delete(bowlerid);
            return RedirectToAction("Index");
        }
    }
}
