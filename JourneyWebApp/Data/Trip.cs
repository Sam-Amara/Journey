using System;
using System.Collections.Generic;

namespace JourneyWebApp.Data
{
    public partial class Trip
    {
        public Trip()
        {
            TravelerAlbum = new HashSet<TravelerAlbum>();
            TravelersTrips = new HashSet<TravelersTrips>();
            TripCities = new HashSet<TripCities>();
        }

        public long Id { get; set; }
        public string TripName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Descript { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<TravelerAlbum> TravelerAlbum { get; set; }
        public ICollection<TravelersTrips> TravelersTrips { get; set; }
        public ICollection<TripCities> TripCities { get; set; }
    }
}
