using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Contexts;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.SongAlbumRepository
{
    public class SongAlbumRepository: ISongAlbumRepository
    {
        public Context _context { get; set; }
        public SongAlbumRepository(Context context)
        {
            _context = context;
        }
        public SongAlbum Create(SongAlbum songAlbum)
        {
            var result = _context.Add<SongAlbum>(songAlbum);
            _context.SaveChanges();
            return result.Entity;
        }
        public SongAlbum Get(int Id)
        {
            return _context.SongAlbums.SingleOrDefault(x => x.Id == Id);
        }
        public List<SongAlbum> GetAll()
        {
            return _context.SongAlbums.ToList();
        }
        public SongAlbum Update(SongAlbum SongAlbum)
        {
            _context.Entry(SongAlbum).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return SongAlbum;
        }
        public SongAlbum Delete(SongAlbum SongAlbum)
        {
            var result = _context.Remove(SongAlbum);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
