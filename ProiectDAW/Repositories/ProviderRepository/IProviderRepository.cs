using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.ProviderRepository
{
    public interface IProviderRepository
    {
        List<Provider> GetAll();
        Provider Get(int Id);
        Provider Create(Provider Provider);
        Provider Update(Provider Provider);
        Provider Delete(Provider Provider);
    }
}
