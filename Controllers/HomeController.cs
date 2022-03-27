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
        private IBowlersRepository repo  {get; set;}  // set up repo


        public HomeController(IBowlersRepository yare)
        {
            repo = yare;
        }

        public IActionResult Index() // display all bowlers
        {
            ViewBag.Teams = repo.Teams.ToList();
            var bowlers = repo.Bowlers.ToList();
            return View(bowlers);
        }

        public IActionResult Team(int teamid)  // display only bowlers from a specific team
        {

            ViewBag.Team = repo.Teams.Single(x => x.TeamID == teamid);
            ViewBag.Teams = repo.Teams.ToList();
            var teamPlayers = repo.Bowlers
                .Where(x => x.TeamID == teamid)
                .ToList();
            return View(teamPlayers);
        }

        [HttpGet]
        public IActionResult Add() // add a bowler view
        {
            ViewBag.Teams = repo.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Bowler bl) // add a bowler post
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
        public IActionResult Edit(int bowlerid) // edit a bowler view
        {
            ViewBag.Teams = repo.Teams.ToList();
            var bowler = repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View(bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b) // edit a bowler post
        {
            if (ModelState.IsValid)
            {
                repo.SaveChanges(b);
                return RedirectToAction("Index");
            }
            else
            {
                return View(b);
            }
        }

        [HttpPost]
        public IActionResult Delete(int bowlerid) // delete a bowler
        {
            repo.Delete(bowlerid);
            return RedirectToAction("Index");
        }
    }
}
