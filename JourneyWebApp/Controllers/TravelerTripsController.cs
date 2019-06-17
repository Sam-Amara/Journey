using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JourneyWebApp.Data;

namespace JourneyWebApp.Controllers
{
    public class TravelerTripsController : Controller
    {
        private readonly JourneyDBContext _context;

        public TravelerTripsController(JourneyDBContext context)
        {
            _context = context;
        }

        // GET: TravelersTrips
        public async Task<IActionResult> Index()
        {
            var travelerID = (int)TempData.Peek("TravelerID");
            var journeyDBContext = _context.TravelersTrips.Where(tc => tc.Traveler.Id == travelerID)
                                                          .Include(t => t.Trip)
                                                          .ThenInclude(tr => tr.TripCities)
                                                          .ThenInclude(tc => tc.City);
            return View(await journeyDBContext.ToListAsync());
        }

        // GET: TravelersTrips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TravelersTrips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TravelersTrips travelersTrips, Trip trip)
        {
            if (ModelState.IsValid)
            {
                trip.DateCreated = DateTime.Now;
                _context.Add(trip);
                await _context.SaveChangesAsync();

                var travelerID = (int)TempData.Peek("TravelerID");
                travelersTrips.TravelerId = travelerID;
                travelersTrips.TripId = trip.Id;

                _context.Add(travelersTrips);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelersTrips);
        }

        // GET: TravelersTrips/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelerID = (int)TempData.Peek("TravelerID");

            var travelersTrips = await _context.TravelersTrips.Where(tc => tc.Traveler.Id == travelerID)
                                                              .Include(t => t.Trip)
                                                              .FirstOrDefaultAsync(tt => tt.TripId == id);
            if (travelersTrips == null)
            {
                return NotFound();
            }
            return View(travelersTrips);
        }

        // POST: TravelersTrips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, TravelersTrips tt)
        {
            
            
            if (id != tt.TripId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var travelerTrip = tt.Trip;
                try
                {
                    travelerTrip.Id = id;
                    _context.Update(travelerTrip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelersTripsExists(travelerTrip.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(id);
        }

        // GET: TravelersTrips/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelersTrips = await _context.TravelersTrips
                .Include(t => t.Traveler)
                .Include(t => t.Trip)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (travelersTrips == null)
            {
                return NotFound();
            }

            return View(travelersTrips);
        }

        // POST: TravelersTrips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var travelersTrips = await _context.TravelersTrips.FindAsync(id);
            _context.TravelersTrips.Remove(travelersTrips);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelersTripsExists(long id)
        {
            return _context.TravelersTrips.Any(e => e.TripId == id);
        }
    }
}
