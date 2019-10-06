using COSMO.Models.Models;
using COSMO.Models.ViewModel;
using System.Collections.Generic;

namespace COSMO.Business.Abstractions
{
    public interface IStudentAssignmentService
    {
        StudentAssignment Save(StudentAssignment studentAssignment);

        /// <summary>
        /// Gets a list of students whose fees are not paid.
        /// </summary>
        /// <returns>A list of students.</returns>
        List<StudentCourse> GetUnpaidStudents(int branchId);

        List<StudentAssignment> GetAllVM(int branchId);

        void Delete(StudentAssignment assign);

        /// <summary>
        /// Pay Fees Action 
        /// </summary>
        /// <param name="feePayment">The fee payment object.</param>
        /// <param name="branchId">The branch Identifier.</param>
        void PayFees(FeePayment feePayment, int branchId);
    }
}
