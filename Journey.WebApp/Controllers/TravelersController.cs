using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Journey.WebApp.Models.Entities;

namespace Journey.WebApp.Controllers
{
    public class TravelersController : Controller
    {
        private readonly JourneyDBContext _context;

        public TravelersController(JourneyDBContext context)
        {
            _context = context;
        }

        // GET: Travelers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Traveler.ToListAsync());
        }

        // GET: Travelers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveler = await _context.Traveler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (traveler == null)
            {
                return NotFound();
            }

            return View(traveler);
        }

        // GET: Travelers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Travelers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Phone,Dob,Gender,Email2,AboutMe,Occupation,Hobbies,SocialMedia")] Traveler traveler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traveler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(traveler);
        }

        // GET: Travelers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveler = await _context.Traveler.FindAsync(id);
            if (traveler == null)
            {
                return NotFound();
            }
            return View(traveler);
        }

        // POST: Travelers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id, FirstName,LastName,Phone,Dob,Gender,Email2,AboutMe,Occupation,Hobbies,SocialMedia")] Traveler traveler)
        {
            if (id != traveler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traveler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelerExists(traveler.Id))
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
            return View(traveler);
        }

        // GET: Travelers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveler = await _context.Traveler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (traveler == null)
            {
                return NotFound();
            }

            return View(traveler);
        }

        // POST: Travelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var traveler = await _context.Traveler.FindAsync(id);
            _context.Traveler.Remove(traveler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelerExists(long id)
        {
            return _context.Traveler.Any(e => e.Id == id);
        }
    }
}
