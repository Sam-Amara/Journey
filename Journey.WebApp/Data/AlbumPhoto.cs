using System;
using System.Collections.Generic;

namespace Journey.WebApp.Data
{
    public partial class AlbumPhoto
    {
        public long AlbumId { get; set; }
        public long PhotoId { get; set; }
        public int SequenceNumber { get; set; }
        public DateTime DateAdded { get; set; }

        public TravelerAlbum Album { get; set; }
        public TravelerPhoto Photo { get; set; }
    }
}
