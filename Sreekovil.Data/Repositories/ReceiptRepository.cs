using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Microsoft.Extensions.Configuration;

namespace COSMO.Data.Repositories
{
    public class ReceiptRepository : GenericRepository<Receipt>, IRecieptRepository
    {
        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public ReceiptRepository(IConfiguration config)
            : base(config)
        {
        }
    }
}
