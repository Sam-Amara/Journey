using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace Journey.WebApp.Controllers
{
    public class TripDetailsController : Controller
    {
        private readonly JourneyDBContext _context;

        public TripDetailsController(JourneyDBContext context)
        {
            _context = context;
        }


        public IActionResult Create(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripDetails = new TripDetails();

            tripDetails.TripCitiesId = (long)id;

            return View(tripDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TripDetails tripDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "TripCities", new { id = tripDetails.TripCitiesId });
            }
            return View(tripDetails);
        }
    }
}