using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Journey.WebApp.Controllers
{
    public class TripActivitiesController : Controller
    {
        private readonly JourneyDBContext _context;

        public TripActivitiesController(JourneyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripActivities = new TripActivities();

            tripActivities.TripDetailsId = (long)id;

            var td = await _context.TripDetails.FindAsync(id);
            ViewBag.tripCityId = td.TripCitiesId;

            return View("Edit", tripActivities);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripActivities = await _context.TripActivities.Include(ta => ta.TripDetails)
                                               .FirstOrDefaultAsync(ta => ta.Id == id);

            if (tripActivities == null)
            {
                return NotFound();
            }

            ViewBag.tripCityId = tripActivities.TripDetails.TripCitiesId;

            return View(tripActivities);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TripActivities tripActivities)
        {
            if (ModelState.IsValid)
            {
                if (tripActivities.Id == 0)
                {
                    _context.Add(tripActivities);
                }
                else
                {
                    _context.Update(tripActivities);
                }
                await _context.SaveChangesAsync();
                var td = await _context.TripDetails.FindAsync(tripActivities.TripDetailsId);
                return RedirectToAction("Details", "TripCities", new { id = td.TripCitiesId });
            }
            return View(tripActivities);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripActivities = await _context.TripActivities.FirstOrDefaultAsync(tc => tc.Id == id);

            if (tripActivities == null)
            {
                return NotFound();
            }

            //ViewBag.city = tripActivities.TripCities.City.CityName;

            return View(tripActivities);
        }

        // POST: TravelersTrips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tripActivities = await _context.TripActivities.Include(ta => ta.TripDetails)
                                               .FirstOrDefaultAsync(tc => tc.Id == id);

            _context.TripActivities.Remove(tripActivities);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "TripCities", new { id = tripActivities.TripDetails.TripCitiesId });
        }

    }
}