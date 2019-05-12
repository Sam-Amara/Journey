using System;
using System.Collections.Generic;

namespace Journey.WebApp.Models.Entities
{
    public partial class TripDetails
    {
        public TripDetails()
        {
            TripActivities = new HashSet<TripActivities>();
        }

        public long Id { get; set; }
        public string Accomodation { get; set; }
        public string AccomodationDetails { get; set; }
        public string InboundTransportation { get; set; }
        public string InboundTransportationDetails { get; set; }
        public string OutboundTransportation { get; set; }
        public string OutboundTransportationDetails { get; set; }
        public long TripCitiesId { get; set; }

        public TripCities TripCities { get; set; }
        public ICollection<TripActivities> TripActivities { get; set; }
    }
}
