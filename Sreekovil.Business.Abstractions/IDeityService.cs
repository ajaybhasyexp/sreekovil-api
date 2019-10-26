using Sreekovil.Models.Models;
using System.Collections.Generic;

namespace Sreekovil.Business.Abstractions
{
    public interface IDeityService : IGenericService<Deity>
    {
     List<Deity> GetDietyById(int DeityId);
    }
}
