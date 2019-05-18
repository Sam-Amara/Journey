using System;
using System.Collections.Generic;

namespace JourneyWebApp.Data
{
    public partial class TripActivities
    {
        public long Id { get; set; }
        public string Activity { get; set; }
        public DateTime? ActivityDate { get; set; }
        public string ActivityType { get; set; }
        public decimal? Cost { get; set; }
        public string Currency { get; set; }
        public string Note { get; set; }
        public long TripDetailsId { get; set; }

        public TripDetails TripDetails { get; set; }
    }
}
