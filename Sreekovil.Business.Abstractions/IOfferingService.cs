using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sreekovil.Business.Abstractions
{
    public interface IOfferingService : IGenericService<Offering>
    {
        List<Offering> GetOfferingsByTempleId(int templeId);
    }
}
