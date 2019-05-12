using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Journey.WebApp.Models;
using Journey.WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly JourneyDBContext _context;

        public HomeController(JourneyDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Travelers = _context.Traveler.Include(t => t.TravelersTrips).ToList();
            return View(Travelers);
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
