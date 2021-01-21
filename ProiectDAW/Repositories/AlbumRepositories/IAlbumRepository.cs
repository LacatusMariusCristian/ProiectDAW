using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.AlbumRepositories
{
    public interface IAlbumRepository
    {
        List<Album> GetAll();
        Album Get(int Id);
        Album Create(Album Album);
        Album Update(Album Album);
        Album Delete(Album Album);
    }
}
