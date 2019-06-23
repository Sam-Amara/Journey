using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Journey.WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Journey.WebApp.Controllers
{
    public class TripDetailsController : Controller
    {
        private readonly JourneyDBContext _context;

        public TripDetailsController(JourneyDBContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Create(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripDetails = new TripDetails();

            tripDetails.TripCitiesId = (long)id;

            var city = await _context.TripCities.Include(tc => tc.City)
                                         .FirstOrDefaultAsync(tc => tc.Id == id);

            ViewBag.city = city.City.CityName;

            return View("Edit", tripDetails);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripDetails = await _context.TripDetails.Include(td => td.TripCities)
                                            .ThenInclude(tc => tc.City)
                                            .FirstOrDefaultAsync(td => td.Id == id);

            if (tripDetails == null)
            {
                return NotFound();
            }

            ViewBag.city = tripDetails.TripCities.City.CityName;

            return View(tripDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TripDetails tripDetails)
        {
            if (ModelState.IsValid)
            {
                if (tripDetails.Id == 0)
                {
                    _context.Add(tripDetails);
                }
                else
                {
                    _context.Update(tripDetails);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "TripCities", new { id = tripDetails.TripCitiesId });
            }
            return View(tripDetails);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripDetails = await _context.TripDetails.Include(td => td.TripCities)
                                                        .ThenInclude(tc => tc.City)
                                                        .FirstOrDefaultAsync(tc => tc.Id == id);

            if (tripDetails == null)
            {
                return NotFound();
            }

            ViewBag.city = tripDetails.TripCities.City.CityName;

            return View(tripDetails);
        }

        // POST: TravelersTrips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tripDetails = await _context.TripDetails.Include(td => td.TripCities)
                                                        .ThenInclude(tc => tc.City)
                                                        .FirstOrDefaultAsync(tc => tc.Id == id);

            _context.TripDetails.Remove(tripDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "TripCities", new { id = tripDetails.TripCitiesId });
        }
    }
}