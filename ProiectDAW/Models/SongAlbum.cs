using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class SongAlbum
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int AlbumId { get; set; }

        public virtual Song Song { get; set; }
        public virtual Album Album { get; set; }
    }
}
