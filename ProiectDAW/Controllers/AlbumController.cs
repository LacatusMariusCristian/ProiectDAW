using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.AlbumRepositories;
using ProiectMDS.Repositories.ArtistAlbumRepository;
using ProiectMDS.Repositories.ArtistRepository;
using ProiectMDS.Repositories.SongRepository;
using ProiectMDS.Repositories.SongAlbumRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        public IAlbumRepository IAlbumRepository { get; set; }
        public IArtistAlbumRepository IArtistAlbumRepository { get; set; }
        public ISongAlbumRepository ISongAlbumRepository { get; set; }
        public ISongRepository ISongRepository { get; set; }
        public IArtistRepository IArtistRepository { get; set; }

        public AlbumController(IAlbumRepository albumRepository, IArtistAlbumRepository artistAlbumRepository, ISongAlbumRepository songAlbumRepository, ISongRepository songRepository, IArtistRepository artistRepository)
        {
            IAlbumRepository = albumRepository;
            IArtistAlbumRepository = artistAlbumRepository;
            ISongRepository = songRepository;
            ISongAlbumRepository = songAlbumRepository;
            IArtistRepository = artistRepository;
        }
        // GET: api/Album
        [HttpGet]
        public ActionResult<IEnumerable<Album>> Get()
        {
            return IAlbumRepository.GetAll();
        }

        // GET: api/Album/5
        [HttpGet("{id}", Name = "Get")]
        public AlbumDetailsDTO Get(int id)
        {
            Album Album = IAlbumRepository.Get(id);
            AlbumDetailsDTO MyAlbum = new AlbumDetailsDTO()
            {
                Name = Album.Name,
                ReleaseYear = Album.ReleaseYear,
                StudioId = Album.StudioId
            };
            IEnumerable<SongAlbum> MySongAlbums = ISongAlbumRepository.GetAll().Where(x => x.AlbumId == Album.Id);
            if (MySongAlbums != null)
            {
                List<string> SongNameList = new List<string>();
                foreach (SongAlbum MySongAlbum in MySongAlbums)
                {
                    Song MySong = ISongRepository.GetAll().SingleOrDefault(x => x.Id == MySongAlbum.SongId);
                    SongNameList.Add(MySong.Name);
                }
                MyAlbum.SongName = SongNameList;
            }
            IEnumerable<ArtistAlbum> MyArtistAlbums = IArtistAlbumRepository.GetAll().Where(x => x.AlbumId == Album.Id);
            if (MyArtistAlbums != null)
            {
                List<string> ArtistNameList = new List<string>();
                foreach (ArtistAlbum MyArtistAlbum in MyArtistAlbums)
                {
                    Artist MyArtist = IArtistRepository.GetAll().SingleOrDefault(x => x.Id == MyArtistAlbum.ArtistId);
                    ArtistNameList.Add(MyArtist.Name);
                }
                MyAlbum.ArtistName = ArtistNameList;
            }
            return MyAlbum;
        }

        // POST: api/Album
        [HttpPost]
        public void Post(AlbumDTO value)
        {
            Album model = new Album()
            {
                Name = value.Name,
                ReleaseYear = value.ReleaseYear,
                StudioId = value.StudioID
            };
            IAlbumRepository.Create(model);
            for (int i = 0; i < value.ArtistId.Count; i++)
            {
                ArtistAlbum ArtistAlbum = new ArtistAlbum()
                {
                    AlbumId = model.Id,
                    ArtistId = value.ArtistId[i]
                };
                IArtistAlbumRepository.Create(ArtistAlbum);
            }
            for (int i = 0; i < value.SongId.Count; i++)
            {
                SongAlbum SongAlbum = new SongAlbum()
                {
                    AlbumId = model.Id,
                    SongId = value.SongId[i]
                };
                ISongAlbumRepository.Create(SongAlbum);
            }

        }

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public void Put(int id, AlbumDTO value)
        {
            Album model = IAlbumRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.ReleaseYear != 0)
            {
                model.ReleaseYear = value.ReleaseYear;
            }
            if (value.StudioID != 0)
            {
                model.StudioId = value.StudioID;
            }
            IAlbumRepository.Update(model);

            if (value.ArtistId != null)
            {
                IEnumerable<ArtistAlbum> MyArtyistAlbums = IArtistAlbumRepository.GetAll().Where(x => x.AlbumId == id);
                foreach (ArtistAlbum MyArtistAlbum in MyArtyistAlbums)
                    IArtistAlbumRepository.Delete(MyArtistAlbum);
                for (int i = 0; i < value.ArtistId.Count; i++)
                {
                    ArtistAlbum ArtistAlbum = new ArtistAlbum()
                    {
                        AlbumId = model.Id,
                        ArtistId = value.ArtistId[i]
                    };
                    IArtistAlbumRepository.Create(ArtistAlbum);
                }
            }
            if (value.SongId != null)
            {
                IEnumerable<SongAlbum> MySongAlbums = ISongAlbumRepository.GetAll().Where(x => x.AlbumId == id);
                foreach (SongAlbum MySongAlbum in MySongAlbums)
                    ISongAlbumRepository.Delete(MySongAlbum);
                for (int i = 0; i < value.SongId.Count; i++)
                {
                    SongAlbum SongAlbum = new SongAlbum()
                    {
                        AlbumId = model.Id,
                        SongId = value.ArtistId[i]
                    };
                    ISongAlbumRepository.Create(SongAlbum);
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Album Delete(int id)
        {
            Album album = IAlbumRepository.Get(id);
            return IAlbumRepository.Delete(album);
        }
    }
}