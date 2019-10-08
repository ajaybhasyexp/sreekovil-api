using Microsoft.Extensions.Configuration;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sreekovil.Data.Repositories
{
    public class DeityRepository : GenericRepository<Deity>, IDeityRepository
    {
        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public DeityRepository(IConfiguration config) : base(config)
        {

        }
    }
}
