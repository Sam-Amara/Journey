using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journey.WebApp.Data
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

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? Dob { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Secondary Email")]
        public string Email2 { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "About Me")]
        public string AboutMe { get; set; }

        [DataType(DataType.MultilineText)]
        public string Occupation { get; set; }

        [DataType(DataType.MultilineText)]
        public string Hobbies { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Social Media")]
        public string SocialMedia { get; set; }


        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<TravelerAlbum> TravelerAlbum { get; set; }
        public ICollection<TravelerRelationships> TravelerRelationshipsTravelerId1Navigation { get; set; }
        public ICollection<TravelerRelationships> TravelerRelationshipsTravelerId2Navigation { get; set; }
        public ICollection<TravelersCities> TravelersCities { get; set; }
        public ICollection<TravelersTrips> TravelersTrips { get; set; }
    }
}
