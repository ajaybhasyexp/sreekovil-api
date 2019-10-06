using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface ICourseRepository : IGenericRepository<StarSign>
    {
        List<StarSign> GetAssignedCourses(int branchId);
    }
}
