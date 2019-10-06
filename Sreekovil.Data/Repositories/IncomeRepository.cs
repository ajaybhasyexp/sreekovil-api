using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Microsoft.Extensions.Configuration;

namespace COSMO.Data.Repositories
{
    public class IncomeRepository : GenericRepository<Income>, IIncomeRepository
    {
        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public IncomeRepository(IConfiguration config)
            : base(config)
        {
        }
    }
}
