using System;
using System.Collections.Generic;

namespace Journey.WebApp.Data
{
    public partial class TravelersTrips
    {
        public long TripId { get; set; }
        public long TravelerId { get; set; }

        public Traveler Traveler { get; set; }
        public Trip Trip { get; set; }
    }
}
