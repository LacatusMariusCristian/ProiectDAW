using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Contexts;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.ProviderRepository
{
    public class ProviderRepository: IProviderRepository
    {
        public Context _context { get; set; }
        public ProviderRepository(Context context)
        {
            _context = context;
        }
        public Provider Create(Provider provider)
        {
            var result = _context.Add<Provider>(provider);
            _context.SaveChanges();
            return result.Entity;
        }
        public Provider Get(int Id)
        {
            return _context.Providers.SingleOrDefault(x => x.Id == Id);
        }
        public List<Provider> GetAll()
        {
            return _context.Providers.ToList();
        }
        public Provider Update(Provider Provider)
        {
            _context.Entry(Provider).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Provider;
        }
        public Provider Delete(Provider Provider)
        {
            var result = _context.Remove(Provider);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
