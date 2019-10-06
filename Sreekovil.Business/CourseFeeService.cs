using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business
{
    public class CourseFeeService : ICourseFeeService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public ICourseFeeRepository _courseFeeRepository { get; set; }

        #endregion

        public CourseFeeService(ICourseFeeRepository courseFeeRepository)
        {
            _courseFeeRepository = courseFeeRepository;

        }

        public void Delete(CourseFee courseFee)
        {
            _courseFeeRepository.Delete(courseFee);
        }

        public CourseFee Get(int id)
        {
            return _courseFeeRepository.Get(id);
        }

        public List<CourseFee> GetAll(int branchId)
        {
            return _courseFeeRepository.GetCourseFeeVM(branchId);
        }

        public CourseFee Save(CourseFee courseFee)
        {
            return _courseFeeRepository.Save(courseFee);
        }

        /// <summary>
        /// Gets the possible fees structure against a branch an course.
        /// </summary>
        /// <param name="branchId">The barnch Identifier</param>
        /// <param name="courseId">The course identifier.</param>
        /// <returns>A list of coursefee objects</returns>
        public List<CourseFee> GetCourseFee(int branchId, int courseId)
        {
            return _courseFeeRepository.GetCourseFee(branchId, courseId);
        }
    }
}
