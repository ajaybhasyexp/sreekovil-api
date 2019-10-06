using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business
{
    /// <summary>
    /// The implementation of course service.
    /// </summary>
    public class CourseService : ICourseService
    {
        #region Private Members

        /// <summary>
        /// The course repository for data operations.
        /// </summary>
        public ICourseRepository _courseRepository { get; set; }

        #endregion

        /// <summary>
        /// The construfctor for course service.
        /// </summary>
        /// <param name="courseRepository">The course repository to inject.</param>
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        #region Public Methods

        /// <summary>
        /// Gets all the course entities.
        /// </summary>
        /// <returns>A list of course entities.</returns>
        public List<StarSign> GetAll()
        {
            return _courseRepository.GetAll();
        }

        public StarSign Get(int id)
        {
            return _courseRepository.Get(id);
        }

        /// <summary>
        /// Saves or updates the course entity.
        /// </summary>
        /// <param name="course">The course entity to update or save.</param>
        /// <returns>The saved course entity.</returns>
        public StarSign Save(StarSign course)
        {
            return _courseRepository.Save(course);
        }

        public void Delete(StarSign course)
        {
            _courseRepository.Delete(course);
        }

        public List<StarSign> GetAssignedCourse(int branchId)
        {
            return _courseRepository.GetAssignedCourses(branchId);
        }

        #endregion
    }
}
