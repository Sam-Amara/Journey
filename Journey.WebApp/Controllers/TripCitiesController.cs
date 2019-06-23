using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Journey.WebApp.Data;
using Journey.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Journey.WebApp.Controllers
{
    [Authorize]
    public class TripCitiesController : Controller
    {
        private readonly JourneyDBContext _context;

        public TripCitiesController(JourneyDBContext context)
        {
            _context = context;
        }

        public IActionResult Create(long? id)
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

            var tripCities = await _context.TripCities.Include(tc => tc.City).FirstOrDefaultAsync(tc => tc.Id == id);

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


        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCity = await _context.TripCities.Include(tc => tc.Trip)
                                                    .ThenInclude(t => t.TripCities)
                                                    .Include(tc => tc.City)
                                                    .Include(tc => tc.TripDetails)
                                                    .ThenInclude(td => td.TripActivities)
                                                    .FirstOrDefaultAsync(tc => tc.Id == id);


            if (tripCity == null)
            {
                return NotFound();
            }
            ViewBag.trip = tripCity.Trip.TripName;
            ViewBag.city = tripCity.City.CityName;
            ViewBag.current = tripCity.Id;

            var tripCityIds = tripCity.Trip.TripCities.OrderBy(tc => tc.StartDate).Select(tc => tc.Id).ToArray();
            var index = Array.IndexOf(tripCityIds, id);

            var indexNext = tripCityIds[index + 1 >= tripCityIds.Length ? 0 : index + 1];
            var indexPrev = tripCityIds[index - 1 < 0 ? tripCityIds.Length - 1 : index - 1];

            var nextCity = await _context.TripCities.Include(tc => tc.City)
                                                    .FirstOrDefaultAsync(tc => tc.Id == indexNext);
            var prevCity = await _context.TripCities.Include(tc => tc.City)
                                                    .FirstOrDefaultAsync(tc => tc.Id == indexPrev);

            ViewBag.next = indexNext;
            ViewBag.previous = indexPrev;
            ViewBag.nextCity = nextCity.City.CityName;
            ViewBag.prevCity = prevCity.City.CityName;

            return View(tripCity.TripDetails);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCities = await _context.TripCities.Include(tc => tc.City)
                                                      .Include(t => t.Trip)
                                                      .FirstOrDefaultAsync(tc => tc.Id == id);

            if (tripCities == null)
            {
                return NotFound();
            }

            return View(tripCities);
        }

        // POST: TravelersTrips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tripCities = await _context.TripCities.Include(tc => tc.City)
                                           .Include(t => t.Trip)
                                           .FirstOrDefaultAsync(tc => tc.Id == id);

            _context.TripCities.Remove(tripCities);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "TravelerTrips", null);
        }
    }
}