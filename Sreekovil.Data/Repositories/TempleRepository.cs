using Sreekovil.Data.Abstractions.Repositories;
using Microsoft.Extensions.Configuration;
using Sreekovil.Models.Models;

namespace Sreekovil.Data.Repositories
{
    public class TempleRepository : GenericRepository<Temple>, ITempleRepository
    {

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public TempleRepository(IConfiguration config)
            : base(config)
        {
        }



    }
}
