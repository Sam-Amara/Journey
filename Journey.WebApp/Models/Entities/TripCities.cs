using System;
using System.Collections.Generic;

namespace Journey.WebApp.Models.Entities
{
    public partial class TripCities
    {
        public TripCities()
        {
            TripDetails = new HashSet<TripDetails>();
        }

        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public int CityId { get; set; }
        public long TripId { get; set; }

        public City City { get; set; }
        public Trip Trip { get; set; }
        public ICollection<TripDetails> TripDetails { get; set; }
    }
}
