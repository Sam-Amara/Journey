using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JourneyWebApp.Data
{
    public partial class TravelersCities
    {
        public long Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public string TravelerAddress { get; set; }
        public bool IsCurrent { get; set; }
        public bool HasLived { get; set; }
        public bool HasVisited { get; set; }
        public bool WantVisit { get; set; }
        public long TravelerId { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public Traveler Traveler { get; set; }
    }
}
