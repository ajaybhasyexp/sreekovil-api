using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sreekovil.Business
{
    public class DeityService : GenericService<Deity>
    {

        public DeityService(IDeityRepository deityRepository) : base(deityRepository)
        {

        }
    }
}
