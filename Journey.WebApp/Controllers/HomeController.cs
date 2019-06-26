using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Journey.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Journey.WebApp.Data;
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

        [Authorize]
        public IActionResult Index()
        {
            //var user = _context.Users.Include(u => u.Traveler).Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            var traveler = _context.Traveler.Include(t => t.User)
                                            .Include(t=> t.TravelerAlbum)
                                            .Include(t => t.TravelerRelationshipsTravelerId1Navigation)
                                            .ThenInclude(r => r.TravelerId2Navigation)
                                            .Include(t => t.TravelersCities)
                                            .ThenInclude(tc => tc.City)
                                            .Include(t => t.TravelersTrips)
                                            .ThenInclude(tt => tt.Trip)
                                            .Where(t => t.User.UserName == User.Identity.Name).FirstOrDefault();

            TempData["User"] = traveler.FirstName ?? User.Identity.Name;
            TempData["TravelerID"] = traveler.Id;

            return View(traveler);
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
