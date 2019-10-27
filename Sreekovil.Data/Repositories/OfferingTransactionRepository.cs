using Microsoft.Extensions.Configuration;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System.Collections.Generic;
using Sreekovil.Models.Common;
using Dapper;
using System.Linq;

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

        public List<OfferingTransaction> GetOfferingTransactionByFilters(Filters filters)
        {
           string query = string.Format(Queries.GetOfferingTransactionByFilters, filters.templeId, filters.fromDate, filters.toDate);
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Query<OfferingTransaction>(query).ToList();

            }
        }
    }
}
