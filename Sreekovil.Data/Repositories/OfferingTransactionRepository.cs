using Microsoft.Extensions.Configuration;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;

namespace Sreekovil.Data.Repositories
{
    public class OfferingTransactionRepository : GenericRepository<OfferingTransaction>, IOfferingTransactionRepository
    {
        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public OfferingTransactionRepository(IConfiguration config)
            : base(config)
        {
        }
    }
}
