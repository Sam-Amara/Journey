using Journey.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journey.WebApp.Models
{
    public class ProfileViewModel
    {
        public Traveler Traveler { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }
    }
}
