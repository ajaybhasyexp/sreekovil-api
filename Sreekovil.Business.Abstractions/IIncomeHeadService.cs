using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business.Abstractions
{
    public interface IIncomeHeadService
    {
        IncomeHead Get(int id);

        List<IncomeHead> GetAll();

        IncomeHead Save(IncomeHead incomeHead);

        void Delete(IncomeHead incomeHead);
    }
}
