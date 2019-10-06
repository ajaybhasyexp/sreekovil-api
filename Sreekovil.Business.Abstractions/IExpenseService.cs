using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business.Abstractions
{
    /// <summary>
    /// The interface for expense business methods.
    /// </summary>
    public interface IExpenseService
    {
        /// <summary>
        /// The method to get expense entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An expense entity based on identifier.</returns>
        User Get(int id);

        // <summary>
        /// Gets all entity items.
        /// </summary>
        /// <returns>A list of all expense entities.</returns>
        List<User> GetAll();

        /// <summary>
        /// Save the expense entity.
        /// </summary>
        /// <param name="expense"></param>
        /// <returns>The saved entity.</returns>
        User Save(User expense);

        /// <summary>
        /// Deletes the expense entity
        /// </summary>
        /// <param name="expense">An expense entity.</param>
        void Delete(User expense);
    }
}
