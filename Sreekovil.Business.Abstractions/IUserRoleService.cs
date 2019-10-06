using COSMO.Models.UserModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Business.Abstractions
{
    public interface IUserRoleService
    {
        /// <summary>
        /// The save method for branch.
        /// </summary>
        /// <param name="branch">The entity to save or update</param>
        /// <returns>The saved or updated entity.</returns>
        UserRole Save(UserRole branch);

        /// <summary>
        /// Gets all the branch entities.
        /// </summary>
        /// <returns>A list of branch entities.</returns>
        List<UserRole> GetAll();

        /// <summary>
        /// Gets the branch entity based on the id.
        /// </summary>
        /// <param name="id">The id to get the branch.</param>
        /// <returns>A branch entity</returns>
        UserRole Get(int id);
    }
}
