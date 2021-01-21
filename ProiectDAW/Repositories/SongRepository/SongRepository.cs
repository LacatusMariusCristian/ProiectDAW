using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Contexts;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.SongRepository
{
    public class SongRepository: ISongRepository
    {
        public Context _context { get; set; }
        public SongRepository(Context context)
        {
            _context = context;
        }
        public Song Create(Song song)
        {
            var result = _context.Add<Song>(song);
            _context.SaveChanges();
            return result.Entity;
        }
        public Song Get(int Id)
        {
            return _context.Songs.SingleOrDefault(x => x.Id == Id);
        }
        public List<Song> GetAll()
        {
            return _context.Songs.ToList();
        }
        public Song Update(Song Song)
        {
            _context.Entry(Song).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Song;
        }
        public Song Delete(Song Song)
        {
            var result = _context.Remove(Song);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
