using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class AlbumDTO
    {
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int StudioID { get; set; }

        public List<int> ArtistId { get; set; }
        public List<int> SongId { get; set; }
    }
}
