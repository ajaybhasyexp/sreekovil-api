using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sreekovil.Data.Abstractions.Repositories
{
    public interface IDeityRepository : IGenericRepository<Deity>
    {
        List<Deity> GetDietyById(int deityId);
    }
}
