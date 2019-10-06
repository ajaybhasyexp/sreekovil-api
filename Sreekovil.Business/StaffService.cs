using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System;
using System.Collections.Generic;

namespace COSMO.Business
{
    public class StaffService : IStaffService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public IStaffRepository _staffRepository { get; set; }

        public IStaffRoleRepository _staffRoleRepository { get; set; }

        #endregion

        public StaffService(IStaffRepository staffRepository, IStaffRoleRepository staffRoleRepository)
        {
            _staffRepository = staffRepository;
            _staffRoleRepository = staffRoleRepository;

        }

        public Staff Get(int id)
        {
            return _staffRepository.Get(id);
        }

        public List<Staff> GetAll()
        {
            return _staffRepository.GetAll();
        }

        public List<StaffRole> GetAllRoles()
        {
            return _staffRoleRepository.GetAll();
        }

        public StaffRole GetRole(int id)
        {
            return _staffRoleRepository.Get(id);
        }

        public Staff Save(Staff staff)
        {
            return _staffRepository.Save(staff);
        }

        public StaffRole SaveRole(StaffRole staffRole)
        {
            return _staffRoleRepository.Save(staffRole);
        }
    }
}
