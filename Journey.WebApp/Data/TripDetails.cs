using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journey.WebApp.Data
{
    public partial class TripDetails
    {
        public TripDetails()
        {
            TripActivities = new HashSet<TripActivities>();
        }

        public long Id { get; set; }

        [Display(Name = "Stayed at")]
        public string Accomodation { get; set; }

        [Display(Name = "Details")]
        public string AccomodationDetails { get; set; }

        [Display(Name = "Arrived by")]
        public string InboundTransportation { get; set; }

        [Display(Name = "Details")]
        public string InboundTransportationDetails { get; set; }

        [Display(Name = "Departed by")]
        public string OutboundTransportation { get; set; }

        [Display(Name = "Details")]
        public string OutboundTransportationDetails { get; set; }
        public long TripCitiesId { get; set; }

        public TripCities TripCities { get; set; }
        public ICollection<TripActivities> TripActivities { get; set; }
    }
}
