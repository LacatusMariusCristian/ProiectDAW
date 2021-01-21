using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }

        public List<SongAlbum> SongAlbum { get; set; }
    }
}
