using COSMO.Models.Models;
using COSMO.Models.ViewModel;
using System.Collections.Generic;

namespace COSMO.Business.Abstractions
{
    public interface IBatchAssignmentService
    {
        /// <summary>
        /// Gets a single batchassignment entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The batch assignment entity.</returns>
        BatchAssignment Get(int id);

        List<BatchAssignment> GetAll();

        List<BatchAssignVM> Save(BatchAssignment assignment);

        void Delete(BatchAssignment batchAssignment);

        List<BatchAssignVM> GetVMs(int branchId);
    }
}
