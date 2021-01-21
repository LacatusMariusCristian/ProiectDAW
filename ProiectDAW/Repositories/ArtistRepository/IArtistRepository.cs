using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.ArtistRepository
{
    public interface IArtistRepository
    {
        List<Artist> GetAll();
        Artist Get(int Id);
        Artist Create(Artist Artist);
        Artist Update(Artist Artist);
        Artist Delete(Artist Artist);
    }
}
