using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business
{
    public class IncomeService : IIncomeService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public IIncomeRepository _incomeRepository { get; set; }

        #endregion

        public IncomeService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        /// <summary>
        /// Gets a single income entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The income entity.</returns>
        public Income Get(int id)
        {
            return _incomeRepository.Get(id);
        }

        /// <summary>
        /// Gets all the income entities
        /// </summary>
        /// <returns></returns>
        public List<Income> GetAll()
        {
            return _incomeRepository.GetAll();
        }

        /// <summary>
        /// Save the income entity.
        /// </summary>
        /// <param name="income">The income entity to save.</param>
        /// <returns>A income entity that has been saved</returns>
        public Income Save(Income income)
        {
            return _incomeRepository.Save(income);
        }

        /// <summary>
        /// Deletes the income.
        /// </summary>
        /// <param name="income"></param>
        public void Delete(Income income)
        {
            _incomeRepository.Delete(income);
        }
    }
}
