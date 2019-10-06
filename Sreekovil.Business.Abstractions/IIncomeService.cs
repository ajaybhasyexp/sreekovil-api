using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Business.Abstractions
{
    public interface IIncomeService
    {
        Income Get(int id);

        List<Income> GetAll();

        Income Save(Income income);

        void Delete(Income income);
    }
}
