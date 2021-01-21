using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.SongRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        public SongController(ISongRepository repository)
        {
            ISongRepository = repository;
        }
        public ISongRepository ISongRepository { get; set; }
        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get()
        {
            return ISongRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        {
            return ISongRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public Song Post(SongDTO value)
        {
            Song model = new Song()
            {
                Name = value.Name,
                Style = value.Style,
            };
            return ISongRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public Song Put(int id, SongDTO value)
        {
            Song model = ISongRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.Style != null)
            {
                model.Style = value.Style;
            }
            return ISongRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Song Delete(int id)
        {
            Song model = ISongRepository.Get(id);
            return ISongRepository.Delete(model);
        }
    }
}
