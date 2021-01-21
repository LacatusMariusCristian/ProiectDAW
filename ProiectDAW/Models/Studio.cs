using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProviderId { get; set; }

        public virtual Provider Provider { get; set; }
        public List<Album> Album { get; set; }
    }
}
