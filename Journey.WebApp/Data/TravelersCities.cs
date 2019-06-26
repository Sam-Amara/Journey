using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journey.WebApp.Data
{
    public partial class TravelersCities
    {
        public long Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Address")]
        public string TravelerAddress { get; set; }

        [Display(Name = "Current")]
        public bool IsCurrent { get; set; }

        [Display(Name = "Lived")]
        public bool HasLived { get; set; }

        [Display(Name = "Visited")]
        public bool HasVisited { get; set; }

        [Display(Name = "Want to Visit")]
        public bool WantVisit { get; set; }
        public long TravelerId { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public Traveler Traveler { get; set; }
    }
}
