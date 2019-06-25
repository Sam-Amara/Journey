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
            //var albumList = await _context.AlbumPhoto.Include(ap => ap.Photo).Include(ap => ap.Album)
            //.Where(ta => ta.Album.TravelerId == travelerId).ToListAsync();

            var albumList = await _context.TravelerAlbum.Where(ta => ta.TravelerId == travelerId).ToListAsync();


            return View(albumList);
        }

        public async Task<IActionResult> Photos(long? id)
        {

            var photosList = await _context.AlbumPhoto.Include(ap => ap.Photo)
                                            .Where(ta => ta.AlbumId == id).ToListAsync();

            return View(photosList);
        }
    }
}