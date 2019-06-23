using Journey.WebApp.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journey.WebApp.Models
{
    public class ProfileViewModel
    {
        public Traveler Traveler { get; set; }
        public IFormFile Upload { get; set; }
    }
}
