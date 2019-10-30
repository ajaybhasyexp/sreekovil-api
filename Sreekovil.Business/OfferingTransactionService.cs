using Sreekovil.Business.Abstractions;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Sreekovil.Models.Common;

namespace Sreekovil.Business
{
    public class OfferingTransactionService : GenericService<OfferingTransaction>, IOfferingTransactionService
    {
        #region Private Members

        /// <summary>
        /// The repository for offering entity.
        /// </summary>
        public IOfferingTransactionRepository _offeringTransactionRepository { get; set; }

        #endregion

        /// <summary>
        /// The constructor for offering service.
        /// </summary>
        /// <param name="offeringRepository">The repository for injection</param>
        public OfferingTransactionService(IOfferingTransactionRepository offeringTransactionRepository) : base(offeringTransactionRepository)
        {
            _offeringTransactionRepository = offeringTransactionRepository;

        }

        #region Public Methods

        public List<OfferingTransaction> GetOfferingTransactionByFilters(Filters filters)
        {
           return _offeringTransactionRepository.GetOfferingTransactionByFilters(filters);
        }

        public List<OfferingTransaction> SaveTransactions(List<OfferingTransaction> transactions)
        {
            return _offeringTransactionRepository.SaveTransactions(transactions);
        }

        #endregion
    }
}
