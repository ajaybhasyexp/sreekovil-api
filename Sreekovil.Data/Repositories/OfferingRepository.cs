using Microsoft.Extensions.Configuration;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;

namespace Sreekovil.Data.Repositories
{
    public class OfferingRepository : GenericRepository<Offering>, IOfferingRepository
    {
        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public OfferingRepository(IConfiguration config)
            : base(config)
        {
        }
    }
}
