using System;
using System.Collections.Generic;

namespace Journey.WebApp.Models.Entities
{
    public partial class TravelersCities
    {
        public long Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TravelerAddress { get; set; }
        public bool? IsCurrent { get; set; }
        public bool? HasLived { get; set; }
        public bool? HasVisited { get; set; }
        public bool? WantVisit { get; set; }
        public long TravelerId { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public Traveler Traveler { get; set; }
    }
}
