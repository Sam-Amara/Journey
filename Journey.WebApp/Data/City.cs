using System;
using System.Collections.Generic;

namespace JourneyWebApp.Data
{
    public partial class City
    {
        public City()
        {
            TravelersCities = new HashSet<TravelersCities>();
            TripCities = new HashSet<TripCities>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string CityState { get; set; }

        public ICollection<TravelersCities> TravelersCities { get; set; }
        public ICollection<TripCities> TripCities { get; set; }
    }
}
