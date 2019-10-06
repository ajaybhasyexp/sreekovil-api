using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business.Abstractions
{
    public interface ICourseFeeService
    {
        CourseFee Get(int id);

        List<CourseFee> GetAll(int branchId);

        CourseFee Save(CourseFee courseFee);

        void Delete(CourseFee courseFee);

        /// <summary>
        /// Gets the possible fees structure against a branch an course.
        /// </summary>
        /// <param name="branchId">The barnch Identifier</param>
        /// <param name="courseId">The course identifier.</param>
        /// <returns>A list of coursefee objects</returns>
        List<CourseFee> GetCourseFee(int branchId, int courseId);
    }
}
