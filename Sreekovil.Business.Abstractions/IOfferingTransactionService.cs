using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using Sreekovil.Models.Common;
using System.Text;

namespace Sreekovil.Business.Abstractions
{
    public interface IOfferingTransactionService : IGenericService<OfferingTransaction>
    {

        List<OfferingTransaction> GetOfferingTransactionByFilters(Filters filters);

        List<OfferingTransaction> SaveTransactions(List<OfferingTransaction> transactions);
    }
}
