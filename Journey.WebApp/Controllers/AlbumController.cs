using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Journey.WebApp.Data;
using Journey.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Journey.WebApp.Controllers
{
    public class AlbumController : Controller
    {
        private readonly JourneyDBContext _context;
        private HttpClient _httpClient;
        private Options _options;

        public AlbumController(JourneyDBContext context, HttpClient httpClient, Options options)
        {
            _context = context;
            _httpClient = httpClient;
            _options = options;
        }

        public async Task<IActionResult> Index()
        {
            var travelerId = (int)TempData.Peek("TravelerID");

            var albumList = await _context.TravelerAlbum.Where(ta => ta.TravelerId == travelerId).ToListAsync();


            return View(albumList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TravelerAlbum travelerAlbum)
        {
            if (ModelState.IsValid)
            {
                travelerAlbum.TravelerId = (int)TempData.Peek("TravelerID");
                travelerAlbum.DateCreated = DateTime.Now;
                _context.Add(travelerAlbum);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return PartialView(travelerAlbum);
        }

        public async Task<IActionResult> Photos(long? id)
        {

            var photosList = await _context.AlbumPhoto.Include(ap => ap.Photo)
                                            .Where(ta => ta.AlbumId == id).ToListAsync();

            ViewBag.albumId = id;

            return View(photosList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Photos(long? id, PhotoViewModel photo)
        {
            if (ModelState.IsValid)
            {

                var p = await MyUtility.UploadPhoto(_context, _httpClient, _options, photo.Upload, (long)id);
                var album = await _context.TravelerAlbum.FindAsync(id);

                p.PhotoName = photo.AlbumPhoto.Photo.PhotoName;
                p.Loc = photo.AlbumPhoto.Photo.Loc;

                album.Thumbnail = p.Thumbnail;
                _context.Update(album);


                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Photos));
            }
            return PartialView(photo);
        }
    }
}