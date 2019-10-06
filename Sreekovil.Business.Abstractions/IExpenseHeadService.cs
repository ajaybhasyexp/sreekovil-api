using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Business.Abstractions
{
    public interface IExpenseHeadService
    {
        /// <summary>
        /// Gets the expense head by id.
        /// </summary>
        /// <param name="id">Identifier for Expense head.</param>
        /// <returns></returns>
        ExpenseHead Get(int id);

        /// <summary>
        /// Gets all the expense head.
        /// </summary>
        /// <returns></returns>
        List<ExpenseHead> GetAll();

        /// <summary>
        /// Saves new expense head.
        /// </summary>
        /// <param name="expenseHead"></param>
        /// <returns></returns>
        ExpenseHead Save(ExpenseHead expenseHead);

        /// <summary>
        /// Deletes the expense head.
        /// </summary>
        /// <param name="expenseHead"></param>
        void Delete(ExpenseHead expenseHead);
    }
}
