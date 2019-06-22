using System;
using System.Collections.Generic;

namespace JourneyWebApp.Data
{
    public partial class TravelerPhoto
    {
        public TravelerPhoto()
        {
            AlbumPhoto = new HashSet<AlbumPhoto>();
        }

        public long Id { get; set; }
        public string PhotoName { get; set; }
        public byte[] Thumbnail { get; set; }
        public string FilePath { get; set; }
        public string Loc { get; set; }
        public DateTime DateAdded { get; set; }

        public ICollection<AlbumPhoto> AlbumPhoto { get; set; }
    }
}
