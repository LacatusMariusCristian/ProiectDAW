using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

        public List<ArtistAlbum> ArtistAlbum { get; set; }
    }
}
