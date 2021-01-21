using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Contexts;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.ArtistRepository
{
    public class ArtistRepository: IArtistRepository
    {
        public Context _context { get; set; }
        public ArtistRepository(Context context)
        {
            _context = context;
        }
        public Artist Create(Artist artist)
        {
            var result = _context.Add<Artist>(artist);
            _context.SaveChanges();
            return result.Entity;
        }
        public Artist Get(int Id)
        {
            return _context.Artists.SingleOrDefault(x => x.Id == Id);
        }
        public List<Artist> GetAll()
        {
            return _context.Artists.ToList();
        }
        public Artist Update(Artist Artist)
        {
            _context.Entry(Artist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Artist;
        }
        public Artist Delete(Artist Artist)
        {
            var result = _context.Remove(Artist);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
