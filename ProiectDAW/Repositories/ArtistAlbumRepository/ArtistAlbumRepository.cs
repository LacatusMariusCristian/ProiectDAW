using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Contexts;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.ArtistAlbumRepository
{
    public class ArtistAlbumRepository: IArtistAlbumRepository
    {
        public Context _context { get; set; }
        public ArtistAlbumRepository(Context context)
        {
            _context = context;
        }
        public ArtistAlbum Create(ArtistAlbum artistAlbum)
        {
            var result = _context.Add<ArtistAlbum>(artistAlbum);
            _context.SaveChanges();
            return result.Entity;
        }
        public ArtistAlbum Get(int Id)
        {
            return _context.ArtistAlbums.SingleOrDefault(x => x.Id == Id);
        }
        public List<ArtistAlbum> GetAll()
        {
            return _context.ArtistAlbums.ToList();
        }
        public ArtistAlbum Update(ArtistAlbum ArtistAlbum)
        {
            _context.Entry(ArtistAlbum).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return ArtistAlbum;
        }
        public ArtistAlbum Delete(ArtistAlbum ArtistAlbum)
        {
            var result = _context.Remove(ArtistAlbum);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
