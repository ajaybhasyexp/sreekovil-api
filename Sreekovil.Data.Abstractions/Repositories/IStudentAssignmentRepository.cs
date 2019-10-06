using COSMO.Models.Models;
using COSMO.Models.ViewModel;
using System.Collections.Generic;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface IStudentAssignmentRepository : IGenericRepository<StudentAssignment>
    {
        List<StudentAssignment> GetAllVM(int branchId);

        /// <summary>
        /// Gets a list of un paid students.
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        List<StudentCourse> GetUnpaidStudents(int branchId);
    }
}
