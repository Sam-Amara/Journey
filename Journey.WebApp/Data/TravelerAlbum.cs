using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journey.WebApp.Data
{
    public partial class TravelerAlbum
    {
        public TravelerAlbum()
        {
            AlbumPhoto = new HashSet<AlbumPhoto>();
        }

        public long Id { get; set; }

        [Display(Name = "Name")]
        public string AlbumName { get; set; }
        public string Thumbnail { get; set; }

        [Display(Name = "Description")]
        public string Descript { get; set; }
        public DateTime DateCreated { get; set; }

        [Display(Name = "Trip")]
        public long? TripId { get; set; }
        public long TravelerId { get; set; }

        public Traveler Traveler { get; set; }
        public Trip Trip { get; set; }
        public ICollection<AlbumPhoto> AlbumPhoto { get; set; }
    }
}
