using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Journey.WebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Journey.WebApp.Models;
using System.Net.Http.Headers;

namespace Journey.WebApp.Views.Home
{
    public class TravelerController : Controller
    {
        private readonly JourneyDBContext _context;
        private HttpClient _httpClient;
        private Options _options;

        public TravelerController(JourneyDBContext context, HttpClient httpClient, Options options)
        {
            _context = context;
            _httpClient = httpClient;
            _options = options;
        }


        // GET: Traveler/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || (int)TempData.Peek("TravelerID") != id)
            {
                return NotFound();
            }

            var traveler = await _context.Traveler.Include(t => t.TravelerAlbum)
                                                  .ThenInclude(ta => ta.AlbumPhoto)
                                                  .ThenInclude(ap => ap.Photo)
                                                  .FirstOrDefaultAsync(t => t.Id == id);

            if (traveler == null)
            {
                return NotFound();
            }

            var profile = new ProfileViewModel
            {
                Traveler = traveler,
            };

            ViewBag.profilePic = await FindOrCreateProfileAlbum(traveler);

            return View(profile);
        }


        // POST: Traveler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ProfileViewModel profile)
        {
            if (id != profile.Traveler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Upload =  profile.Upload;
                    if (Upload != null && Upload.Length > 0)
                    {
                        var imagesUrl = _options.ApiUrl;

                        using (var image = new StreamContent(Upload.OpenReadStream()))
                        {
                            image.Headers.ContentType = new MediaTypeHeaderValue(Upload.ContentType);
                            var response = await _httpClient.PostAsync(imagesUrl, image);
                        }
                    }

                    _context.Update(profile.Traveler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelerExists(profile.Traveler.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }

            return View(profile);
        }

        private bool TravelerExists(long id)
        {
            return _context.Traveler.Any(e => e.Id == id);
        }

        private async Task<string> FindOrCreateProfileAlbum(Traveler traveler)
        {
            var profileAlbum = traveler.TravelerAlbum.FirstOrDefault(ta => ta.AlbumName.Equals("Profile Photos"));

            if(profileAlbum == null)
            {
                profileAlbum = new TravelerAlbum
                {
                    AlbumName = "Profile Photos",
                    DateCreated = DateTime.Now,
                    TravelerId = traveler.Id
                };

                _context.TravelerAlbum.Add(profileAlbum);
                await _context.SaveChangesAsync();
            }
            else
            {
                var profilePic = profileAlbum.AlbumPhoto.LastOrDefault()?.Photo;

                if (profilePic != null)
                    return profilePic.FilePath;
            }

            return null;
        }
    }
}
