using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journey.WebApp.Data
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

        [Display(Name = "Name")]
        public string TripName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Description")]
        public string Descript { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<TravelerAlbum> TravelerAlbum { get; set; }
        public ICollection<TravelersTrips> TravelersTrips { get; set; }
        public ICollection<TripCities> TripCities { get; set; }
    }
}
