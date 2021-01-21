using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using Microsoft.EntityFrameworkCore;

namespace ProiectMDS.Contexts
{
    public class Context: DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistAlbum> ArtistAlbums { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongAlbum> SongAlbums { get; set; }
        public DbSet<Studio> Studios { get; set; }

        public static bool isMigration = true;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isMigration)
            {
                optionsBuilder.UseSqlServer(@"Server=.\;Database=DBProiectMDS;Trusted_Connection=True;");
            }
        }

        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) :base(options)
        {

        }
    }
}
