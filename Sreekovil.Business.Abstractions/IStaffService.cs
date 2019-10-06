using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Business.Abstractions
{
    public interface IStaffService
    {
        List<StaffRole> GetAllRoles();

        List<Staff> GetAll();

        StaffRole GetRole(int id);

        Staff Get(int id);

        StaffRole SaveRole(StaffRole course);

        Staff Save(Staff course);
    }
}
