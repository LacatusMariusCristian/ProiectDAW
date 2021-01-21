using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int StudioId { get; set; }

        public virtual Studio Studio { get; set; }
        public List<ArtistAlbum> ArtistAlbum { get; set; }
        public List<SongAlbum> SongAlbum { get; set; }
    }
}
