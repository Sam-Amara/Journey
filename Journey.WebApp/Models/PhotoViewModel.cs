using Journey.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journey.WebApp.Models
{
    public class PhotoViewModel
    {
        public AlbumPhoto AlbumPhoto { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }
    }
}
