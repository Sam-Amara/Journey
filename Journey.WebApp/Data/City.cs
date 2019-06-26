using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journey.WebApp.Data
{
    public partial class City
    {
        public City()
        {
            TravelersCities = new HashSet<TravelersCities>();
            TripCities = new HashSet<TripCities>();
        }

        public int Id { get; set; }

        [Display(Name = "City")]
        public string CityName { get; set; }

        public string Country { get; set; }

        [Display(Name = "State/Province")]
        public string CityState { get; set; }

        public ICollection<TravelersCities> TravelersCities { get; set; }
        public ICollection<TripCities> TripCities { get; set; }
    }
}
