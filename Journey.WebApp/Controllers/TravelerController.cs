using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JourneyWebApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace JourneyWebApp.Views.Home
{
    public class TravelerController : Controller
    {
        private readonly JourneyDBContext _context;

        public TravelerController(JourneyDBContext context)
        {
            _context = context;
        }


        // GET: Traveler/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || (int)TempData.Peek("TravelerID") != id)
            {
                return NotFound();
            }

            var traveler = await _context.Traveler.FindAsync(id);
            if (traveler == null)
            {
                return NotFound();
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", traveler.UserId);
            return View(traveler);
        }

        // POST: Traveler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,Phone,Dob,Gender,Email2,AboutMe,Occupation,Hobbies,SocialMedia,DateCreated,UserId")] Traveler traveler)
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
                //return RedirectToAction("Index", "Home");
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", traveler.UserId);
            return View(traveler);
        }

        private bool TravelerExists(long id)
        {
            return _context.Traveler.Any(e => e.Id == id);
        }
    }
}
