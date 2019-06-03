using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JourneyWebApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace JourneyWebApp.Controllers
{
    [Authorize]
    public class TravelerCitiesController : Controller
    {
        private readonly JourneyDBContext _context;

        public TravelerCitiesController(JourneyDBContext context)
        {
            _context = context;
        }

        // GET: TravelerCities
        public async Task<IActionResult> Index()
        {
            var travelerID = (int)TempData.Peek("TravelerID");
            var journeyDBContext = _context.TravelersCities.Where(tc => tc.Traveler.Id == travelerID).Include(t => t.City);
            return View(await journeyDBContext.ToListAsync());
        }

        // GET: TravelerCities/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelersCities = await _context.TravelersCities
                .Include(t => t.City)
                .Include(t => t.Traveler)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelersCities == null)
            {
                return NotFound();
            }

            return View(travelersCities);
        }

        // GET: TravelerCities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TravelerCities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,TravelerAddress,IsCurrent,HasLived,HasVisited,WantVisit")] TravelersCities travelersCities, City city)
        {
            if (ModelState.IsValid)
            {
                var cityID = await CityFindOrAdd(city);
                travelersCities.CityId = cityID;

                var travelerID = (int)TempData.Peek("TravelerID");
                travelersCities.TravelerId = travelerID;

                _context.Add(travelersCities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelersCities);
        }

        // GET: TravelerCities/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var travelersCities =  await _context.TravelersCities.Include(tc => tc.City).FirstOrDefaultAsync(m => m.Id == id); ;

            if (travelersCities == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "CityName", travelersCities.CityId);
            ViewData["TravelerId"] = new SelectList(_context.Traveler, "Id", "Id", travelersCities.TravelerId);
            return View(travelersCities);
        }

        // POST: TravelerCities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,StartDate,EndDate,TravelerAddress,IsCurrent,HasLived,HasVisited,WantVisit,TravelerId,CityId")] TravelersCities travelersCities)
        {
            if (id != travelersCities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelersCities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelersCitiesExists(travelersCities.Id))
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
            ViewData["CityId"] = new SelectList(_context.City, "Id", "CityName", travelersCities.CityId);
            ViewData["TravelerId"] = new SelectList(_context.Traveler, "Id", "Id", travelersCities.TravelerId);
            return View(travelersCities);
        }

        // GET: TravelerCities/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelersCities = await _context.TravelersCities
                .Include(t => t.City)
                .Include(t => t.Traveler)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelersCities == null)
            {
                return NotFound();
            }

            return View(travelersCities);
        }

        // POST: TravelerCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var travelersCities = await _context.TravelersCities.FindAsync(id);
            _context.TravelersCities.Remove(travelersCities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelersCitiesExists(long id)
        {
            return _context.TravelersCities.Any(e => e.Id == id);
        }

        private async Task<int> CityFindOrAdd(City cityToFind)
        {
            var name = cityToFind.CityName.Trim().ToLower();
            var state = cityToFind.CityState?.Trim().ToLower();
            var country = cityToFind.Country.Trim().ToLower();

            var city = await _context.City.FirstOrDefaultAsync(c => c.CityName.ToLower() == name
                                                  && (string.IsNullOrEmpty(state) || c.CityState.ToLower() == state)
                                                  && c.Country.ToLower()   == country);

            if(city == null)
            {
                city = new City()
                {
                    CityName = name,
                    CityState = state,
                    Country = country
                };

                _context.Add(city);
                await _context.SaveChangesAsync();
            }

            return city.Id;
        }
    } 
}
