﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JourneyWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using JourneyWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace JourneyWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly JourneyDBContext _context;

        public HomeController(JourneyDBContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var LoggedTraveler = _context.Traveler.Include(t => t.TravelersTrips).FirstOrDefault(t => t.UserId == User.Identity.Name);
            return View(LoggedTraveler);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
