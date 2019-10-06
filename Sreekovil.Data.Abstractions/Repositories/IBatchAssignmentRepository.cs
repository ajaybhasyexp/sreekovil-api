using COSMO.Models.Models;
using COSMO.Models.ViewModel;
using System.Collections.Generic;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface IBatchAssignmentRepository : IGenericRepository<BatchAssignment>
    {
        List<BatchAssignVM> GetAssignVMs(int branchId);

        List<BatchAssignVM> SaveBatchAssignVMs(BatchAssignment assignment);
    }
}
