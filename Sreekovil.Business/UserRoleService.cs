using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.UserModule;
using System.Collections.Generic;

namespace COSMO.Business
{
    public class UserRoleService : IUserRoleService
    {
        #region Private Members

        /// <summary>
        /// The course repository for data operations.
        /// </summary>
        public IUserRoleRepository _userRoleRepository { get; set; }

        #endregion

        /// <summary>
        /// The construfctor for course service.
        /// </summary>
        /// <param name="courseRepository">The course repository to inject.</param>
        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public UserRole Get(int id)
        {
            return _userRoleRepository.Get(id);
        }

        public List<UserRole> GetAll()
        {
            return _userRoleRepository.GetAll();
        }

        public UserRole Save(UserRole userRole)
        {
            return _userRoleRepository.Save(userRole);
        }
    }
}
