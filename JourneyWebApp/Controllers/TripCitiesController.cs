using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyWebApp.Data;
using JourneyWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JourneyWebApp.Controllers
{
    [Authorize]
    public class TripCitiesController : Controller
    {
        private readonly JourneyDBContext _context;

        public TripCitiesController(JourneyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCity = new TripCities();
            
            tripCity.TripId = (long)id;
            return View("Edit", tripCity);
        }


        // GET: TravelersTrips/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCities = await _context.TripCities.Include(tc=> tc.City).FirstOrDefaultAsync(tc => tc.Id == id);

            if (tripCities == null)
            {
                return NotFound();
            }
            return View(tripCities);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TripCities tripCities, City city)
        {
            if (ModelState.IsValid)
            {
                var cityID = await MyUtility.CityFindOrAdd(_context, city);
                tripCities.CityId = cityID;

                if (tripCities.Id == 0)
                {
                    _context.Add(tripCities);
                }
                else
                {
                    _context.Update(tripCities);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "TravelerTrips", null);
            }
            return View(tripCities);
        }
    }
}