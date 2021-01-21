using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.StudioRepository
{
    public interface IStudioRepository
    {
        List<Studio> GetAll();
        Studio Get(int Id);
        Studio Create(Studio Studio);
        Studio Update(Studio Studio);
        Studio Delete(Studio Studio);
    }
}
