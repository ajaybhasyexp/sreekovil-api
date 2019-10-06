using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business
{
    public class ExpenseService : IExpenseService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public IExpenseRepository _expenseRepository { get; set; }

        #endregion

        /// <summary>
        /// The constructor for expense service methods.
        /// </summary>
        /// <param name="expenseRepository"></param>
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        /// <summary>
        /// The method to get expense entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An expense entity based on identifier.</returns>
        public User Get(int id)
        {
            return _expenseRepository.Get(id);
        }

        /// <summary>
        /// Gets all entity items.
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            return _expenseRepository.GetAll();
        }

        /// <summary>
        /// Save the expense entity.
        /// </summary>
        /// <param name="expense"></param>
        /// <returns>The saved entity.</returns>
        public User Save(User expense)
        {
            return _expenseRepository.Save(expense);
        }

        /// <summary>
        /// Deletes the expense entity
        /// </summary>
        /// <param name="expense"></param>
        public void Delete(User expense)
        {
            _expenseRepository.Delete(expense);
        }
    }
}
