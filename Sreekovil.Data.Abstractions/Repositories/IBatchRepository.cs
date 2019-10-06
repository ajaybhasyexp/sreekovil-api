using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface IBatchRepository : IGenericRepository<Batch>
    {
        List<Batch> GetAssignedBatches(int branchId, int courseId);   
    }
}
