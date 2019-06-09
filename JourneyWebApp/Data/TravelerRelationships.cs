using System;
using System.Collections.Generic;

namespace JourneyWebApp.Data
{
    public partial class TravelerRelationships
    {
        public long TravelerId1 { get; set; }
        public long TravelerId2 { get; set; }
        public string Relationship { get; set; }
        public bool IsFollower { get; set; }
        public bool IsEmergencyContact { get; set; }
        public DateTime? StartDate { get; set; }

        public Traveler TravelerId1Navigation { get; set; }
        public Traveler TravelerId2Navigation { get; set; }
    }
}
