using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.ArtistAlbumRepository
{
    public interface IArtistAlbumRepository
    {
        List<ArtistAlbum> GetAll();
        ArtistAlbum Get(int Id);
        ArtistAlbum Create(ArtistAlbum artistAlbum);
        ArtistAlbum Update(ArtistAlbum artistAlbum);
        ArtistAlbum Delete(ArtistAlbum artistAlbum);
    }
}
