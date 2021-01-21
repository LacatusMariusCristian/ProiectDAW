using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Contexts;
using ProiectMDS.Models;


namespace ProiectMDS.Repositories.AlbumRepositories
{
    public class AlbumRepository:IAlbumRepository
    {
        public Context _context { get; set; }
        public AlbumRepository(Context context)
        {
            _context = context;
        }
        public Album Create(Album album)
        {
            var result = _context.Add<Album>(album);
            _context.SaveChanges();
            return result.Entity;
        }
        public Album Get(int Id)
        {
            return _context.Albums.SingleOrDefault(x => x.Id == Id);
        }
        public List<Album>GetAll()
        {
            return _context.Albums.ToList();
        }
        public Album Update(Album Album)
        {
            _context.Entry(Album).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Album;
        }
        public Album Delete(Album Album)
        {
            var result = _context.Remove(Album);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
