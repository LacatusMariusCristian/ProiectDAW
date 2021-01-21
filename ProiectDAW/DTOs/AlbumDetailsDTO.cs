using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class AlbumDetailsDTO
    {
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int StudioId { get; set; }
        public List<string> ArtistName { get; set; }
        public List<string> SongName { get; set; }
    }
}
