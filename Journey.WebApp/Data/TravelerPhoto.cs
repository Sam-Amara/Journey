using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journey.WebApp.Data
{
    public partial class TravelerPhoto
    {
        public TravelerPhoto()
        {
            AlbumPhoto = new HashSet<AlbumPhoto>();
        }

        public long Id { get; set; }

        [Display(Name = "Name")]
        public string PhotoName { get; set; }
        public string Thumbnail { get; set; }
        public string FilePath { get; set; }

        [Display(Name = "Location")]
        public string Loc { get; set; }
        public DateTime DateAdded { get; set; }

        public ICollection<AlbumPhoto> AlbumPhoto { get; set; }
    }
}
