using Microsoft.Extensions.Configuration;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System.Collections.Generic;
using Sreekovil.Models.Common;
using Dapper;
using System.Linq;
using Dapper.Contrib.Extensions;

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

        /// <summary>
        /// Inserts a list of offering transaction to the DB.
        /// </summary>
        /// <param name="transactions">A list of transactions to insert.</param>
        /// <returns>a list of inserted transactions</returns>
        public List<OfferingTransaction> SaveTransactions(List<OfferingTransaction> transactions)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Insert(transactions);
                return transactions;
            }
        }
    }
}
