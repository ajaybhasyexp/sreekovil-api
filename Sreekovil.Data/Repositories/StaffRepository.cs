using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Microsoft.Extensions.Configuration;

namespace COSMO.Data.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        #region Private Members

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public StaffRepository(IConfiguration config)
            : base(config)
        {

        }


        #endregion


    }
}
