using System;
using System.Collections.Generic;

namespace Journey.WebApp.Models.Entities
{
    public partial class Traveler
    {
        public Traveler()
        {
            TravelerAlbum = new HashSet<TravelerAlbum>();
            TravelerRelationshipsTravelerId1Navigation = new HashSet<TravelerRelationships>();
            TravelerRelationshipsTravelerId2Navigation = new HashSet<TravelerRelationships>();
            TravelersCities = new HashSet<TravelersCities>();
            TravelersTrips = new HashSet<TravelersTrips>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string AboutMe { get; set; }
        public string Occupation { get; set; }
        public string Hobbies { get; set; }
        public string SocialMedia { get; set; }
        public byte[] Pass { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<TravelerAlbum> TravelerAlbum { get; set; }
        public ICollection<TravelerRelationships> TravelerRelationshipsTravelerId1Navigation { get; set; }
        public ICollection<TravelerRelationships> TravelerRelationshipsTravelerId2Navigation { get; set; }
        public ICollection<TravelersCities> TravelersCities { get; set; }
        public ICollection<TravelersTrips> TravelersTrips { get; set; }
    }
}
