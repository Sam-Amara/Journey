using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journey.WebApp.Data
{
    public partial class TripActivities
    {
        public long Id { get; set; }
        public string Activity { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime? ActivityDate { get; set; }

        [Display(Name = "Type")]
        public string ActivityType { get; set; }
        public decimal? Cost { get; set; }
        public string Currency { get; set; }
        public string Note { get; set; }
        public long TripDetailsId { get; set; }

        public TripDetails TripDetails { get; set; }
    }
}
