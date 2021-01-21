using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.ProviderRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        public ProviderController(IProviderRepository repository)
        {
            IProviderRepository = repository;
        }
        public IProviderRepository IProviderRepository { get; set; }
        // GET: api/Provider
        [HttpGet]
        public ActionResult <IEnumerable<Provider>> Get()
        {
            return IProviderRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<Provider> Get(int id)
        {
            return IProviderRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public Provider Post(ProviderDTO value)
        {
            Provider model = new Provider()
            {
                Name = value.Name,
            };
            return IProviderRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public Provider Put(int id, ProviderDTO value)
        {
            Provider model = IProviderRepository.Get(id);
            if(value.Name!=null)
            {
                model.Name = value.Name;
            }
            return IProviderRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Provider Delete(int id)
        {
            Provider model = IProviderRepository.Get(id);
            return IProviderRepository.Delete(model);
        }
    }
}
