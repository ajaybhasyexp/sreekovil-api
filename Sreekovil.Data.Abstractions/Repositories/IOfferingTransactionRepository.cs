using Sreekovil.Models.Models;
using Sreekovil.Models.Common;
using System.Collections.Generic;

namespace Sreekovil.Data.Abstractions.Repositories
{
    public interface IOfferingTransactionRepository : IGenericRepository<OfferingTransaction>
    {
        List<OfferingTransaction> GetOfferingTransactionByFilters(Filters filter);
    }
}