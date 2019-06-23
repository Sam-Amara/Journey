using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journey.WebApp.Data
{
    public partial class TripCities
    {
        public TripCities()
        {
            TripDetails = new HashSet<TripDetails>();
        }

        public long Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public int CityId { get; set; }
        public long TripId { get; set; }

        public City City { get; set; }
        public Trip Trip { get; set; }
        public ICollection<TripDetails> TripDetails { get; set; }
    }
}
